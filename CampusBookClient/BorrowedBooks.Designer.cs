namespace CampusBookClient
{
    partial class BorrowedBooks
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BackBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Requested = new System.Windows.Forms.RadioButton();
            this.Borrowed = new System.Windows.Forms.RadioButton();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.BackBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(223, 836);
            this.panel1.TabIndex = 0;
            // 
            // BackBtn
            // 
            this.BackBtn.AutoEllipsis = true;
            this.BackBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.BackBtn.Location = new System.Drawing.Point(33, 100);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(156, 40);
            this.BackBtn.TabIndex = 2;
            this.BackBtn.Text = "Back";
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Clicked);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Requested);
            this.panel2.Controls.Add(this.Borrowed);
            this.panel2.Controls.Add(this.SearchText);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(229, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1045, 836);
            this.panel2.TabIndex = 1;
            // 
            // Requested
            // 
            this.Requested.AutoSize = true;
            this.Requested.Checked = true;
            this.Requested.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.6F);
            this.Requested.Location = new System.Drawing.Point(750, 67);
            this.Requested.Name = "Requested";
            this.Requested.Size = new System.Drawing.Size(109, 24);
            this.Requested.TabIndex = 5;
            this.Requested.TabStop = true;
            this.Requested.Text = "Requested";
            this.Requested.UseVisualStyleBackColor = true;
            this.Requested.CheckedChanged += new System.EventHandler(this.radioBtn_CheckedChanged);
            // 
            // Borrowed
            // 
            this.Borrowed.AutoSize = true;
            this.Borrowed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.6F);
            this.Borrowed.Location = new System.Drawing.Point(594, 67);
            this.Borrowed.Name = "Borrowed";
            this.Borrowed.Size = new System.Drawing.Size(98, 24);
            this.Borrowed.TabIndex = 4;
            this.Borrowed.Text = "Borrowed";
            this.Borrowed.UseVisualStyleBackColor = true;
            this.Borrowed.CheckedChanged += new System.EventHandler(this.radioBtn_CheckedChanged);
            // 
            // SearchText
            // 
            this.SearchText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SearchText.Location = new System.Drawing.Point(327, 62);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(194, 30);
            this.SearchText.TabIndex = 3;
            this.SearchText.TextChanged += new System.EventHandler(this.Search_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label1.Location = new System.Drawing.Point(159, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search Books:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(8, 136);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1057, 697);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // BorrowedBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 836);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "BorrowedBooks";
            this.Text = "BorroedBooks";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.RadioButton Requested;
        private System.Windows.Forms.RadioButton Borrowed;
    }
}