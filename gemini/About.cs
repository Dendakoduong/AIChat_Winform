using System;
using System.Windows.Forms;

namespace gemini
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            // Set form properties to prevent resizing and maximizing
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false; // Disable maximize button
            this.SizeGripStyle = SizeGripStyle.Hide; // Hide the size grip (bottom-right corner)
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkDiscord_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/sNeBQN7wxj");
        }

        private void linkGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Dendakoduong");
        }
    }
}
