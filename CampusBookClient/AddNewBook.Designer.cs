namespace CampusBookClient
{
    partial class AddNewBook
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.isbn = new System.Windows.Forms.TextBox();
            this.subject = new System.Windows.Forms.TextBox();
            this.description = new System.Windows.Forms.TextBox();
            this.authorName = new System.Windows.Forms.TextBox();
            this.bookName = new System.Windows.Forms.TextBox();
            this.pages = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.bookImageButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.branchComboBox = new System.Windows.Forms.ComboBox();
            this.AcknoLabel = new System.Windows.Forms.Label();
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.bookImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.bookImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(445, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add New Book";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(210, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Book ISBN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(210, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Book Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label4.Location = new System.Drawing.Point(210, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Authorname";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label5.Location = new System.Drawing.Point(217, 350);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "Description";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label6.Location = new System.Drawing.Point(222, 478);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 24);
            this.label6.TabIndex = 5;
            this.label6.Text = "Branch";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label7.Location = new System.Drawing.Point(222, 421);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 24);
            this.label7.TabIndex = 6;
            this.label7.Text = "Subject";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label8.Location = new System.Drawing.Point(217, 621);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 24);
            this.label8.TabIndex = 7;
            this.label8.Text = "Return Date";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label9.Location = new System.Drawing.Point(227, 549);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 24);
            this.label9.TabIndex = 8;
            this.label9.Text = "Pages";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label10.Location = new System.Drawing.Point(227, 693);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 24);
            this.label10.TabIndex = 9;
            this.label10.Text = "Book Image";
            // 
            // isbn
            // 
            this.isbn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.isbn.Location = new System.Drawing.Point(403, 108);
            this.isbn.Name = "isbn";
            this.isbn.Size = new System.Drawing.Size(287, 28);
            this.isbn.TabIndex = 10;
            // 
            // subject
            // 
            this.subject.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.subject.Location = new System.Drawing.Point(403, 405);
            this.subject.Name = "subject";
            this.subject.Size = new System.Drawing.Size(287, 28);
            this.subject.TabIndex = 12;
            // 
            // description
            // 
            this.description.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.description.Location = new System.Drawing.Point(403, 344);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(287, 28);
            this.description.TabIndex = 13;
            // 
            // authorName
            // 
            this.authorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.authorName.Location = new System.Drawing.Point(403, 266);
            this.authorName.Name = "authorName";
            this.authorName.Size = new System.Drawing.Size(287, 28);
            this.authorName.TabIndex = 14;
            // 
            // bookName
            // 
            this.bookName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.bookName.Location = new System.Drawing.Point(403, 185);
            this.bookName.Name = "bookName";
            this.bookName.Size = new System.Drawing.Size(287, 28);
            this.bookName.TabIndex = 15;
            // 
            // pages
            // 
            this.pages.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.pages.Location = new System.Drawing.Point(403, 549);
            this.pages.Name = "pages";
            this.pages.Size = new System.Drawing.Size(100, 28);
            this.pages.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label11.Location = new System.Drawing.Point(734, 108);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(190, 24);
            this.label11.TabIndex = 17;
            this.label11.Text = "(e.g: 978178324029b)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label12.Location = new System.Drawing.Point(671, 629);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(151, 24);
            this.label12.TabIndex = 18;
            this.label12.Text = "(e.g: 28-02-2024)";
            // 
            // bookImageButton
            // 
            this.bookImageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.bookImageButton.Location = new System.Drawing.Point(413, 685);
            this.bookImageButton.Name = "bookImageButton";
            this.bookImageButton.Size = new System.Drawing.Size(162, 40);
            this.bookImageButton.TabIndex = 20;
            this.bookImageButton.Text = "Browse Image";
            this.bookImageButton.UseVisualStyleBackColor = true;
            this.bookImageButton.Click += new System.EventHandler(this.BrowseImage_Clicked);
            // 
            // branchComboBox
            // 
            this.branchComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.branchComboBox.FormattingEnabled = true;
            this.branchComboBox.Location = new System.Drawing.Point(403, 480);
            this.branchComboBox.Name = "branchComboBox";
            this.branchComboBox.Size = new System.Drawing.Size(114, 30);
            this.branchComboBox.TabIndex = 21;
            // 
            // AcknoLabel
            // 
            this.AcknoLabel.AutoSize = true;
            this.AcknoLabel.Location = new System.Drawing.Point(620, 699);
            this.AcknoLabel.Name = "AcknoLabel";
            this.AcknoLabel.Size = new System.Drawing.Size(0, 16);
            this.AcknoLabel.TabIndex = 22;
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.SubmitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SubmitBtn.Location = new System.Drawing.Point(650, 747);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(161, 55);
            this.SubmitBtn.TabIndex = 23;
            this.SubmitBtn.Text = "Add Book";
            this.SubmitBtn.UseVisualStyleBackColor = false;
            this.SubmitBtn.Click += new System.EventHandler(this.Submit_Clicked);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button2.Location = new System.Drawing.Point(34, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 41);
            this.button2.TabIndex = 24;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Back_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.dateTimePicker.Location = new System.Drawing.Point(391, 617);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 28);
            this.dateTimePicker.TabIndex = 25;
            // 
            // bookImage
            // 
            this.bookImage.Location = new System.Drawing.Point(798, 162);
            this.bookImage.Name = "bookImage";
            this.bookImage.Size = new System.Drawing.Size(241, 258);
            this.bookImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bookImage.TabIndex = 26;
            this.bookImage.TabStop = false;
            // 
            // AddNewBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1124, 860);
            this.Controls.Add(this.bookImage);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.SubmitBtn);
            this.Controls.Add(this.AcknoLabel);
            this.Controls.Add(this.branchComboBox);
            this.Controls.Add(this.bookImageButton);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.pages);
            this.Controls.Add(this.bookName);
            this.Controls.Add(this.authorName);
            this.Controls.Add(this.description);
            this.Controls.Add(this.subject);
            this.Controls.Add(this.isbn);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddNewBook";
            this.Text = "AddNewBook";
            this.Load += new System.EventHandler(this.AddNewBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bookImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox isbn;
        private System.Windows.Forms.TextBox subject;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.TextBox authorName;
        private System.Windows.Forms.TextBox bookName;
        private System.Windows.Forms.TextBox pages;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button bookImageButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox branchComboBox;
        private System.Windows.Forms.Label AcknoLabel;
        private System.Windows.Forms.Button SubmitBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.PictureBox bookImage;
    }
}