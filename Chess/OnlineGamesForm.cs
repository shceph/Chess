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
        public OnlineGamesForm()
        {
            InitializeComponent();
        }

        private void OnlineGamesForm_Load(object sender, EventArgs e)
        {
            // Set the view to show details.
            listViewGames.View = System.Windows.Forms.View.Details;
            // Allow the user to edit item text.
            listViewGames.LabelEdit = true;
            // Allow the user to rearrange columns.
            listViewGames.AllowColumnReorder = true;
            // Select the item and subitems when selection is made.
            listViewGames.FullRowSelect = true;
            // Display grid lines.
            listViewGames.GridLines = true;
            // Sort the items in the list in ascending order.
            listViewGames.Sorting = System.Windows.Forms.SortOrder.Ascending;

            listViewGames.Columns.Add("Host username", 100, HorizontalAlignment.Left);
            listViewGames.Columns.Add("Game description", 300, HorizontalAlignment.Left);
            UpdateGamesTable();
        }

        private void TimerUpdateGamesTable_Tick(object sender, EventArgs e)
        {
            UpdateGamesTable();
        }

        private void UpdateGamesTable()
        {
            listViewGames.Items.Clear();

            using SqlConnection connection = new(Globals.ConnectionString);

            try
            {
                // Open the connection
                connection.Open();

                // Perform database operations here
                string query = "SELECT host_username, game_description FROM ChessGames";
                using SqlCommand command = new(query, connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listViewGames.Items.Add(new ListViewItem(new[] { reader.GetString(0), reader[1] == DBNull.Value ? "" : (string)reader[1] }));
                    }
                }
                else
                {
                    MessageBox.Show("No games found!");
                }

                // Close the connection
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
