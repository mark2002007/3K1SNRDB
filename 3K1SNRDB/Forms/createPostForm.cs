using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _3K1SNRDB.Forms;

public partial class CreatePostForm : Form
{
    private readonly UserModel _currentUser;

    public CreatePostForm(UserModel currentUser)
    {
        InitializeComponent();
        _currentUser = currentUser;
    }

    private void PostButton_Click(object sender, EventArgs e)
    {
        Controller.AddPost(new PostModel
        {
            user_id = _currentUser.id,
            text = createPostTextBox.Text,
            post_time = DateTime.UtcNow,
            liked_by = new List<Guid>()
        });
        Close();
    }
}