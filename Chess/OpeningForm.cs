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
    public partial class OpeningForm : Form
    {
        public OpeningForm()
        {
            InitializeComponent();
            Icon = new Icon(Globals.IconPath);
        }

        private void Start()
        {
            using MainForm mainForm = new();
            Hide();
            mainForm.ShowDialog();
            Show();
        }

        private void OnlineGames()
        {
            if (Globals.Account == null)
            {
                MessageBox.Show("You aren't logged in", "Log in");
                return;
            }

            using OnlineGamesForm onlineGamesForm = new();
            onlineGamesForm.ShowDialog();
        }

        private void CreateAccount()
        {
            using CreateAccountForm createAccountForm = new();
            createAccountForm.ShowDialog();
        }

        private void LogOff()
        {
            if (Globals.Account != null)
            {
                MessageBox.Show("You aren't logged in");
                return;
            }

            Globals.SetAccountToNull();
            MessageBox.Show("Succesfuly logged out");
        }

        private void LogIn()
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
                    MessageBox.Show("You have logged in succesfuly", "Logged in");
                    textBoxUsername.Text = string.Empty;
                    textBoxPassword.Text = string.Empty;
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
        }

        private void OpeningForm_Activated(object sender, EventArgs e)
        {
            textBoxUsername.Focus();
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void ButtonStartOnline_Click(object sender, EventArgs e)
        {
            OnlineGames();
        }

        private void ButtonLogIn_Click(object sender, EventArgs e)
        {
            LogIn();
        }

        private void LinkLabelNoAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateAccount();
        }

        private void StartLocallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void FindOnlineGamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnlineGames();
        }

        private void LogInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogIn();
        }

        private void LogOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogOff();
        }
    }
}
