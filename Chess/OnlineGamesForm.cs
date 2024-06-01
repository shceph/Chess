using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Chess
{
    public partial class OnlineGamesForm : Form
    {
        private readonly DataTable dataTable;
        private Guid RequestId { get; set; }

        private const string columnID = "ID";
        private const string columnUsername = "Username";
        private const string columnGuestUsername = "GuestUsername";
        private const string columnDescription = "Description";
        private const string columnIsWhitesTurn = "IsWhitesTurn";
        private const string columnBoard = "Board";

        public OnlineGamesForm()
        {
            InitializeComponent();

            Icon = new Icon(Globals.IconPath);

            dataTable = new("Games");
            dataTable.Columns.Add(columnID, typeof(Guid));
            dataTable.Columns.Add(columnUsername, typeof(string));
            dataTable.Columns.Add(columnGuestUsername, typeof(string));
            dataTable.Columns.Add(columnDescription, typeof(string));
            dataTable.Columns.Add(columnIsWhitesTurn, typeof(bool));
            dataTable.Columns.Add(columnBoard, typeof(string));

            dataGridViewGames.DataSource = dataTable;

            dataGridViewGames.Columns[columnID].Visible = false;
            dataGridViewGames.Columns[columnGuestUsername].Visible = false;
            dataGridViewGames.Columns[columnIsWhitesTurn].Visible = false;
            dataGridViewGames.Columns[columnBoard].Visible = false;

            dataGridViewGames.Columns[columnID].Width = 300;
            dataGridViewGames.Columns[columnUsername].Width = 150;
            dataGridViewGames.Columns[columnDescription].Width = 500;

            UpdateGamesTable();
        }

        private void TimerUpdateGamesTable_Tick(object sender, EventArgs e)
        {
            //UpdateGamesTable();
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
                connection.Open();

                string query = "SELECT * FROM ChessGames";
                using SqlCommand command = new(query, connection);
                using SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dataTable.Rows.Add(
                            reader.GetGuid(0),   // ID
                            reader.GetString(1), // Host username
                            reader[2] == DBNull.Value ? "" : (string)reader[2], // Guest username
                            reader[3] == DBNull.Value ? "" : (string)reader[3], // Game description
                            reader.GetBoolean(4), // Is whites turn
                            reader.GetString(5)   // Board string
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
        }

        private void Join()
        {
            if (dataGridViewGames.SelectedRows.Count != 1)
            {
                return;
            }

            using SqlConnection connection = new(Globals.ConnectionString);

            try
            {
                if (Globals.Username == string.Empty)
                {
                    throw new Exception("You must provide a username.");
                }

                connection.Open();

                // Perform database operations here
                string query = @"
                    INSERT INTO JoinRequests (request_id, username, game_id, accepted)
                    OUTPUT INSERTED.request_id
                    VALUES (NEWID(), @username, @game_id, @accepted)";

                using SqlCommand command = new(query, connection);

                command.Parameters.AddWithValue("@username", Globals.Username);
                command.Parameters.AddWithValue("@game_id", (Guid)dataGridViewGames.SelectedRows[0].Cells[columnID].Value);
                command.Parameters.AddWithValue("@accepted", false);

                RequestId = (Guid)command.ExecuteScalar();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return;
            }

            MessageBox.Show("Successfully sent the join request", "Request sent");
        }

        private void ButtonHost_Click(object sender, EventArgs e)
        {
            using HostGameForm hgf = new();
            hgf.ShowDialog();
            UpdateGamesTable();
        }

        private void HostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using HostGameForm hgf = new();
            hgf.ShowDialog();
            UpdateGamesTable();
        }

        private void ButtonJoin_Click(object sender, EventArgs e)
        {
            Join();
        }

        private void JoinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Join();
        }

        private void ButtonCheckRequests_Click(object sender, EventArgs e)
        {
            if (HostGameForm.GameId is null)
            {
                MessageBox.Show("You haven't hosted a game", "Host a game");
                return;
            }

            using CheckRequestsForm crf = new();
            crf.ShowDialog();
        }
    }
}
