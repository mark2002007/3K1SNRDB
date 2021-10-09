using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3K1SNRDB.Forms;

namespace _3K1SNRDB
{
    public partial class mainForm : Form
    {
        private List<UserModel> users { get; set; }
        private UserModel user { get; set; }
        private List<PostModel> posts { get; set; }

        public mainForm(UserModel user)
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(1131, 500);
            MaximumSize = new Size(1131, 5000);
            //=====================
            //USERS TABLE
            this.user = user;
            RefreshUsers();
            RefreshUsersTable();
            RefreshPosts();
            GenerateStream();
            //TEXTBOXES
            firstNameTextBox.ForeColor = Color.Gray;
            lastNameTextBox.ForeColor = Color.Gray;
            loginTextBox.ForeColor = Color.Gray;
            searchPostsTextBox.ForeColor = Color.Gray;
        }

        private void RefreshUsers() => users = Controller.GetAllUsers();
        private void RefreshPosts() => posts = Controller.GetAllPosts().OrderByDescending(p => p.post_time).ToList();
        private void GenerateStream()
        {
            var r = postsFlowLayoutPanel.Controls;
            for (int i = postsFlowLayoutPanel.Controls.Count - 1; i >= 1; i--)
                postsFlowLayoutPanel.Controls.RemoveAt(i);
            foreach (var post in posts)
            {
                TextBox postTextBox = new();
                postTextBox.AppendText($"Posted by {Controller.GetUserByID(post.user_id).login} on {post.post_time}; Likes {post.liked_by.Count} ({(post.liked_by.Any(i => i == user.id)?"Liked" : "Like")})");
                postTextBox.AppendText(Environment.NewLine);
                postTextBox.AppendText(post.text);
                postTextBox.Height = 150;
                postTextBox.Dock = DockStyle.Top;
                postTextBox.Multiline = true;
                postTextBox.WordWrap = true;
                postTextBox.ScrollBars = ScrollBars.Vertical;
                postTextBox.ReadOnly = true;
                postTextBox.DoubleClick += postTextBox_DoubleClick;
                postTextBox.KeyPress += postTextBox_KeyPress;
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
        private void postTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (e.KeyChar == 'l' || e.KeyChar == 'д')
            {
                var post = (PostModel)textBox.Tag;
                if (Controller.GetAllPosts().Find(p => p.id == post.id).liked_by.Any(u_id => u_id == user.id))
                    Controller.RemoveLike(post, user);
                else
                    Controller.AddLike(post, user);
                RefreshPosts();
                GenerateStream();
            }
            else if(e.KeyChar == 'c') 
                postTextBox_DoubleClick(sender, e);
        }
        private void postTextBox_DoubleClick(object sender, EventArgs e)
        {
            new createCommentForm((PostModel)((TextBox)sender).Tag, user).ShowDialog();
            RefreshPosts();
            GenerateStream();
        }
        private void GenerateComments(Guid postId)
        {
            var comments = Controller.GetAllComments()
                .GroupBy(c => c.depth)
                .OrderBy(g => g.Key)
                .Select(g => g.ToList())
                .ToList();
            TreeView tv = new TreeView();
            tv.Dock = DockStyle.Top;
            tv.Height = 200;
            tv.AfterSelect += Tv_AfterSelect;
            tv.KeyPress += Tv_KeyPress;
            List<List<TreeNode>> nodes= new List<List<TreeNode>>();
            for (int i = 0; i < comments.Count(); i++)
            {
                nodes.Add(new List<TreeNode>());
                for (int j = 0; j < comments[i].Count();j++)
                {
                    TreeNode tn = new TreeNode();
                    tn.Text = $"{Controller.GetUserByID(comments[i][j].user_id).login}, Likes {comments[i][j].liked_by.Count} ({(comments[i][j].liked_by.Any(i => i == user.id) ? "Liked" : "Like")}); {comments[i][j].text}" ;
                    tn.Tag = comments[i][j];
                    if (comments[i][j].depth == 0)
                    {
                        if (comments[i][j].parent_id == postId)
                        {
                            tv.Nodes.Add(tn);
                            nodes[i].Add(tn);
                        }
                    }
                    else if (nodes[i - 1].Find(n => ((CommentModel)n.Tag).id == comments[i][j].parent_id)?.Nodes.Add(tn) != null) 
                        nodes[i].Add(tn);
                }
            }

            tv.ExpandAll();
            postsFlowLayoutPanel.Controls.Add(tv);
        }
        private void Tv_KeyPress(object sender, KeyPressEventArgs e)
        {
            var comment = (CommentModel)node_selected.Tag;
            if (e.KeyChar == 'l' || e.KeyChar == 'д')
            {
                if (Controller.GetAllComments().Find(c => c.id == comment.id)
                    .liked_by
                    .Any(u_id => u_id == user.id))
                    Controller.RemoveLike(comment, user);
                else
                    Controller.AddLike(comment, user);
                RefreshPosts();
                GenerateStream();
            }
            else if (e.KeyChar == 'c')
            {
                new createCommentForm(comment, user).ShowDialog();
                RefreshPosts();
                GenerateStream();
            }
            e.Handled = true;
        }
        public void RefreshUsersTable()
        {
            usersListView.Items.Clear();
            foreach (var u in users)
            {
                if (u.id == user.id) continue;
                ListViewItem lvi = new(
                    items: new[]
                    {
                        u.login,
                        u.first_name,
                        u.last_name,
                        u.email,
                        string.Join(", ", u.interests.ToArray()),
                        user.friends_id.Any(id => id == u.id)? "Yes" : "No"
                    });
                usersListView.Items.Add(lvi);
            }
        }
        public void RefreshUser() => user = Controller.GetUserByLogin(user.login);
        private void searchButton_Click(object sender, EventArgs e)
        {
            if(firstNameTextBox.Text != "First Name")
                users = users.Where(u => u.first_name == firstNameTextBox.Text).ToList();
            if (lastNameTextBox.Text != "Last Name")
                users = users.Where(u => u.last_name == lastNameTextBox.Text).ToList();
            RefreshUsersTable();
        }
        private void firstNameTextBox_Enter(object sender, EventArgs e)
        {
            if (firstNameTextBox.Text == "First Name")
            {
                firstNameTextBox.Text = String.Empty;
                firstNameTextBox.ForeColor = Color.Black;
            }
        }
        private void firstNameTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(firstNameTextBox.Text))
            {
                firstNameTextBox.Text = "First Name";
                firstNameTextBox.ForeColor = Color.Gray;
            }
        }
        private void lastNameTextBox_Enter(object sender, EventArgs e)
        {
            if (lastNameTextBox.Text == "Last Name")
            {
                lastNameTextBox.Text = String.Empty;
                lastNameTextBox.ForeColor = Color.Black;
            }
        }
        private void lastNameTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lastNameTextBox.Text))
            {
                lastNameTextBox.Text = "Last Name"; 
                lastNameTextBox.ForeColor = Color.Gray;
            }
        }
        private void loginTextBox_Enter(object sender, EventArgs e)
        {
            if (loginTextBox.Text == "Login")
            {
                loginTextBox.Text = String.Empty;
                loginTextBox.ForeColor = Color.Black;
            }
        }
        private void loginTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(loginTextBox.Text))
            {
                loginTextBox.Text = "Login";
                loginTextBox.ForeColor = Color.Gray;
            }
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            Controller.AddFriend(user, Controller.GetUserByLogin(loginTextBox.Text));
            RefreshUser();
            RefreshUsersTable();
        }
        private void removeButton_Click(object sender, EventArgs e)
        {
            Controller.RemoveFriend(user, Controller.GetUserByLogin(loginTextBox.Text));
            RefreshUser();
            RefreshUsersTable();
        }
        private void addPostButton_Click(object sender, EventArgs e)
        {
        }
        private void postsSearchButton_Click(object sender, EventArgs e)
        {
            posts = posts.Where(p => Controller.GetUserByID(p.user_id).login == searchPostsTextBox.Text)
                .ToList();
            GenerateStream();
        }
        private void searchPostsTextBox_Enter(object sender, EventArgs e)
        {
            if (searchPostsTextBox.Text == "Login")
            {
                searchPostsTextBox.Text = String.Empty;
                searchPostsTextBox.ForeColor = Color.Black;
            }
        }
        private void searchPostsTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchPostsTextBox.Text))
            {
                searchPostsTextBox.Text = "Login";
                searchPostsTextBox.ForeColor = Color.Gray;
            }
        }
        private TreeNode node_selected { get; set; }
        private void Tv_AfterSelect(object sender, TreeViewEventArgs e) => node_selected = e.Node;
        private void writePostButton_Click(object sender, EventArgs e)
        {
            new createPostForm(user).ShowDialog();
            RefreshPosts();
            GenerateStream();
        }
    }
}
