using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_PAW_2
{
    public partial class LoginControl : UserControl
    {
        public event EventHandler<LoginEventArgs> LoginSuccessful;
        public event EventHandler LoginFailed;

        public LoginControl()
        {
            InitializeComponent();
        }

        public string Username
        {
            get => textBoxUsername.Text;
            set => textBoxUsername.Text = value;
        }

        public string Password
        {
            get => textBoxPassword.Text;
            set => textBoxPassword.Text = value;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // Replace these with actual authentication logic
            if (Username == "admin" && Password == "password")
            {
                LoginSuccessful?.Invoke(this, new LoginEventArgs(Username));
                Overview frm = new Overview();
                frm.ShowDialog();
                frm.Hide();
                
            }
            else
            {
                LoginFailed?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public class LoginEventArgs : EventArgs
    {
        public string Username { get; }

        public LoginEventArgs(string username)
        {
            Username = username;
        }
    }
}