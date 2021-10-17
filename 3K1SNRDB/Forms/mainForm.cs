using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3K1SNRDB.Forms;

namespace _3K1SNRDB;

public partial class MainForm : Form
{
    private List<UserModel> _users { get; set; }
    private UserModel _user { get; set; }
    private List<PostModel> _posts { get; set; }
    private TreeNode _selectedNode { get; set; }

    public MainForm(UserModel user)
    {
        InitializeComponent();
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        MinimumSize = new Size(1131, 500);
        MaximumSize = new Size(1131, 5000);
        //=====================
        //USERS TABLE
        _user = user;
        RefreshUsers();
        RefreshUsersTableAsync();
        RefreshPosts();
        GenerateStream();
        //TEXTBOXES
        firstNameTextBox.ForeColor = Color.Gray;
        lastNameTextBox.ForeColor = Color.Gray;
        loginTextBox.ForeColor = Color.Gray;
        searchPostsTextBox.ForeColor = Color.Gray;
    }

    private void AddFriendButton_Click(object sender, EventArgs e)
    {
        Controller.AddFriend(_user, Controller.GetUserByLogin(loginTextBox.Text));
        RefreshUser();
        RefreshUsersTableAsync();
    }

    private void FirstNameTextBox_Enter(object sender, EventArgs e)
    {
        if (firstNameTextBox.Text == "First Name")
        {
            firstNameTextBox.Text = string.Empty;
            firstNameTextBox.ForeColor = Color.Black;
        }
    }

    private void FirstNameTextBox_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(firstNameTextBox.Text))
        {
            firstNameTextBox.Text = "First Name";
            firstNameTextBox.ForeColor = Color.Gray;
        }
    }

    private void GenerateComments(Guid postId)
    {
        var comments = Controller.GetAllComments()
            .GroupBy(c => c.depth)
            .OrderBy(g => g.Key)
            .Select(g => g.ToList())
            .ToList();
        var tv = new TreeView();
        tv.Dock = DockStyle.Top;
        tv.Height = 200;
        tv.AfterSelect += Tv_AfterSelect;
        tv.KeyPress += Tv_KeyPress;
        var nodes = new List<List<TreeNode>>();
        for (var i = 0; i < comments.Count(); i++)
        {
            nodes.Add(new List<TreeNode>());
            for (var j = 0; j < comments[i].Count(); j++)
            {
                var tn = new TreeNode();
                tn.Text =
                    $"{Controller.GetUserByID(comments[i][j].user_id).login}, Likes {comments[i][j].liked_by.Count} ({(comments[i][j].liked_by.Any(i => i == _user.id) ? "Liked" : "Like")}); {comments[i][j].text}";
                tn.Tag = comments[i][j];
                if (comments[i][j].depth == 0)
                {
                    if (comments[i][j].parent_id == postId)
                    {
                        tv.Nodes.Add(tn);
                        nodes[i].Add(tn);
                    }
                }
                else if (nodes[i - 1].Find(n => ((CommentModel)n.Tag).id == comments[i][j].parent_id)?.Nodes
                        .Add(tn) != null)
                {
                    nodes[i].Add(tn);
                }
            }
        }

        tv.ExpandAll();
        postsFlowLayoutPanel.Controls.Add(tv);
    }

    private void GenerateStream()
    {
        var r = postsFlowLayoutPanel.Controls;
        for (var i = postsFlowLayoutPanel.Controls.Count - 1; i >= 1; i--)
            postsFlowLayoutPanel.Controls.RemoveAt(i);
        foreach (var post in _posts)
        {
            TextBox postTextBox = new();
            postTextBox.AppendText(
                $"Posted by {Controller.GetUserByID(post.user_id).login} on {post.post_time}; Likes {post.liked_by.Count} ({(post.liked_by.Any(i => i == _user.id) ? "Liked" : "Like")})");
            postTextBox.AppendText(Environment.NewLine);
            postTextBox.AppendText(post.text);
            postTextBox.Height = 150;
            postTextBox.Dock = DockStyle.Top;
            postTextBox.Multiline = true;
            postTextBox.WordWrap = true;
            postTextBox.ScrollBars = ScrollBars.Vertical;
            postTextBox.ReadOnly = true;
            postTextBox.DoubleClick += PostTextBoxAddComment;
            postTextBox.KeyPress += PostTextBox_KeyPress;
            postTextBox.Tag = post;
            postsFlowLayoutPanel.Controls.Add(postTextBox);
            //
            //CheckBox cb = new CheckBox();
            //cb.Text = "Like";
            //cb.Appearance = Appearance.Button;
            //cb.AutoSize = true;
            //cb.ForeColor = Color.;
            //cb.BackColor = Color.Turquoise;
            //postsFlowLayoutPanel.Controls.Add(cb);
            //
            GenerateComments(post.id);
        }
    }

    private void LastNameTextBox_Enter(object sender, EventArgs e)
    {
        if (lastNameTextBox.Text == "Last Name")
        {
            lastNameTextBox.Text = string.Empty;
            lastNameTextBox.ForeColor = Color.Black;
        }
    }

    private void LastNameTextBox_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(lastNameTextBox.Text))
        {
            lastNameTextBox.Text = "Last Name";
            lastNameTextBox.ForeColor = Color.Gray;
        }
    }

    private void LoginTextBox_Enter(object sender, EventArgs e)
    {
        if (loginTextBox.Text == "Login")
        {
            loginTextBox.Text = string.Empty;
            loginTextBox.ForeColor = Color.Black;
        }
    }

    private void LoginTextBox_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(loginTextBox.Text))
        {
            loginTextBox.Text = "Login";
            loginTextBox.ForeColor = Color.Gray;
        }
    }

    private void PostsSearchButton_Click(object sender, EventArgs e)
    {
        RefreshPosts();
        if(searchPostsTextBox.Text != "Login")
            _posts = _posts.Where(p => Controller.GetUserByID(p.user_id).login == searchPostsTextBox.Text)
                .ToList();
        GenerateStream();
    }

    private void PostTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        var textBox = (TextBox)sender;
        if (e.KeyChar == 'l' || e.KeyChar == 'д')
        {
            var post = (PostModel)textBox.Tag;
            if (Controller.GetAllPosts().Find(p => p.id == post.id).liked_by.Any(u_id => u_id == _user.id))
                Controller.RemoveLike(post, _user);
            else
                Controller.AddLike(post, _user);
            RefreshPosts();
            GenerateStream();
        }
        else if (e.KeyChar == 'c')
        {
            PostTextBoxAddComment(sender, e);
        }
    }

    private void PostTextBoxAddComment(object sender, EventArgs e)
    {
        new CreateCommentForm((PostModel)((TextBox)sender).Tag, _user).ShowDialog();
        RefreshPosts();
        GenerateStream();
    }

    private void RefreshPosts() => _posts = Controller.GetAllPosts().OrderByDescending(p => p.post_time).ToList();
    private void RefreshUser() => _user = Controller.GetUserByLogin(_user.login);
    private void RefreshUsers() => _users = Controller.GetAllUsers();

    private async void RefreshUsersTableAsync()
    {
        string val;
        usersListView.Items.Clear();
        foreach (var u in _users)
        {
            if (u.id == _user.id) continue;
            ListViewItem lvi = new(
                new[]
                {
                    u.login,
                    u.first_name,
                    u.last_name,
                    u.email,
                    string.Join(", ", u.interests.ToArray()),
                    //_user.friends_id.Any(id => id == u.id) ? "Yes" : "No"
                    await Task.Run(() => 
                        (val = Controller.GetDistanceToUser(_user.id, u.id).ToString()) == "1"
                            ? "Friend"
                            : val)  
                });
            usersListView.Items.Add(lvi);
        }
    }

    private void RemoveButton_Click(object sender, EventArgs e)
    {
        Controller.RemoveFriend(_user, Controller.GetUserByLogin(loginTextBox.Text));
        RefreshUser();
        RefreshUsersTableAsync();
    }

    private void SearchButton_Click(object sender, EventArgs e)
    {
        RefreshUsers();
        if (firstNameTextBox.Text != "First Name")
            _users = _users.Where(u => u.first_name == firstNameTextBox.Text).ToList();
        if (lastNameTextBox.Text != "Last Name")
            _users = _users.Where(u => u.last_name == lastNameTextBox.Text).ToList();
        RefreshUsersTableAsync();
    }

    private void SearchPostsTextBox_Enter(object sender, EventArgs e)
    {
        if (searchPostsTextBox.Text == "Login")
        {
            searchPostsTextBox.Text = string.Empty;
            searchPostsTextBox.ForeColor = Color.Black;
        }
    }

    private void SearchPostsTextBox_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(searchPostsTextBox.Text))
        {
            searchPostsTextBox.Text = "Login";
            searchPostsTextBox.ForeColor = Color.Gray;
        }
    }

    private void Tv_AfterSelect(object sender, TreeViewEventArgs e)
    {
        _selectedNode = e.Node;
    }

    private void Tv_KeyPress(object sender, KeyPressEventArgs e)
    {
        var comment = (CommentModel)_selectedNode.Tag;
        if (e.KeyChar == 'l' || e.KeyChar == 'д')
        {
            if (Controller.GetAllComments().Find(c => c.id == comment.id)
                .liked_by
                .Any(u_id => u_id == _user.id))
                Controller.RemoveLike(comment, _user);
            else
                Controller.AddLike(comment, _user);
            RefreshPosts();
            GenerateStream();
        }
        else if (e.KeyChar == 'c')
        {
            new CreateCommentForm(comment, _user).ShowDialog();
            RefreshPosts();
            GenerateStream();
        }

        e.Handled = true;
    }

    private void WritePostButton_Click(object sender, EventArgs e)
    {
        new CreatePostForm(_user).ShowDialog();
        RefreshPosts();
        GenerateStream();
    }
}