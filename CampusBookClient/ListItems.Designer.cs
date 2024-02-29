namespace CampusBookClient
{
    partial class ListItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListItem));
            this.bookImage = new System.Windows.Forms.PictureBox();
            this.bookName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.book_image = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.book_name = new System.Windows.Forms.Label();
            this.book_owner = new System.Windows.Forms.Label();
            this.return_date = new System.Windows.Forms.Label();
            this.isAvailable = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bookImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.book_image)).BeginInit();
            this.SuspendLayout();
            // 
            // bookImage
            // 
            this.bookImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.bookImage.Image = ((System.Drawing.Image)(resources.GetObject("bookImage.Image")));
            this.bookImage.Location = new System.Drawing.Point(13, 3);
            this.bookImage.Name = "bookImage";
            this.bookImage.Size = new System.Drawing.Size(187, 229);
            this.bookImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bookImage.TabIndex = 0;
            this.bookImage.TabStop = false;
            this.bookImage.MouseLeave += new System.EventHandler(this.ListItemMouseLeave);
            this.bookImage.MouseHover += new System.EventHandler(this.ListItemMouseHover);
            // 
            // bookName
            // 
            this.bookName.AutoEllipsis = true;
            this.bookName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookName.Location = new System.Drawing.Point(229, 31);
            this.bookName.Name = "bookName";
            this.bookName.Size = new System.Drawing.Size(134, 23);
            this.bookName.TabIndex = 1;
            this.bookName.Text = "BookName";
            this.bookName.MouseLeave += new System.EventHandler(this.ListItemMouseLeave);
            this.bookName.MouseHover += new System.EventHandler(this.ListItemMouseHover);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(229, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "BookOwner";
            this.label2.MouseHover += new System.EventHandler(this.ListItemMouseHover);
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(229, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 32);
            this.label3.TabIndex = 3;
            this.label3.Text = "Return Date";
            this.label3.MouseHover += new System.EventHandler(this.ListItemMouseHover);
            // 
            // book_image
            // 
            this.book_image.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.book_image.Image = ((System.Drawing.Image)(resources.GetObject("book_image.Image")));
            this.book_image.Location = new System.Drawing.Point(13, 3);
            this.book_image.Name = "book_image";
            this.book_image.Size = new System.Drawing.Size(187, 229);
            this.book_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.book_image.TabIndex = 0;
            this.book_image.TabStop = false;
            this.book_image.MouseHover += new System.EventHandler(this.ListItemMouseHover);
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(229, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "BookName";
            this.label1.MouseHover += new System.EventHandler(this.ListItemMouseHover);
            // 
            // book_name
            // 
            this.book_name.AutoSize = true;
            this.book_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.book_name.Location = new System.Drawing.Point(453, 33);
            this.book_name.Name = "book_name";
            this.book_name.Size = new System.Drawing.Size(60, 24);
            this.book_name.TabIndex = 4;
            this.book_name.Text = "label4";
            // 
            // book_owner
            // 
            this.book_owner.AutoSize = true;
            this.book_owner.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.book_owner.Location = new System.Drawing.Point(453, 91);
            this.book_owner.Name = "book_owner";
            this.book_owner.Size = new System.Drawing.Size(0, 24);
            this.book_owner.TabIndex = 5;
            // 
            // return_date
            // 
            this.return_date.AutoSize = true;
            this.return_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.return_date.Location = new System.Drawing.Point(453, 146);
            this.return_date.Name = "return_date";
            this.return_date.Size = new System.Drawing.Size(0, 24);
            this.return_date.TabIndex = 6;
            // 
            // isAvailable
            // 
            this.isAvailable.AutoSize = true;
            this.isAvailable.BackColor = System.Drawing.Color.White;
            this.isAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.isAvailable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.isAvailable.Location = new System.Drawing.Point(245, 205);
            this.isAvailable.Name = "isAvailable";
            this.isAvailable.Size = new System.Drawing.Size(0, 22);
            this.isAvailable.TabIndex = 7;
            // 
            // ListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.isAvailable);
            this.Controls.Add(this.return_date);
            this.Controls.Add(this.book_owner);
            this.Controls.Add(this.book_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bookName);
            this.Controls.Add(this.book_image);
            this.Controls.Add(this.bookImage);
            this.Name = "ListItem";
            this.Size = new System.Drawing.Size(1050, 247);
            this.Click += new System.EventHandler(this.ListItem_Click);
            this.MouseLeave += new System.EventHandler(this.ListItemMouseLeave);
            this.MouseHover += new System.EventHandler(this.ListItemMouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.bookImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.book_image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox bookImage;
        private System.Windows.Forms.Label bookName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox book_image;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label book_name;
        private System.Windows.Forms.Label book_owner;
        private System.Windows.Forms.Label return_date;
        private System.Windows.Forms.Label isAvailable;
    }
}
