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
        public static Guid? GameID { get { return gameId; } } 

        public HostGameForm()
        {
            InitializeComponent();
            Icon = new Icon(Globals.IconPath);
        }

        public static bool IsHosted()
        {
            if (Globals.Account == null)
            {
                MessageBox.Show("You aren't logged in", "Log in");
                return false;
            }

            if (GameID != null)
            {
                return true;
            }

            using SqlConnection connection = new(Globals.ConnectionString);

            try
            {
                connection.Open();

                // Perform database operations here
                string query = @"
                    SELECT Games.id FROM Games
                    JOIN Accounts ON host_id = Accounts.id
                    WHERE Accounts.id = @id";

                using SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@id", Globals.Account.Value.ID);

                gameId = (Guid?)command.ExecuteScalar();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            return GameID != null;
        }

        private void ButtonHost_Click(object sender, EventArgs e)
        {
            if (GameID != null)
            {
                MessageBox.Show("You have already hosted the game", "Can't host");
                return;
            }

            using SqlConnection connection = new(Globals.ConnectionString);

            try
            {
                if (Globals.Account == null)
                {
                    throw new Exception("You aren't logged in.");
                }

                // Open the connection
                connection.Open();

                // Perform database operations here
                string query = @"
                    INSERT INTO Games (id, host_id, guest_id, game_description, is_whites_turn, board)
                    OUTPUT INSERTED.id
                    VALUES (NEWID(), @host_id, NULL, @description, 1, @board_string)";

                using SqlCommand command = new(query, connection);

                string? description = null;

                if (textBoxDescription.Text != string.Empty)
                {
                    description = textBoxDescription.Text;
                }

                command.Parameters.AddWithValue("@host_id", Globals.Account.Value.ID);
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
