namespace Weighment
{
    partial class Form1
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
            this.label6 = new System.Windows.Forms.Label();
            this.txtvehno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbport = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtweight = new System.Windows.Forms.TextBox();
            this.btnconnect = new System.Windows.Forms.Button();
            this.btnsubmit = new System.Windows.Forms.Button();
            this.lblstat = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtpwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtuname = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblurl = new System.Windows.Forms.Label();
            this.lbltenantId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(578, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 23);
            this.label6.TabIndex = 40;
            this.label6.Text = "PORT NAME";
            // 
            // txtvehno
            // 
            this.txtvehno.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtvehno.Location = new System.Drawing.Point(198, 210);
            this.txtvehno.Name = "txtvehno";
            this.txtvehno.Size = new System.Drawing.Size(177, 32);
            this.txtvehno.TabIndex = 3;
            this.txtvehno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtvehno_KeyDown);
            this.txtvehno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtvehno_KeyPress);
            this.txtvehno.Leave += new System.EventHandler(this.txtvehno_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 23);
            this.label1.TabIndex = 38;
            this.label1.Text = "VEHICLE NO";
            // 
            // cmbport
            // 
            this.cmbport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbport.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbport.FormattingEnabled = true;
            this.cmbport.Location = new System.Drawing.Point(711, 153);
            this.cmbport.Name = "cmbport";
            this.cmbport.Size = new System.Drawing.Size(133, 31);
            this.cmbport.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(414, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 31);
            this.label2.TabIndex = 41;
            this.label2.Text = "WEIGH  BRIDGE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(563, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 23);
            this.label3.TabIndex = 42;
            this.label3.Text = "WEIGHT (Kgs)";
            // 
            // txtweight
            // 
            this.txtweight.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtweight.Location = new System.Drawing.Point(711, 207);
            this.txtweight.Name = "txtweight";
            this.txtweight.Size = new System.Drawing.Size(177, 32);
            this.txtweight.TabIndex = 5;
            // 
            // btnconnect
            // 
            this.btnconnect.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnconnect.Location = new System.Drawing.Point(387, 261);
            this.btnconnect.Name = "btnconnect";
            this.btnconnect.Size = new System.Drawing.Size(89, 30);
            this.btnconnect.TabIndex = 4;
            this.btnconnect.Text = "READ";
            this.btnconnect.UseVisualStyleBackColor = true;
            this.btnconnect.Click += new System.EventHandler(this.btnconnect_Click);
            // 
            // btnsubmit
            // 
            this.btnsubmit.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsubmit.Location = new System.Drawing.Point(521, 261);
            this.btnsubmit.Name = "btnsubmit";
            this.btnsubmit.Size = new System.Drawing.Size(100, 30);
            this.btnsubmit.TabIndex = 6;
            this.btnsubmit.Text = "SUBMIT";
            this.btnsubmit.UseVisualStyleBackColor = true;
            this.btnsubmit.Click += new System.EventHandler(this.btnsubmit_Click);
            // 
            // lblstat
            // 
            this.lblstat.AutoSize = true;
            this.lblstat.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstat.Location = new System.Drawing.Point(778, 48);
            this.lblstat.Name = "lblstat";
            this.lblstat.Size = new System.Drawing.Size(78, 21);
            this.lblstat.TabIndex = 46;
            this.lblstat.Text = "STATUS";
            this.lblstat.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(42, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 23);
            this.label5.TabIndex = 48;
            this.label5.Text = "TENANT ID";
            this.label5.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(141, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 23);
            this.label7.TabIndex = 54;
            this.label7.Text = "URL";
            // 
            // txtpwd
            // 
            this.txtpwd.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpwd.Location = new System.Drawing.Point(198, 150);
            this.txtpwd.Name = "txtpwd";
            this.txtpwd.PasswordChar = '*';
            this.txtpwd.Size = new System.Drawing.Size(177, 32);
            this.txtpwd.TabIndex = 1;
            this.txtpwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpwd_KeyDown);
            this.txtpwd.Leave += new System.EventHandler(this.txtpwd_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(73, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 23);
            this.label4.TabIndex = 52;
            this.label4.Text = "PASSWORD";
            // 
            // txtuname
            // 
            this.txtuname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtuname.Location = new System.Drawing.Point(711, 93);
            this.txtuname.Name = "txtuname";
            this.txtuname.Size = new System.Drawing.Size(177, 31);
            this.txtuname.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(577, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 23);
            this.label8.TabIndex = 51;
            this.label8.Text = "USER NAME";
            // 
            // lblurl
            // 
            this.lblurl.AutoSize = true;
            this.lblurl.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblurl.Location = new System.Drawing.Point(193, 95);
            this.lblurl.Name = "lblurl";
            this.lblurl.Size = new System.Drawing.Size(242, 27);
            this.lblurl.TabIndex = 55;
            this.lblurl.Text = "idms-erd.aavin.tn.gov.in";
            // 
            // lbltenantId
            // 
            this.lbltenantId.AutoSize = true;
            this.lbltenantId.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltenantId.Location = new System.Drawing.Point(155, 13);
            this.lbltenantId.Name = "lbltenantId";
            this.lbltenantId.Size = new System.Drawing.Size(87, 23);
            this.lbltenantId.TabIndex = 56;
            this.lbltenantId.Text = "aavin-erd";
            this.lbltenantId.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(1012, 344);
            this.Controls.Add(this.lbltenantId);
            this.Controls.Add(this.lblurl);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtpwd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtuname);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblstat);
            this.Controls.Add(this.btnsubmit);
            this.Controls.Add(this.btnconnect);
            this.Controls.Add(this.txtweight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtvehno);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WEIGH  BRIDGE";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtvehno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtweight;
        private System.Windows.Forms.Button btnconnect;
        private System.Windows.Forms.Button btnsubmit;
        private System.Windows.Forms.Label lblstat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtpwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtuname;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblurl;
        private System.Windows.Forms.Label lbltenantId;
    }
}

