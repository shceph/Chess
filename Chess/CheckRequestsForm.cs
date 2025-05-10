using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Chess
{
    public partial class CheckRequestsForm : Form
    {
        private readonly List<Guid> ids = [];

        public CheckRequestsForm()
        {
            InitializeComponent();

            Icon = new Icon(Globals.IconPath);
            RefreshListBox();
        }

        private void RefreshListBox()
        {
            ids.Clear();
            listBoxRequests.Items.Clear();

            using SqlConnection connection = new(Globals.ConnectionString);

            try
            {
                if (Globals.Account == null)
                {
                    throw new Exception("You aren't logged in");
                }

                connection.Open();

                string query = @"
                    SELECT JoinRequests.id, username FROM Accounts
                    JOIN JoinRequests ON (JoinRequests.requestor_id = Accounts.id)
                    WHERE JoinRequests.game_id = (SELECT id FROM Games
                    WHERE host_id = @current_account_id)";

                using SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@current_account_id", Globals.Account.Value.ID);

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ids.Add(reader.GetGuid(0));
                        listBoxRequests.Items.Add(reader.GetString(1));
                    }
                }
                else
                {
                    MessageBox.Show("No requests found!");
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void AcceptSelectedRequest()
        {
            int selectedIndex = listBoxRequests.SelectedIndex;

            if (selectedIndex == -1)
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
                    UPDATE JoinRequests
                    SET accepted = 1
                    WHERE id = @id";

                using SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@id", ids[selectedIndex]);
                command.ExecuteScalar();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            MessageBox.Show("The request has been accepted successfully", "Request accepted");

            Hide();
            using MainForm mainForm = new(true, HostGameForm.HostsSide, HostGameForm.GameID);
            mainForm.ShowDialog();
            Show();
        }

        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            AcceptSelectedRequest();
        }

        private void AcceptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcceptSelectedRequest();
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshListBox();
        }
    }
}
