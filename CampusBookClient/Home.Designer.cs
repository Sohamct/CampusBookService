namespace CampusBookClient
{
    partial class Home
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
            this.SearchText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LogoutBtn = new System.Windows.Forms.Button();
            this.MyBook = new System.Windows.Forms.Button();
            this.AddNewBook = new System.Windows.Forms.Button();
            this.BorrowerBookBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchText
            // 
            this.SearchText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SearchText.Location = new System.Drawing.Point(319, 66);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(194, 30);
            this.SearchText.TabIndex = 0;
            this.SearchText.TextChanged += new System.EventHandler(this.Search_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label1.Location = new System.Drawing.Point(135, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search Books:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.SearchText);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(205, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1059, 845);
            this.panel1.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 133);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1056, 712);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.BorrowerBookBtn);
            this.panel2.Controls.Add(this.LogoutBtn);
            this.panel2.Controls.Add(this.MyBook);
            this.panel2.Controls.Add(this.AddNewBook);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(199, 845);
            this.panel2.TabIndex = 4;
            // 
            // LogoutBtn
            // 
            this.LogoutBtn.AutoEllipsis = true;
            this.LogoutBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.LogoutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LogoutBtn.Location = new System.Drawing.Point(12, 336);
            this.LogoutBtn.Name = "LogoutBtn";
            this.LogoutBtn.Size = new System.Drawing.Size(156, 40);
            this.LogoutBtn.TabIndex = 2;
            this.LogoutBtn.Text = "Logout";
            this.LogoutBtn.UseVisualStyleBackColor = false;
            this.LogoutBtn.Click += new System.EventHandler(this.Logout_Click);
            // 
            // MyBook
            // 
            this.MyBook.AutoEllipsis = true;
            this.MyBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.MyBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.MyBook.Location = new System.Drawing.Point(12, 169);
            this.MyBook.Name = "MyBook";
            this.MyBook.Size = new System.Drawing.Size(156, 40);
            this.MyBook.TabIndex = 1;
            this.MyBook.Text = "My Books";
            this.MyBook.UseVisualStyleBackColor = false;
            this.MyBook.Click += new System.EventHandler(this.MyBooks_Clicked);
            // 
            // AddNewBook
            // 
            this.AddNewBook.AutoEllipsis = true;
            this.AddNewBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.AddNewBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.AddNewBook.Location = new System.Drawing.Point(12, 69);
            this.AddNewBook.Name = "AddNewBook";
            this.AddNewBook.Size = new System.Drawing.Size(156, 40);
            this.AddNewBook.TabIndex = 0;
            this.AddNewBook.Text = "Add New Book";
            this.AddNewBook.UseVisualStyleBackColor = false;
            this.AddNewBook.Click += new System.EventHandler(this.AddNewBook_Clicked);
            // 
            // BorrowerBookBtn
            // 
            this.BorrowerBookBtn.AutoEllipsis = true;
            this.BorrowerBookBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BorrowerBookBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.BorrowerBookBtn.Location = new System.Drawing.Point(12, 249);
            this.BorrowerBookBtn.Name = "BorrowerBookBtn";
            this.BorrowerBookBtn.Size = new System.Drawing.Size(173, 40);
            this.BorrowerBookBtn.TabIndex = 3;
            this.BorrowerBookBtn.Text = "Borrowed Books";
            this.BorrowerBookBtn.UseVisualStyleBackColor = false;
            this.BorrowerBookBtn.Click += new System.EventHandler(this.BorrowedBook_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 845);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Home";
            this.Text = "Home";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button AddNewBook;
        private System.Windows.Forms.Button MyBook;
        private System.Windows.Forms.Button LogoutBtn;
        private System.Windows.Forms.Button BorrowerBookBtn;
    }
}