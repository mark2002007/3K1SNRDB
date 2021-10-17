namespace _3K1SNRDB.Forms
{
    partial class CreatePostForm
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
            this.postButton = new System.Windows.Forms.Button();
            this.createPostTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // postButton
            // 
            this.postButton.Location = new System.Drawing.Point(12, 388);
            this.postButton.Name = "postButton";
            this.postButton.Size = new System.Drawing.Size(776, 50);
            this.postButton.TabIndex = 3;
            this.postButton.Text = "Post";
            this.postButton.UseVisualStyleBackColor = true;
            this.postButton.Click += new System.EventHandler(this.PostButton_Click);
            // 
            // createPostTextBox
            // 
            this.createPostTextBox.Location = new System.Drawing.Point(12, 12);
            this.createPostTextBox.Multiline = true;
            this.createPostTextBox.Name = "createPostTextBox";
            this.createPostTextBox.Size = new System.Drawing.Size(776, 370);
            this.createPostTextBox.TabIndex = 2;
            // 
            // createPostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.postButton);
            this.Controls.Add(this.createPostTextBox);
            this.Name = "createPostForm";
            this.Text = "createPostForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button postButton;
        private System.Windows.Forms.TextBox createPostTextBox;
    }
}