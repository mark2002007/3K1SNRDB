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
            //
        }

        private void RefreshUsers() => users = Controler.GetAllUsers();
        private void RefreshPosts() => posts = Controler.GetAllPosts().OrderByDescending(p => p.post_time).ToList();
        private void GenerateStream()
        {
            var r = postsFlowLayoutPanel.Controls;
            for (int i = postsFlowLayoutPanel.Controls.Count - 1; i >= 1; i--)
                postsFlowLayoutPanel.Controls.RemoveAt(i);
            foreach (var post in posts)
            {
                TextBox tb = new();
                tb.AppendText($"Posted by {Controler.GetUserByID(post.user_id).login} on {post.post_time}");
                tb.AppendText(Environment.NewLine);
                tb.AppendText(post.text);
                tb.Height = 150;
                tb.Dock = DockStyle.Top;
                tb.Multiline = true;
                tb.WordWrap = true;
                tb.ScrollBars = ScrollBars.Vertical;
                tb.ReadOnly = true;
                tb.DoubleClick += tb_DoubleClick;
                tb.Tag = post;
                postsFlowLayoutPanel.Controls.Add(tb);
                GenerateComments(post.id);
            }
        }

        private void tb_DoubleClick(object sender, EventArgs e)
        {
            new createCommentForm((PostModel)((TextBox)sender).Tag, user).ShowDialog();
            RefreshPosts();
            GenerateStream();
        }

        private void GenerateComments(Guid postId)
        {
            var comments = Controler.GetAllComments()
                .GroupBy(c => c.depth)
                .OrderBy(g => g.Key)
                .Select(g => g.ToList())
                .ToList();
            TreeView tv = new TreeView();
            tv.Dock = DockStyle.Top;
            tv.Height = 200;
            tv.AfterSelect += Tv_AfterSelect;
            List<List<TreeNode>> nodes= new List<List<TreeNode>>();
            for (int i = 0; i < comments.Count(); i++)
            {
                nodes.Add(new List<TreeNode>());
                for (int j = 0; j < comments[i].Count();j++)
                {
                    TreeNode tn = new TreeNode();
                    tn.Text = comments[i][j].text;
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
        public void RefreshUser() => user = Controler.GetUserByLogin(user.login);
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
            Controler.AddFriend(user, Controler.GetUserByLogin(loginTextBox.Text));
            RefreshUser();
            RefreshUsersTable();
        }
        private void removeButton_Click(object sender, EventArgs e)
        {
            Controler.RemoveFriend(user, Controler.GetUserByLogin(loginTextBox.Text));
            RefreshUser();
            RefreshUsersTable();
        }
        private void addPostButton_Click(object sender, EventArgs e)
        {
        }
        private void postsSearchButton_Click(object sender, EventArgs e)
        {
            posts = posts.Where(p => Controler.GetUserByID(p.user_id).login == searchPostsTextBox.Text)
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
        private void Tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            new createCommentForm((CommentModel)e.Node.Tag, user).ShowDialog();
            RefreshPosts();
            GenerateStream();
        }
        private void writePostButton_Click(object sender, EventArgs e)
        {
            new createPostForm(user).ShowDialog();
            RefreshPosts();
            GenerateStream();
        }
    }
}
