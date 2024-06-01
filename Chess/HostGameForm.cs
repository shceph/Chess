using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Chess
{
    public partial class HostGameForm : Form
    {
        private static Guid? gameId = null;
        public static Guid? GameId { get { return gameId; } } 

        public HostGameForm()
        {
            InitializeComponent();
            Icon = new Icon(Globals.IconPath);
        }

        private void ButtonHost_Click(object sender, EventArgs e)
        {
            using SqlConnection connection = new(Globals.ConnectionString);

            try
            {
                if (Globals.Username == string.Empty)
                {
                    throw new Exception("You must provide a username.");
                }

                // Open the connection
                connection.Open();

                // Perform database operations here
                string query = @"
                    INSERT INTO ChessGames (game_id, host_username, guest_username, game_description, is_whites_turn, board)
                    OUTPUT INSERTED.game_id
                    VALUES (NEWID(), @host_username, NULL, @description, 1, @board_string)";

                using SqlCommand command = new(query, connection);

                string? description = null;

                if (textBoxDescription.Text != string.Empty)
                {
                    description = textBoxDescription.Text;
                }

                command.Parameters.AddWithValue("@host_username", Globals.Username);
                command.Parameters.AddWithValue("@description", (object?)description ?? DBNull.Value);
                command.Parameters.AddWithValue("@board_string", Game.InitialBoardString);

                gameId = (Guid)command.ExecuteScalar();

                // Close the connection
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            Close();
        }
    }
}
