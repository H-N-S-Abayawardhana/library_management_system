namespace library_system
{
    partial class BookStatusLabel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookStatusLabel));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchBar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNIC = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.ComboLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUserStatus = new System.Windows.Forms.TextBox();
            this.comboBSelect = new System.Windows.Forms.ComboBox();
            this.CopiesLabel = new System.Windows.Forms.Label();
            this.txtcopies = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.txtBstatus = new System.Windows.Forms.TextBox();
            this.txtIsReserved = new System.Windows.Forms.TextBox();
            this.ReservedLabel = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Blue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1437, 110);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(538, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 73);
            this.label1.TabIndex = 1;
            this.label1.Text = "INQUIRIES";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1390, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.txtSearchBar);
            this.panel2.Location = new System.Drawing.Point(0, 109);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(430, 653);
            this.panel2.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(89, 40);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(232, 212);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(37, 301);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Search By User Number";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(190, 379);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 40);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchBar
            // 
            this.txtSearchBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchBar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBar.Location = new System.Drawing.Point(89, 318);
            this.txtSearchBar.Name = "txtSearchBar";
            this.txtSearchBar.Size = new System.Drawing.Size(287, 32);
            this.txtSearchBar.TabIndex = 1;
            this.txtSearchBar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(436, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "NIC Number :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(436, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "Name of User :";
            // 
            // txtNIC
            // 
            this.txtNIC.BackColor = System.Drawing.Color.White;
            this.txtNIC.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtNIC.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNIC.Location = new System.Drawing.Point(622, 265);
            this.txtNIC.Name = "txtNIC";
            this.txtNIC.ReadOnly = true;
            this.txtNIC.Size = new System.Drawing.Size(249, 32);
            this.txtNIC.TabIndex = 7;
            this.txtNIC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.White;
            this.txtUserName.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtUserName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(622, 149);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(249, 32);
            this.txtUserName.TabIndex = 6;
            this.txtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ComboLabel
            // 
            this.ComboLabel.AutoSize = true;
            this.ComboLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.ComboLabel.Location = new System.Drawing.Point(1111, 117);
            this.ComboLabel.Name = "ComboLabel";
            this.ComboLabel.Size = new System.Drawing.Size(187, 24);
            this.ComboLabel.TabIndex = 10;
            this.ComboLabel.Text = "Select the Book Title ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label6.Location = new System.Drawing.Point(436, 395);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 24);
            this.label6.TabIndex = 13;
            this.label6.Text = "User Status :";
            // 
            // txtUserStatus
            // 
            this.txtUserStatus.BackColor = System.Drawing.Color.White;
            this.txtUserStatus.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtUserStatus.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserStatus.Location = new System.Drawing.Point(622, 387);
            this.txtUserStatus.Name = "txtUserStatus";
            this.txtUserStatus.ReadOnly = true;
            this.txtUserStatus.Size = new System.Drawing.Size(249, 32);
            this.txtUserStatus.TabIndex = 12;
            this.txtUserStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // comboBSelect
            // 
            this.comboBSelect.BackColor = System.Drawing.Color.White;
            this.comboBSelect.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBSelect.FormattingEnabled = true;
            this.comboBSelect.Location = new System.Drawing.Point(1074, 149);
            this.comboBSelect.Name = "comboBSelect";
            this.comboBSelect.Size = new System.Drawing.Size(285, 32);
            this.comboBSelect.TabIndex = 14;
            this.comboBSelect.SelectedIndexChanged += new System.EventHandler(this.comboBSelect_SelectedIndexChanged);
            // 
            // CopiesLabel
            // 
            this.CopiesLabel.AutoSize = true;
            this.CopiesLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CopiesLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.CopiesLabel.Location = new System.Drawing.Point(1129, 214);
            this.CopiesLabel.Name = "CopiesLabel";
            this.CopiesLabel.Size = new System.Drawing.Size(148, 24);
            this.CopiesLabel.TabIndex = 15;
            this.CopiesLabel.Text = "Available Copies";
            // 
            // txtcopies
            // 
            this.txtcopies.BackColor = System.Drawing.Color.White;
            this.txtcopies.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtcopies.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcopies.Location = new System.Drawing.Point(1074, 245);
            this.txtcopies.Name = "txtcopies";
            this.txtcopies.ReadOnly = true;
            this.txtcopies.Size = new System.Drawing.Size(285, 32);
            this.txtcopies.TabIndex = 16;
            this.txtcopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.statusLabel.Location = new System.Drawing.Point(1154, 314);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(115, 24);
            this.statusLabel.TabIndex = 17;
            this.statusLabel.Text = "Book Status ";
            // 
            // txtBstatus
            // 
            this.txtBstatus.BackColor = System.Drawing.Color.White;
            this.txtBstatus.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtBstatus.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBstatus.Location = new System.Drawing.Point(1074, 350);
            this.txtBstatus.Name = "txtBstatus";
            this.txtBstatus.Size = new System.Drawing.Size(290, 32);
            this.txtBstatus.TabIndex = 18;
            this.txtBstatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIsReserved
            // 
            this.txtIsReserved.BackColor = System.Drawing.Color.White;
            this.txtIsReserved.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtIsReserved.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIsReserved.Location = new System.Drawing.Point(1074, 462);
            this.txtIsReserved.Name = "txtIsReserved";
            this.txtIsReserved.Size = new System.Drawing.Size(290, 32);
            this.txtIsReserved.TabIndex = 19;
            this.txtIsReserved.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ReservedLabel
            // 
            this.ReservedLabel.AutoSize = true;
            this.ReservedLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReservedLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.ReservedLabel.Location = new System.Drawing.Point(1154, 427);
            this.ReservedLabel.Name = "ReservedLabel";
            this.ReservedLabel.Size = new System.Drawing.Size(100, 24);
            this.ReservedLabel.TabIndex = 20;
            this.ReservedLabel.Text = "Reserved ?";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(894, 534);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(139, 40);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // BookStatusLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cyan;
            this.ClientSize = new System.Drawing.Size(1435, 634);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.ReservedLabel);
            this.Controls.Add(this.txtIsReserved);
            this.Controls.Add(this.txtBstatus);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.txtcopies);
            this.Controls.Add(this.CopiesLabel);
            this.Controls.Add(this.comboBSelect);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtUserStatus);
            this.Controls.Add(this.ComboLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNIC);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BookStatusLabel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InquiryProcess";
            this.Load += new System.EventHandler(this.InquiryProcess_Load);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNIC;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label ComboLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUserStatus;
        private System.Windows.Forms.ComboBox comboBSelect;
        private System.Windows.Forms.Label CopiesLabel;
        private System.Windows.Forms.TextBox txtcopies;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.TextBox txtBstatus;
        private System.Windows.Forms.TextBox txtIsReserved;
        private System.Windows.Forms.Label ReservedLabel;
        private System.Windows.Forms.Button btnCancel;
    }
}