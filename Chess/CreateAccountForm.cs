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
    public partial class CreateAccountForm : Form
    {
        public CreateAccountForm()
        {
            InitializeComponent();

            Icon = new Icon(Globals.IconPath);
        }

        private void ButtonCreateAccount_Click(object sender, EventArgs e)
        {
            Guid id;
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            if (password != textBoxConfirm.Text)
            {
                MessageBox.Show("Original and the confirm password must be the same", "Error");
                return;
            }

            if (!Account.UsernameAndPasswordAreValid(username, password))
            {
                return;
            }

            using SqlConnection connection = new(Globals.ConnectionString);

            try
            {
                connection.Open();

                string query = @"
                    SELECT username FROM Accounts
                    WHERE username = @username";

                using SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@username", username);
                object? query_output = command.ExecuteScalar();

                if (query_output != null)
                {
                    MessageBox.Show("The username already exists");
                    connection.Close();
                    return;
                }

                query = @"
                    INSERT INTO Accounts (id, username, password)
                    OUTPUT INSERTED.id
                    VALUES (NEWID(), @username, @password)";

                command.CommandText = query;
                command.Parameters.AddWithValue("@password", password);

                id = (Guid)command.ExecuteScalar();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return;
            }

            MessageBox.Show("Successfully created the account", "Account created");
            Close();
        }
    }
}
