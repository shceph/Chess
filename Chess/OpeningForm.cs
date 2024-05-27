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

            string iconPath = Path.Combine(Application.StartupPath, "assets", "icon.ico");
            this.Icon = new Icon(iconPath);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new();
            this.Hide();
            mainForm.ShowDialog();
            this.Show();
        }
    }
}
