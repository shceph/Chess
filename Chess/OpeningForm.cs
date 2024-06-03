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
    public partial class OpeningForm : Form
    {

        public OpeningForm()
        {
            InitializeComponent();
            Icon = new Icon(Globals.IconPath);
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            using MainForm mainForm = new();
            Hide();
            mainForm.ShowDialog();
            Show();
        }

        private void ButtonStartOnline_Click(object sender, EventArgs e)
        {
            if (Globals.Account == null)
            {
                MessageBox.Show("You aren't logged in", "Log in");
                return;
            }

            using OnlineGamesForm ogf = new();
            ogf.ShowDialog();
        }

        private void ButtonLogIn_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            if (!Account.UsernameAndPasswordAreValid(username, password))
            {
                return;
            }

            using SqlConnection connection = new(Globals.ConnectionString);

            try
            {
                connection.Open();

                string query = @"
                    SELECT * FROM Accounts
                    WHERE username = @username AND password = @password";

                using SqlCommand command = new(query, connection);

                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    Globals.Account = new(reader.GetGuid(0), username, password);
                    MessageBox.Show("You logged in succesfuly", "Logged in");
                }
                else
                {
                    MessageBox.Show("Your username or password are incorrect.\nCreate an account if you don't have one", "No such account");
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            textBoxUsername.Text = string.Empty;
            textBoxPassword.Text = string.Empty;
        }

        private void LinkLabelNoAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using CreateAccountForm caf = new();
            caf.ShowDialog();
        }

        private void LogOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.Account != null)
            {
                MessageBox.Show("You aren't logged in");
                return;
            }

            Globals.SetAccountToNull();
            MessageBox.Show("Succesfuly logged out");
        }
    }
}
