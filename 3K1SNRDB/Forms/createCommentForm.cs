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
    public partial class createCommentForm : Form
    {
        private ICommentable parent;
        private UserModel curr_user;
        public createCommentForm(ICommentable parent, UserModel currentuser)
        {
            InitializeComponent();
            this.parent = parent;
            this.curr_user = currentuser;
        }
        private void commentButton_Click(object sender, EventArgs e)
        {
            Controler.AddComment(new CommentModel
            {
            parent_id= parent.id, 
            user_id = curr_user.id, 
            depth = parent is CommentModel? ((CommentModel)parent).depth + 1 : 0, 
            text = createCommentTextBox.Text,
            comment_time = DateTime.UtcNow
            });
            Close();
        }
    }
}
