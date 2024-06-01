using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            if (textBoxUsername.Text == string.Empty)
            {
                MessageBox.Show("You need to provide a username!", "No username");
                return;
            }

            if (!Globals.SetUsername(textBoxUsername.Text))
            {
                MessageBox.Show("Your username must conatain only letters and digits!", "Wrong username");
                return;
            }

            using OnlineGamesForm ogf = new();
            ogf.ShowDialog();
        }
    }
}
