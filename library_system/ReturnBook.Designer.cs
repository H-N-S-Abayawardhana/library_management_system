namespace library_system
{
    partial class ReturnBook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReturnBook));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnclose = new System.Windows.Forms.Button();
            this.HeaderinReturnBook = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBorrowedBooks = new System.Windows.Forms.TextBox();
            this.btnsearch = new System.Windows.Forms.Button();
            this.txtEnterUNumber = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtNameUser = new System.Windows.Forms.TextBox();
            this.txtNumberNIC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtborrowedB1 = new System.Windows.Forms.TextBox();
            this.txtborrowedB2 = new System.Windows.Forms.TextBox();
            this.txtborrowedB3 = new System.Windows.Forms.TextBox();
            this.txtborrowedB4 = new System.Windows.Forms.TextBox();
            this.txtborrowedB5 = new System.Windows.Forms.TextBox();
            this.txtborrowedDate5 = new System.Windows.Forms.TextBox();
            this.txtborrowedDate4 = new System.Windows.Forms.TextBox();
            this.txtborrowedDate3 = new System.Windows.Forms.TextBox();
            this.txtborrowedDate2 = new System.Windows.Forms.TextBox();
            this.txtborrowedDate1 = new System.Windows.Forms.TextBox();
            this.btncancel = new System.Windows.Forms.Button();
            this.txtreturnDate5 = new System.Windows.Forms.TextBox();
            this.txtreturnDate4 = new System.Windows.Forms.TextBox();
            this.txtreturnDate3 = new System.Windows.Forms.TextBox();
            this.txtreturnDate2 = new System.Windows.Forms.TextBox();
            this.txtreturnDate1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnreturn1 = new System.Windows.Forms.Button();
            this.btnreturn2 = new System.Windows.Forms.Button();
            this.btnreturn3 = new System.Windows.Forms.Button();
            this.btnreturn4 = new System.Windows.Forms.Button();
            this.btnreturn5 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Blue;
            this.panel1.Controls.Add(this.btnclose);
            this.panel1.Controls.Add(this.HeaderinReturnBook);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1441, 112);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.Red;
            this.btnclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclose.ForeColor = System.Drawing.Color.White;
            this.btnclose.Location = new System.Drawing.Point(1390, 1);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(44, 40);
            this.btnclose.TabIndex = 2;
            this.btnclose.Text = "X";
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.button2_Click);
            // 
            // HeaderinReturnBook
            // 
            this.HeaderinReturnBook.AutoSize = true;
            this.HeaderinReturnBook.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderinReturnBook.ForeColor = System.Drawing.Color.White;
            this.HeaderinReturnBook.Location = new System.Drawing.Point(506, 30);
            this.HeaderinReturnBook.Name = "HeaderinReturnBook";
            this.HeaderinReturnBook.Size = new System.Drawing.Size(429, 73);
            this.HeaderinReturnBook.TabIndex = 0;
            this.HeaderinReturnBook.Text = "RETURN BOOKS";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtBorrowedBooks);
            this.panel2.Controls.Add(this.btnsearch);
            this.panel2.Controls.Add(this.txtEnterUNumber);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(0, 112);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(452, 543);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(24, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Search By User Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(47, 403);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(255, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Number of Books Borrowed :";
            // 
            // txtBorrowedBooks
            // 
            this.txtBorrowedBooks.BackColor = System.Drawing.Color.White;
            this.txtBorrowedBooks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBorrowedBooks.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtBorrowedBooks.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBorrowedBooks.Location = new System.Drawing.Point(340, 394);
            this.txtBorrowedBooks.Name = "txtBorrowedBooks";
            this.txtBorrowedBooks.ReadOnly = true;
            this.txtBorrowedBooks.Size = new System.Drawing.Size(69, 40);
            this.txtBorrowedBooks.TabIndex = 4;
            this.txtBorrowedBooks.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnsearch
            // 
            this.btnsearch.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnsearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnsearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnsearch.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsearch.ForeColor = System.Drawing.Color.White;
            this.btnsearch.Location = new System.Drawing.Point(347, 320);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(84, 32);
            this.btnsearch.TabIndex = 3;
            this.btnsearch.Text = "Search";
            this.btnsearch.UseVisualStyleBackColor = false;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // txtEnterUNumber
            // 
            this.txtEnterUNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEnterUNumber.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnterUNumber.Location = new System.Drawing.Point(70, 322);
            this.txtEnterUNumber.Name = "txtEnterUNumber";
            this.txtEnterUNumber.Size = new System.Drawing.Size(255, 32);
            this.txtEnterUNumber.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(111, 31);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(232, 212);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // txtNameUser
            // 
            this.txtNameUser.BackColor = System.Drawing.Color.White;
            this.txtNameUser.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtNameUser.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameUser.Location = new System.Drawing.Point(719, 143);
            this.txtNameUser.Name = "txtNameUser";
            this.txtNameUser.ReadOnly = true;
            this.txtNameUser.Size = new System.Drawing.Size(232, 32);
            this.txtNameUser.TabIndex = 2;
            // 
            // txtNumberNIC
            // 
            this.txtNumberNIC.BackColor = System.Drawing.Color.White;
            this.txtNumberNIC.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtNumberNIC.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumberNIC.Location = new System.Drawing.Point(719, 200);
            this.txtNumberNIC.Name = "txtNumberNIC";
            this.txtNumberNIC.ReadOnly = true;
            this.txtNumberNIC.Size = new System.Drawing.Size(232, 32);
            this.txtNumberNIC.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(472, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "Name of the User :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label5.Location = new System.Drawing.Point(472, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 24);
            this.label5.TabIndex = 7;
            this.label5.Text = "NIC Number :";
            // 
            // txtborrowedB1
            // 
            this.txtborrowedB1.BackColor = System.Drawing.Color.White;
            this.txtborrowedB1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtborrowedB1.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtborrowedB1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtborrowedB1.Location = new System.Drawing.Point(489, 323);
            this.txtborrowedB1.Name = "txtborrowedB1";
            this.txtborrowedB1.ReadOnly = true;
            this.txtborrowedB1.Size = new System.Drawing.Size(232, 32);
            this.txtborrowedB1.TabIndex = 8;
            this.txtborrowedB1.TextChanged += new System.EventHandler(this.txtborrowedB1_TextChanged);
            // 
            // txtborrowedB2
            // 
            this.txtborrowedB2.BackColor = System.Drawing.Color.White;
            this.txtborrowedB2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtborrowedB2.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtborrowedB2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtborrowedB2.Location = new System.Drawing.Point(489, 373);
            this.txtborrowedB2.Name = "txtborrowedB2";
            this.txtborrowedB2.ReadOnly = true;
            this.txtborrowedB2.Size = new System.Drawing.Size(232, 32);
            this.txtborrowedB2.TabIndex = 9;
            // 
            // txtborrowedB3
            // 
            this.txtborrowedB3.BackColor = System.Drawing.Color.White;
            this.txtborrowedB3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtborrowedB3.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtborrowedB3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtborrowedB3.Location = new System.Drawing.Point(489, 421);
            this.txtborrowedB3.Name = "txtborrowedB3";
            this.txtborrowedB3.ReadOnly = true;
            this.txtborrowedB3.Size = new System.Drawing.Size(232, 32);
            this.txtborrowedB3.TabIndex = 10;
            // 
            // txtborrowedB4
            // 
            this.txtborrowedB4.BackColor = System.Drawing.Color.White;
            this.txtborrowedB4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtborrowedB4.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtborrowedB4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtborrowedB4.Location = new System.Drawing.Point(489, 468);
            this.txtborrowedB4.Name = "txtborrowedB4";
            this.txtborrowedB4.ReadOnly = true;
            this.txtborrowedB4.Size = new System.Drawing.Size(232, 32);
            this.txtborrowedB4.TabIndex = 11;
            // 
            // txtborrowedB5
            // 
            this.txtborrowedB5.BackColor = System.Drawing.Color.White;
            this.txtborrowedB5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtborrowedB5.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtborrowedB5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtborrowedB5.Location = new System.Drawing.Point(489, 515);
            this.txtborrowedB5.Name = "txtborrowedB5";
            this.txtborrowedB5.ReadOnly = true;
            this.txtborrowedB5.Size = new System.Drawing.Size(232, 32);
            this.txtborrowedB5.TabIndex = 12;
            // 
            // txtborrowedDate5
            // 
            this.txtborrowedDate5.BackColor = System.Drawing.Color.White;
            this.txtborrowedDate5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtborrowedDate5.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtborrowedDate5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtborrowedDate5.Location = new System.Drawing.Point(739, 515);
            this.txtborrowedDate5.Name = "txtborrowedDate5";
            this.txtborrowedDate5.ReadOnly = true;
            this.txtborrowedDate5.Size = new System.Drawing.Size(211, 32);
            this.txtborrowedDate5.TabIndex = 17;
            // 
            // txtborrowedDate4
            // 
            this.txtborrowedDate4.BackColor = System.Drawing.Color.White;
            this.txtborrowedDate4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtborrowedDate4.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtborrowedDate4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtborrowedDate4.Location = new System.Drawing.Point(739, 468);
            this.txtborrowedDate4.Name = "txtborrowedDate4";
            this.txtborrowedDate4.ReadOnly = true;
            this.txtborrowedDate4.Size = new System.Drawing.Size(211, 32);
            this.txtborrowedDate4.TabIndex = 16;
            // 
            // txtborrowedDate3
            // 
            this.txtborrowedDate3.BackColor = System.Drawing.Color.White;
            this.txtborrowedDate3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtborrowedDate3.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtborrowedDate3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtborrowedDate3.Location = new System.Drawing.Point(739, 421);
            this.txtborrowedDate3.Name = "txtborrowedDate3";
            this.txtborrowedDate3.ReadOnly = true;
            this.txtborrowedDate3.Size = new System.Drawing.Size(211, 32);
            this.txtborrowedDate3.TabIndex = 15;
            // 
            // txtborrowedDate2
            // 
            this.txtborrowedDate2.BackColor = System.Drawing.Color.White;
            this.txtborrowedDate2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtborrowedDate2.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtborrowedDate2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtborrowedDate2.Location = new System.Drawing.Point(739, 373);
            this.txtborrowedDate2.Name = "txtborrowedDate2";
            this.txtborrowedDate2.ReadOnly = true;
            this.txtborrowedDate2.Size = new System.Drawing.Size(211, 32);
            this.txtborrowedDate2.TabIndex = 14;
            // 
            // txtborrowedDate1
            // 
            this.txtborrowedDate1.BackColor = System.Drawing.Color.White;
            this.txtborrowedDate1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtborrowedDate1.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtborrowedDate1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtborrowedDate1.Location = new System.Drawing.Point(739, 323);
            this.txtborrowedDate1.Name = "txtborrowedDate1";
            this.txtborrowedDate1.ReadOnly = true;
            this.txtborrowedDate1.Size = new System.Drawing.Size(211, 32);
            this.txtborrowedDate1.TabIndex = 13;
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.Color.Red;
            this.btncancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btncancel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.ForeColor = System.Drawing.Color.White;
            this.btncancel.Location = new System.Drawing.Point(779, 585);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(148, 36);
            this.btncancel.TabIndex = 24;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // txtreturnDate5
            // 
            this.txtreturnDate5.BackColor = System.Drawing.Color.White;
            this.txtreturnDate5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtreturnDate5.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtreturnDate5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreturnDate5.Location = new System.Drawing.Point(969, 515);
            this.txtreturnDate5.Name = "txtreturnDate5";
            this.txtreturnDate5.ReadOnly = true;
            this.txtreturnDate5.Size = new System.Drawing.Size(199, 32);
            this.txtreturnDate5.TabIndex = 29;
            // 
            // txtreturnDate4
            // 
            this.txtreturnDate4.BackColor = System.Drawing.Color.White;
            this.txtreturnDate4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtreturnDate4.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtreturnDate4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreturnDate4.Location = new System.Drawing.Point(969, 468);
            this.txtreturnDate4.Name = "txtreturnDate4";
            this.txtreturnDate4.ReadOnly = true;
            this.txtreturnDate4.Size = new System.Drawing.Size(199, 32);
            this.txtreturnDate4.TabIndex = 28;
            // 
            // txtreturnDate3
            // 
            this.txtreturnDate3.BackColor = System.Drawing.Color.White;
            this.txtreturnDate3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtreturnDate3.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtreturnDate3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreturnDate3.Location = new System.Drawing.Point(969, 421);
            this.txtreturnDate3.Name = "txtreturnDate3";
            this.txtreturnDate3.ReadOnly = true;
            this.txtreturnDate3.Size = new System.Drawing.Size(199, 32);
            this.txtreturnDate3.TabIndex = 27;
            // 
            // txtreturnDate2
            // 
            this.txtreturnDate2.BackColor = System.Drawing.Color.White;
            this.txtreturnDate2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtreturnDate2.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtreturnDate2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreturnDate2.Location = new System.Drawing.Point(969, 373);
            this.txtreturnDate2.Name = "txtreturnDate2";
            this.txtreturnDate2.ReadOnly = true;
            this.txtreturnDate2.Size = new System.Drawing.Size(199, 32);
            this.txtreturnDate2.TabIndex = 26;
            // 
            // txtreturnDate1
            // 
            this.txtreturnDate1.BackColor = System.Drawing.Color.White;
            this.txtreturnDate1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtreturnDate1.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtreturnDate1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreturnDate1.Location = new System.Drawing.Point(969, 323);
            this.txtreturnDate1.Name = "txtreturnDate1";
            this.txtreturnDate1.ReadOnly = true;
            this.txtreturnDate1.Size = new System.Drawing.Size(199, 32);
            this.txtreturnDate1.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Default;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label6.Location = new System.Drawing.Point(528, 278);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 24);
            this.label6.TabIndex = 30;
            this.label6.Text = "Borrowed Books :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.Default;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label7.Location = new System.Drawing.Point(735, 278);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 24);
            this.label7.TabIndex = 31;
            this.label7.Text = "Borrowed Date :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Cursor = System.Windows.Forms.Cursors.Default;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label8.Location = new System.Drawing.Point(965, 278);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 24);
            this.label8.TabIndex = 32;
            this.label8.Text = "Return Date :";
            // 
            // btnreturn1
            // 
            this.btnreturn1.BackColor = System.Drawing.Color.Lime;
            this.btnreturn1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnreturn1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreturn1.ForeColor = System.Drawing.Color.White;
            this.btnreturn1.Location = new System.Drawing.Point(1206, 323);
            this.btnreturn1.Name = "btnreturn1";
            this.btnreturn1.Size = new System.Drawing.Size(84, 32);
            this.btnreturn1.TabIndex = 39;
            this.btnreturn1.Text = "Return";
            this.btnreturn1.UseVisualStyleBackColor = false;
            this.btnreturn1.Click += new System.EventHandler(this.btnreturn1_Click);
            // 
            // btnreturn2
            // 
            this.btnreturn2.BackColor = System.Drawing.Color.Lime;
            this.btnreturn2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnreturn2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreturn2.ForeColor = System.Drawing.Color.White;
            this.btnreturn2.Location = new System.Drawing.Point(1206, 373);
            this.btnreturn2.Name = "btnreturn2";
            this.btnreturn2.Size = new System.Drawing.Size(84, 32);
            this.btnreturn2.TabIndex = 40;
            this.btnreturn2.Text = "Return";
            this.btnreturn2.UseVisualStyleBackColor = false;
            this.btnreturn2.Click += new System.EventHandler(this.btnreturn2_Click_1);
            // 
            // btnreturn3
            // 
            this.btnreturn3.BackColor = System.Drawing.Color.Lime;
            this.btnreturn3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnreturn3.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreturn3.ForeColor = System.Drawing.Color.White;
            this.btnreturn3.Location = new System.Drawing.Point(1206, 421);
            this.btnreturn3.Name = "btnreturn3";
            this.btnreturn3.Size = new System.Drawing.Size(84, 32);
            this.btnreturn3.TabIndex = 41;
            this.btnreturn3.Text = "Return";
            this.btnreturn3.UseVisualStyleBackColor = false;
            this.btnreturn3.Click += new System.EventHandler(this.btnreturn3_Click_1);
            // 
            // btnreturn4
            // 
            this.btnreturn4.BackColor = System.Drawing.Color.Lime;
            this.btnreturn4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnreturn4.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreturn4.ForeColor = System.Drawing.Color.White;
            this.btnreturn4.Location = new System.Drawing.Point(1206, 468);
            this.btnreturn4.Name = "btnreturn4";
            this.btnreturn4.Size = new System.Drawing.Size(84, 32);
            this.btnreturn4.TabIndex = 42;
            this.btnreturn4.Text = "Return";
            this.btnreturn4.UseVisualStyleBackColor = false;
            this.btnreturn4.Click += new System.EventHandler(this.btnreturn4_Click_1);
            // 
            // btnreturn5
            // 
            this.btnreturn5.BackColor = System.Drawing.Color.Lime;
            this.btnreturn5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnreturn5.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreturn5.ForeColor = System.Drawing.Color.White;
            this.btnreturn5.Location = new System.Drawing.Point(1206, 515);
            this.btnreturn5.Name = "btnreturn5";
            this.btnreturn5.Size = new System.Drawing.Size(84, 32);
            this.btnreturn5.TabIndex = 43;
            this.btnreturn5.Text = "Return";
            this.btnreturn5.UseVisualStyleBackColor = false;
            this.btnreturn5.Click += new System.EventHandler(this.btnreturn5_Click_1);
            // 
            // ReturnBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cyan;
            this.ClientSize = new System.Drawing.Size(1436, 655);
            this.Controls.Add(this.btnreturn5);
            this.Controls.Add(this.btnreturn4);
            this.Controls.Add(this.btnreturn3);
            this.Controls.Add(this.btnreturn2);
            this.Controls.Add(this.btnreturn1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtreturnDate5);
            this.Controls.Add(this.txtreturnDate4);
            this.Controls.Add(this.txtreturnDate3);
            this.Controls.Add(this.txtreturnDate2);
            this.Controls.Add(this.txtreturnDate1);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.txtborrowedDate5);
            this.Controls.Add(this.txtborrowedDate4);
            this.Controls.Add(this.txtborrowedDate3);
            this.Controls.Add(this.txtborrowedDate2);
            this.Controls.Add(this.txtborrowedDate1);
            this.Controls.Add(this.txtborrowedB5);
            this.Controls.Add(this.txtborrowedB4);
            this.Controls.Add(this.txtborrowedB3);
            this.Controls.Add(this.txtborrowedB2);
            this.Controls.Add(this.txtborrowedB1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNumberNIC);
            this.Controls.Add(this.txtNameUser);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReturnBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReturnBook";
            this.Load += new System.EventHandler(this.ReturnBook_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label HeaderinReturnBook;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.TextBox txtEnterUNumber;
        private System.Windows.Forms.TextBox txtBorrowedBooks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.TextBox txtNameUser;
        private System.Windows.Forms.TextBox txtNumberNIC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtborrowedB1;
        private System.Windows.Forms.TextBox txtborrowedB2;
        private System.Windows.Forms.TextBox txtborrowedB3;
        private System.Windows.Forms.TextBox txtborrowedB4;
        private System.Windows.Forms.TextBox txtborrowedB5;
        private System.Windows.Forms.TextBox txtborrowedDate5;
        private System.Windows.Forms.TextBox txtborrowedDate4;
        private System.Windows.Forms.TextBox txtborrowedDate3;
        private System.Windows.Forms.TextBox txtborrowedDate2;
        private System.Windows.Forms.TextBox txtborrowedDate1;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.TextBox txtreturnDate5;
        private System.Windows.Forms.TextBox txtreturnDate4;
        private System.Windows.Forms.TextBox txtreturnDate3;
        private System.Windows.Forms.TextBox txtreturnDate2;
        private System.Windows.Forms.TextBox txtreturnDate1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnreturn1;
        private System.Windows.Forms.Button btnreturn2;
        private System.Windows.Forms.Button btnreturn3;
        private System.Windows.Forms.Button btnreturn4;
        private System.Windows.Forms.Button btnreturn5;
        private System.Windows.Forms.Label label2;
    }
}