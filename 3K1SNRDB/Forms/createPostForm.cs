using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3K1SNRDB.Forms
{
    public partial class createPostForm : Form
    {
        private UserModel curr_user;
        public createPostForm(UserModel curr_user)
        {
            InitializeComponent();
            this.curr_user = curr_user;
        }

        private void postButton_Click(object sender, EventArgs e)
        {
            Controler.AddPost(new PostModel
            {
                user_id = curr_user.id,
                text = createPostTextBox.Text,
                post_time = DateTime.UtcNow
            });
            Close();
        }
    }
}
