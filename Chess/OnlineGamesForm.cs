using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.Data.SqlClient;

namespace Chess
{
    public partial class OnlineGamesForm : Form
    {
        private readonly DataTable dataTable;

        private const string columnID = "ID";
        private const string columnUsername = "Username";
        private const string columnDescription = "Description";

        public OnlineGamesForm()
        {
            InitializeComponent();

            Icon = new Icon(Globals.IconPath);

            dataTable = new("Games");
            dataTable.Columns.Add(columnID, typeof(Guid));
            dataTable.Columns.Add(columnUsername, typeof(string));
            dataTable.Columns.Add(columnDescription, typeof(string));

            dataGridViewGames.DataSource = dataTable;
            dataGridViewGames.Columns[columnID].Visible = false;
            dataGridViewGames.Columns[columnUsername].Width = 300;
            dataGridViewGames.Columns[columnDescription].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            UpdateGamesTable();
            HostGameForm.IsHosted();
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateGamesTable();
        }

        private void UpdateGamesTable()
        {
            int row_count = 0;
            dataTable.Rows.Clear();

            using SqlConnection connection = new(Globals.ConnectionString);

            try
            {
                if (Globals.Account == null)
                {
                    throw new Exception("You aren't logged in");
                }

                connection.Open();

                string query = @"
                    SELECT Games.id, Accounts.username, Games.game_description FROM Games
                    JOIN Accounts ON host_id = Accounts.id";

                using SqlCommand command = new(query, connection);
                using SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dataTable.Rows.Add(
                            reader.GetGuid(0),   // ID
                            reader.GetString(1), // Host username
                            reader[2] == DBNull.Value ? "" : (string)reader[2] // Game description
                        );

                        row_count++;
                    }
                }
                else
                {
                    MessageBox.Show("No games found!");
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            labelGameCount.Text = "Game count: " + row_count;
            dataGridViewGames.Columns[columnID].Visible = false;
        }

        private void SendRequest()
        {
            if (HostGameForm.GameID != null)
            {
                MessageBox.Show("You can't join other games while you are hosting one.", "Can't join",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dataGridViewGames.SelectedRows.Count != 1)
            {
                return;
            }

            using SqlConnection connection = new(Globals.ConnectionString);

            try
            {
                if (Globals.Account == null)
                {
                    throw new Exception("You aren't logged in");
                }

                connection.Open();

                string query = @"
                    SELECT * FROM JoinRequests
                    WHERE game_id = @game_id AND requestor_id = @requestor_id";

                using SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@game_id", (Guid)dataGridViewGames.SelectedRows[0].Cells[columnID].Value);
                command.Parameters.AddWithValue("@requestor_id", Globals.Account.Value.ID);
                object? output = command.ExecuteScalar();

                if (output != null)
                {
                    MessageBox.Show("You already sent a request to this game", "Request already sent");
                }
                else
                {
                    query = @"
                    INSERT INTO JoinRequests (id, game_id, requestor_id)
                    VALUES (NEWID(), @game_id, @requestor_id)";

                    command.CommandText = query;
                    command.ExecuteScalar();

                    MessageBox.Show("Successfully sent the join request", "Request sent");
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return;
            }
        }

        private void CheckRequests()
        {
            if (HostGameForm.GameID is null)
            {
                MessageBox.Show("You haven't hosted a game", "Host a game");
                return;
            }

            using CheckRequestsForm checkRequestsForm = new();
            checkRequestsForm.ShowDialog();
        }

        private void CheckAcceptedRequests()
        {
            using AcceptedRequestsForm acceptedRequestsForm = new();
            acceptedRequestsForm.ShowDialog();
        }

        private void Host()
        {
            if (HostGameForm.GameID != null)
            {
                MessageBox.Show("You have already hosted a game", "Can't host");
                return;
            }

            using HostGameForm hostGameForm = new();
            hostGameForm.ShowDialog();
            UpdateGamesTable();
        }

        private void ButtonHost_Click(object sender, EventArgs e)
        {
            Host();
        }

        private void HostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Host();
        }

        private void ButtonJoin_Click(object sender, EventArgs e)
        {
            SendRequest();
        }

        private void JoinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendRequest();
        }

        private void ButtonCheckRequests_Click(object sender, EventArgs e)
        {
            CheckRequests();
        }

        private void ButtonAcceptedRequests_Click(object sender, EventArgs e)
        {
            CheckAcceptedRequests();
        }

        private void CheckRequestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckRequests();
        }

        private void CheckAcceptedRequestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckAcceptedRequests();
        }
    }
}
