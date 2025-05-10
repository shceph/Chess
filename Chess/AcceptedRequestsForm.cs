using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class AcceptedRequestsForm : Form
    {
        private readonly List<Guid> ids = [];
        private readonly List<bool> hostsSide = [];

        public AcceptedRequestsForm()
        {
            InitializeComponent();
            Icon = new Icon(Globals.IconPath);
            RefreshListBox();
        }

        private void RefreshListBox()
        {
            ids.Clear();
            listBoxAcceptedRequests.Items.Clear();

            using SqlConnection connection = new(Globals.ConnectionString);

            try
            {
                if (Globals.Account == null)
                {
                    throw new Exception("You aren't logged in");
                }

                connection.Open();

                string query = @"
                    SELECT Games.id, Games.hosts_side, username
                    FROM JoinRequests
                    JOIN Games ON (Games.id = JoinRequests.game_id)
                    JOIN Accounts ON (Accounts.id = Games.host_id)
                    WHERE JoinRequests.requestor_id = @requestor_id";

                using SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@requestor_id", Globals.Account.Value.ID);

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ids.Add(reader.GetGuid(0));
                        hostsSide.Add(reader.GetBoolean(1));
                        listBoxAcceptedRequests.Items.Add(reader.GetString(2));
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

        private void EnterSelectedGame()
        {
            int selectedIndex = listBoxAcceptedRequests.SelectedIndex;

            if (selectedIndex == -1)
            {
                return;
            }

            Hide(); // If hostsSide[selectedIndex] is true, it means host's side is white, which means the side of the joining player is black
            using MainForm mainForm = new(true, hostsSide[selectedIndex] ? PieceColor.Black : PieceColor.White, ids[selectedIndex]);
            mainForm.ShowDialog();
            Show();
        }

        private void ButtonEnterGame_Click(object sender, EventArgs e)
        {
            EnterSelectedGame();
        }

        private void EnterTheGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnterSelectedGame();
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshListBox();
        }
    }
}
