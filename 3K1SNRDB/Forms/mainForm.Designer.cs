using System.Windows.Forms;

namespace _3K1SNRDB
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("First Item");
            this.tabControl = new System.Windows.Forms.TabControl();
            this.postsTabPage = new System.Windows.Forms.TabPage();
            this.searchPostsTextBox = new System.Windows.Forms.TextBox();
            this.postsSearchButton = new System.Windows.Forms.Button();
            this.postsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.writePostButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.searchTabPage = new System.Windows.Forms.TabPage();
            this.removeButton = new System.Windows.Forms.Button();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.usersListView = new System.Windows.Forms.ListView();
            this.loginColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.firstNameColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.lastNameColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.emailColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.interestsColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.isFriendColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.postsTabPage.SuspendLayout();
            this.postsFlowLayoutPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.searchTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.postsTabPage);
            this.tabControl.Controls.Add(this.searchTabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1109, 951);
            this.tabControl.TabIndex = 0;
            // 
            // postsTabPage
            // 
            this.postsTabPage.Controls.Add(this.searchPostsTextBox);
            this.postsTabPage.Controls.Add(this.postsSearchButton);
            this.postsTabPage.Controls.Add(this.postsFlowLayoutPanel);
            this.postsTabPage.Controls.Add(this.panel2);
            this.postsTabPage.Location = new System.Drawing.Point(4, 34);
            this.postsTabPage.Name = "postsTabPage";
            this.postsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.postsTabPage.Size = new System.Drawing.Size(1101, 913);
            this.postsTabPage.TabIndex = 1;
            this.postsTabPage.Text = "Posts";
            this.postsTabPage.UseVisualStyleBackColor = true;
            // 
            // searchPostsTextBox
            // 
            this.searchPostsTextBox.Location = new System.Drawing.Point(733, 8);
            this.searchPostsTextBox.Name = "searchPostsTextBox";
            this.searchPostsTextBox.Size = new System.Drawing.Size(198, 31);
            this.searchPostsTextBox.TabIndex = 4;
            this.searchPostsTextBox.Text = "Login";
            this.searchPostsTextBox.Enter += new System.EventHandler(this.searchPostsTextBox_Enter);
            this.searchPostsTextBox.Leave += new System.EventHandler(this.searchPostsTextBox_Leave);
            // 
            // postsSearchButton
            // 
            this.postsSearchButton.Location = new System.Drawing.Point(937, 6);
            this.postsSearchButton.Name = "postsSearchButton";
            this.postsSearchButton.Size = new System.Drawing.Size(156, 34);
            this.postsSearchButton.TabIndex = 3;
            this.postsSearchButton.Text = "Search";
            this.postsSearchButton.UseMnemonic = false;
            this.postsSearchButton.UseVisualStyleBackColor = true;
            this.postsSearchButton.Click += new System.EventHandler(this.postsSearchButton_Click);
            // 
            // postsFlowLayoutPanel
            // 
            this.postsFlowLayoutPanel.AutoScroll = true;
            this.postsFlowLayoutPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.postsFlowLayoutPanel.Controls.Add(this.writePostButton);
            this.postsFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.postsFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.postsFlowLayoutPanel.Location = new System.Drawing.Point(3, 48);
            this.postsFlowLayoutPanel.Name = "postsFlowLayoutPanel";
            this.postsFlowLayoutPanel.Size = new System.Drawing.Size(1095, 862);
            this.postsFlowLayoutPanel.TabIndex = 0;
            this.postsFlowLayoutPanel.WrapContents = false;
            // 
            // writePostButton
            // 
            this.writePostButton.Location = new System.Drawing.Point(3, 3);
            this.writePostButton.Name = "writePostButton";
            this.writePostButton.Size = new System.Drawing.Size(1056, 44);
            this.writePostButton.TabIndex = 0;
            this.writePostButton.Text = "Write Post";
            this.writePostButton.UseVisualStyleBackColor = true;
            this.writePostButton.Click += new System.EventHandler(this.writePostButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1095, 45);
            this.panel2.TabIndex = 5;
            // 
            // searchTabPage
            // 
            this.searchTabPage.Controls.Add(this.removeButton);
            this.searchTabPage.Controls.Add(this.loginTextBox);
            this.searchTabPage.Controls.Add(this.addButton);
            this.searchTabPage.Controls.Add(this.lastNameTextBox);
            this.searchTabPage.Controls.Add(this.searchButton);
            this.searchTabPage.Controls.Add(this.firstNameTextBox);
            this.searchTabPage.Controls.Add(this.usersListView);
            this.searchTabPage.Controls.Add(this.panel1);
            this.searchTabPage.Location = new System.Drawing.Point(4, 34);
            this.searchTabPage.Name = "searchTabPage";
            this.searchTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.searchTabPage.Size = new System.Drawing.Size(1101, 913);
            this.searchTabPage.TabIndex = 0;
            this.searchTabPage.Text = "Search";
            this.searchTabPage.UseVisualStyleBackColor = true;
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(938, 74);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(112, 34);
            this.removeButton.TabIndex = 7;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(637, 77);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(150, 31);
            this.loginTextBox.TabIndex = 6;
            this.loginTextBox.Text = "Login";
            this.loginTextBox.Enter += new System.EventHandler(this.loginTextBox_Enter);
            this.loginTextBox.Leave += new System.EventHandler(this.loginTextBox_Leave);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(807, 74);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(112, 34);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(20, 74);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(150, 31);
            this.lastNameTextBox.TabIndex = 4;
            this.lastNameTextBox.Text = "Last Name";
            this.lastNameTextBox.Enter += new System.EventHandler(this.lastNameTextBox_Enter);
            this.lastNameTextBox.Leave += new System.EventHandler(this.lastNameTextBox_Leave);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(190, 71);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(112, 34);
            this.searchButton.TabIndex = 3;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(20, 18);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(150, 31);
            this.firstNameTextBox.TabIndex = 2;
            this.firstNameTextBox.Text = "First Name";
            this.firstNameTextBox.Enter += new System.EventHandler(this.firstNameTextBox_Enter);
            this.firstNameTextBox.Leave += new System.EventHandler(this.firstNameTextBox_Leave);
            // 
            // usersListView
            // 
            this.usersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.loginColumnHeader,
            this.firstNameColumnHeader,
            this.lastNameColumnHeader,
            this.emailColumnHeader,
            this.interestsColumnHeader,
            this.isFriendColumnHeader});
            this.usersListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usersListView.HoverSelection = true;
            this.usersListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.usersListView.Location = new System.Drawing.Point(3, 125);
            this.usersListView.Name = "usersListView";
            this.usersListView.Size = new System.Drawing.Size(1095, 785);
            this.usersListView.TabIndex = 0;
            this.usersListView.UseCompatibleStateImageBehavior = false;
            this.usersListView.View = System.Windows.Forms.View.Details;
            // 
            // loginColumnHeader
            // 
            this.loginColumnHeader.Text = "Login";
            this.loginColumnHeader.Width = 150;
            // 
            // firstNameColumnHeader
            // 
            this.firstNameColumnHeader.Tag = "";
            this.firstNameColumnHeader.Text = "First Name";
            this.firstNameColumnHeader.Width = 150;
            // 
            // lastNameColumnHeader
            // 
            this.lastNameColumnHeader.Text = "Last Name";
            this.lastNameColumnHeader.Width = 150;
            // 
            // emailColumnHeader
            // 
            this.emailColumnHeader.Text = "Email";
            this.emailColumnHeader.Width = 275;
            // 
            // interestsColumnHeader
            // 
            this.interestsColumnHeader.Text = "Interests";
            this.interestsColumnHeader.Width = 250;
            // 
            // isFriendColumnHeader
            // 
            this.isFriendColumnHeader.Text = "Friend?";
            this.isFriendColumnHeader.Width = 75;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1095, 122);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(586, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Click on comment to reply, double-click on post to comment";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 951);
            this.Controls.Add(this.tabControl);
            this.Name = "mainForm";
            this.Text = "Social Network";
            this.tabControl.ResumeLayout(false);
            this.postsTabPage.ResumeLayout(false);
            this.postsTabPage.PerformLayout();
            this.postsFlowLayoutPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.searchTabPage.ResumeLayout(false);
            this.searchTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage searchTabPage;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView usersListView;
        private System.Windows.Forms.ColumnHeader firstNameColumnHeader;
        private System.Windows.Forms.ColumnHeader lastNameColumnHeader;
        private System.Windows.Forms.ColumnHeader emailColumnHeader;
        private System.Windows.Forms.ColumnHeader interestsColumnHeader;
        private System.Windows.Forms.ColumnHeader isFriendColumnHeader;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ColumnHeader loginColumnHeader;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private TabControl tabControl;
        private Button button1;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private TabPage postsTabPage;
        private FlowLayoutPanel postsFlowLayoutPanel;
        private Button button2;
        private Button addPostButton;
        private Button addCommentButton;
        private TextBox searchPostsTextBox;
        private Button postsSearchButton;
        private Button writePostButton;
        private Panel panel1;
        private Panel panel2;
        private Label label1;
    }
}