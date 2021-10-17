using System;
using System.Windows.Forms;

namespace _3K1SNRDB;

public partial class SignInForm : Form
{
    public SignInForm()
    {
        InitializeComponent();
    }

    private void LoginButton_Click(object sender, EventArgs e)
    {
        if (Controller.CheckPassword(loginTextBox.Text, passwordTextBox.Text))
        {
            Hide();
            var u = Controller.GetUserByLogin(loginTextBox.Text);
            new MainForm(u).Show();
        }
        else
        {
            MessageBox.Show("Invalid login or password!");
        }
    }
}