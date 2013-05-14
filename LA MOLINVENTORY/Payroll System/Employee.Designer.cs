namespace Payroll_System
{
    partial class Employee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Employee));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.adCon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.adRate = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.adTyp = new System.Windows.Forms.ComboBox();
            this.adAdd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.glassButton2 = new Glass.GlassButton();
            this.adName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.edname = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.edconta = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.edrate = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.edtype = new System.Windows.Forms.ComboBox();
            this.edadd = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.glassButton1 = new Glass.GlassButton();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.glassButton3 = new Glass.GlassButton();
            this.label11 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(417, 262);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.adCon);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.adRate);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.adTyp);
            this.tabPage1.Controls.Add(this.adAdd);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.glassButton2);
            this.tabPage1.Controls.Add(this.adName);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(409, 232);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Add Employee";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(263, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 17);
            this.label5.TabIndex = 74;
            this.label5.Text = "Contact No.:";
            // 
            // adCon
            // 
            this.adCon.BackColor = System.Drawing.SystemColors.Control;
            this.adCon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adCon.Location = new System.Drawing.Point(266, 151);
            this.adCon.Name = "adCon";
            this.adCon.Size = new System.Drawing.Size(111, 22);
            this.adCon.TabIndex = 73;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 72;
            this.label4.Text = "Address:";
            // 
            // adRate
            // 
            this.adRate.BackColor = System.Drawing.SystemColors.Control;
            this.adRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adRate.Location = new System.Drawing.Point(198, 89);
            this.adRate.Mask = "000.00";
            this.adRate.Name = "adRate";
            this.adRate.Size = new System.Drawing.Size(53, 22);
            this.adRate.TabIndex = 71;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 17);
            this.label3.TabIndex = 70;
            this.label3.Text = "Starting Rate (PHP):";
            // 
            // adTyp
            // 
            this.adTyp.BackColor = System.Drawing.SystemColors.Control;
            this.adTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.adTyp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.adTyp.FormattingEnabled = true;
            this.adTyp.Items.AddRange(new object[] {
            "Skilled",
            "Helper"});
            this.adTyp.Location = new System.Drawing.Point(28, 86);
            this.adTyp.Name = "adTyp";
            this.adTyp.Size = new System.Drawing.Size(121, 25);
            this.adTyp.TabIndex = 69;
            // 
            // adAdd
            // 
            this.adAdd.BackColor = System.Drawing.SystemColors.Control;
            this.adAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adAdd.Location = new System.Drawing.Point(28, 151);
            this.adAdd.Name = "adAdd";
            this.adAdd.Size = new System.Drawing.Size(223, 22);
            this.adAdd.TabIndex = 68;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 67;
            this.label2.Text = "Employee Type:";
            // 
            // glassButton2
            // 
            this.glassButton2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.glassButton2.GlowColor = System.Drawing.Color.MintCream;
            this.glassButton2.Location = new System.Drawing.Point(137, 190);
            this.glassButton2.Name = "glassButton2";
            this.glassButton2.OuterBorderColor = System.Drawing.Color.Transparent;
            this.glassButton2.ShineColor = System.Drawing.SystemColors.Highlight;
            this.glassButton2.Size = new System.Drawing.Size(114, 24);
            this.glassButton2.TabIndex = 66;
            this.glassButton2.Text = "Add Employee";
            this.glassButton2.Click += new System.EventHandler(this.glassButton2_Click);
            // 
            // adName
            // 
            this.adName.BackColor = System.Drawing.SystemColors.Control;
            this.adName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adName.Location = new System.Drawing.Point(28, 41);
            this.adName.Name = "adName";
            this.adName.Size = new System.Drawing.Size(261, 22);
            this.adName.TabIndex = 65;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 63;
            this.label1.Text = "Employee Name:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage2.Controls.Add(this.comboBox2);
            this.tabPage2.Controls.Add(this.edname);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.comboBox3);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.edconta);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.edrate);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.edtype);
            this.tabPage2.Controls.Add(this.edadd);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.glassButton1);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(409, 232);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Update Employee";
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(29, 220);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(349, 25);
            this.comboBox2.TabIndex = 89;
            this.comboBox2.Visible = false;
            // 
            // edname
            // 
            this.edname.BackColor = System.Drawing.SystemColors.Control;
            this.edname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edname.Location = new System.Drawing.Point(137, 56);
            this.edname.Name = "edname";
            this.edname.Size = new System.Drawing.Size(246, 22);
            this.edname.TabIndex = 88;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(26, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 17);
            this.label12.TabIndex = 87;
            this.label12.Text = "Employee Name:";
            // 
            // comboBox3
            // 
            this.comboBox3.BackColor = System.Drawing.SystemColors.Control;
            this.comboBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(34, 25);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(349, 25);
            this.comboBox3.TabIndex = 86;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(269, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 17);
            this.label6.TabIndex = 85;
            this.label6.Text = "Contact No.:";
            // 
            // edconta
            // 
            this.edconta.BackColor = System.Drawing.SystemColors.Control;
            this.edconta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edconta.Location = new System.Drawing.Point(272, 164);
            this.edconta.Name = "edconta";
            this.edconta.Size = new System.Drawing.Size(111, 22);
            this.edconta.TabIndex = 84;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 17);
            this.label7.TabIndex = 83;
            this.label7.Text = "Address:";
            // 
            // edrate
            // 
            this.edrate.BackColor = System.Drawing.SystemColors.Control;
            this.edrate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edrate.Location = new System.Drawing.Point(204, 108);
            this.edrate.Mask = "000.00";
            this.edrate.Name = "edrate";
            this.edrate.Size = new System.Drawing.Size(53, 22);
            this.edrate.TabIndex = 82;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(201, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 17);
            this.label8.TabIndex = 81;
            this.label8.Text = "Rate (PHP):";
            // 
            // edtype
            // 
            this.edtype.BackColor = System.Drawing.SystemColors.Control;
            this.edtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.edtype.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.edtype.FormattingEnabled = true;
            this.edtype.Items.AddRange(new object[] {
            "Skilled",
            "Helper"});
            this.edtype.Location = new System.Drawing.Point(34, 105);
            this.edtype.Name = "edtype";
            this.edtype.Size = new System.Drawing.Size(121, 25);
            this.edtype.TabIndex = 80;
            // 
            // edadd
            // 
            this.edadd.BackColor = System.Drawing.SystemColors.Control;
            this.edadd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edadd.Location = new System.Drawing.Point(34, 164);
            this.edadd.Name = "edadd";
            this.edadd.Size = new System.Drawing.Size(223, 22);
            this.edadd.TabIndex = 79;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 17);
            this.label9.TabIndex = 78;
            this.label9.Text = "Employee Type:";
            // 
            // glassButton1
            // 
            this.glassButton1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.glassButton1.GlowColor = System.Drawing.Color.Honeydew;
            this.glassButton1.Location = new System.Drawing.Point(137, 190);
            this.glassButton1.Name = "glassButton1";
            this.glassButton1.OuterBorderColor = System.Drawing.Color.Transparent;
            this.glassButton1.ShineColor = System.Drawing.SystemColors.Highlight;
            this.glassButton1.Size = new System.Drawing.Size(114, 24);
            this.glassButton1.TabIndex = 77;
            this.glassButton1.Text = "Update Employee";
            this.glassButton1.Click += new System.EventHandler(this.glassButton1_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 17);
            this.label10.TabIndex = 75;
            this.label10.Text = "Employee Name:";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tabPage3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage3.Controls.Add(this.comboBox5);
            this.tabPage3.Controls.Add(this.comboBox4);
            this.tabPage3.Controls.Add(this.glassButton3);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(409, 232);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Delete Employee";
            // 
            // comboBox5
            // 
            this.comboBox5.BackColor = System.Drawing.SystemColors.Control;
            this.comboBox5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(30, 104);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(349, 25);
            this.comboBox5.TabIndex = 90;
            this.comboBox5.Visible = false;
            // 
            // comboBox4
            // 
            this.comboBox4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(34, 38);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(349, 25);
            this.comboBox4.TabIndex = 89;
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // glassButton3
            // 
            this.glassButton3.GlowColor = System.Drawing.Color.Crimson;
            this.glassButton3.Location = new System.Drawing.Point(137, 190);
            this.glassButton3.Name = "glassButton3";
            this.glassButton3.OuterBorderColor = System.Drawing.Color.Transparent;
            this.glassButton3.ShineColor = System.Drawing.Color.Transparent;
            this.glassButton3.Size = new System.Drawing.Size(114, 24);
            this.glassButton3.TabIndex = 88;
            this.glassButton3.Text = "Delete Employee";
            this.glassButton3.Click += new System.EventHandler(this.glassButton3_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(26, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 17);
            this.label11.TabIndex = 87;
            this.label11.Text = "Employee Name:";
            // 
            // Employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(417, 262);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Franklin Gothic Book", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Employee";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee";
            this.Load += new System.EventHandler(this.Employee_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.MaskedTextBox adRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox adTyp;
        private System.Windows.Forms.TextBox adAdd;
        private System.Windows.Forms.Label label2;
        private Glass.GlassButton glassButton2;
        private System.Windows.Forms.TextBox adName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox adCon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox edconta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox edrate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox edtype;
        private System.Windows.Forms.TextBox edadd;
        private System.Windows.Forms.Label label9;
        private Glass.GlassButton glassButton1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox4;
        private Glass.GlassButton glassButton3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox edname;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox5;

    }
}