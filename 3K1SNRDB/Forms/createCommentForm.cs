using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _3K1SNRDB.Forms;

public partial class CreateCommentForm : Form
{
    private readonly UserModel curr_user;
    private readonly ICommentable parent;

    public CreateCommentForm(ICommentable parent, UserModel currentuser)
    {
        InitializeComponent();
        this.parent = parent;
        curr_user = currentuser;
    }

    private void CommentButton_Click(object sender, EventArgs e)
    {
        Controller.AddComment(new CommentModel
        {
            parent_id = parent.id,
            user_id = curr_user.id,
            depth = parent is CommentModel ? ((CommentModel)parent).depth + 1 : 0,
            text = createCommentTextBox.Text,
            comment_time = DateTime.UtcNow,
            liked_by = new List<Guid>()
        });
        Close();
    }
}