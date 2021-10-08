namespace _3K1SNRDB.Forms
{
    partial class createCommentForm
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
            this.createCommentTextBox = new System.Windows.Forms.TextBox();
            this.commentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createCommentTextBox
            // 
            this.createCommentTextBox.Location = new System.Drawing.Point(12, 12);
            this.createCommentTextBox.Multiline = true;
            this.createCommentTextBox.Name = "createCommentTextBox";
            this.createCommentTextBox.Size = new System.Drawing.Size(776, 370);
            this.createCommentTextBox.TabIndex = 0;
            // 
            // commentButton
            // 
            this.commentButton.Location = new System.Drawing.Point(12, 388);
            this.commentButton.Name = "commentButton";
            this.commentButton.Size = new System.Drawing.Size(776, 50);
            this.commentButton.TabIndex = 1;
            this.commentButton.Text = "Comment";
            this.commentButton.UseVisualStyleBackColor = true;
            this.commentButton.Click += new System.EventHandler(this.commentButton_Click);
            // 
            // createCommentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.commentButton);
            this.Controls.Add(this.createCommentTextBox);
            this.Name = "createCommentForm";
            this.Text = "CreateComment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox createCommentTextBox;
        private System.Windows.Forms.Button commentButton;
    }
}