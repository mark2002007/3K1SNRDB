using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3K1SNRDB
{
    public partial class signInForm : Form
    {
        public signInForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (Controller.CheckPassword(loginTextBox.Text, passwordTextBox.Text))
            {
                Hide();
                var u = Controller.GetUserByLogin(loginTextBox.Text);
                new mainForm(u).Show();
            }
            else
                MessageBox.Show("Invalid login or password!");
        }
    }
}
