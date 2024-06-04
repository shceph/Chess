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

namespace Chess
{
    public partial class AcceptedRequestsForm : Form
    {
        private readonly List<Guid> ids = [];

        public AcceptedRequestsForm()
        {
            InitializeComponent();
            RefreshListBox();
        }

        private void ButtonEnterGame_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBoxAcceptedRequests.SelectedIndex;

            if (selectedIndex == -1)
            {
                return;
            }

            Hide();
            using MainForm mainForm = new(true, PieceColor.Black, ids[selectedIndex]);
            mainForm.ShowDialog();
            Show();
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
                    SELECT Games.id, username
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
                        listBoxAcceptedRequests.Items.Add(reader.GetString(1));
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
    }
}
