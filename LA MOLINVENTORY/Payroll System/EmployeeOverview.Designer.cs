namespace Payroll_System
{
    partial class EmployeeOverview
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
            this.edname = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.edconta = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.edrate = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.edtype = new System.Windows.Forms.ComboBox();
            this.edadd = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.glassButton3 = new Glass.GlassButton();
            this.glassButton1 = new Glass.GlassButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // edname
            // 
            this.edname.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.edname.Location = new System.Drawing.Point(144, 53);
            this.edname.Name = "edname";
            this.edname.Size = new System.Drawing.Size(246, 22);
            this.edname.TabIndex = 100;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(36, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 17);
            this.label12.TabIndex = 99;
            this.label12.Text = "Employee Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(269, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 17);
            this.label6.TabIndex = 98;
            this.label6.Text = "Contact No.:";
            // 
            // edconta
            // 
            this.edconta.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.edconta.Location = new System.Drawing.Point(272, 101);
            this.edconta.Name = "edconta";
            this.edconta.Size = new System.Drawing.Size(118, 22);
            this.edconta.TabIndex = 97;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 17);
            this.label7.TabIndex = 96;
            this.label7.Text = "Address:";
            // 
            // edrate
            // 
            this.edrate.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.edrate.Location = new System.Drawing.Point(181, 101);
            this.edrate.Mask = "000.00";
            this.edrate.Name = "edrate";
            this.edrate.Size = new System.Drawing.Size(53, 22);
            this.edrate.TabIndex = 95;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(178, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 17);
            this.label8.TabIndex = 94;
            this.label8.Text = "Rate (PHP):";
            // 
            // edtype
            // 
            this.edtype.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.edtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.edtype.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.edtype.ForeColor = System.Drawing.SystemColors.InfoText;
            this.edtype.FormattingEnabled = true;
            this.edtype.Items.AddRange(new object[] {
            "Skilled",
            "Helper"});
            this.edtype.Location = new System.Drawing.Point(39, 98);
            this.edtype.Name = "edtype";
            this.edtype.Size = new System.Drawing.Size(121, 25);
            this.edtype.TabIndex = 93;
            // 
            // edadd
            // 
            this.edadd.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.edadd.Location = new System.Drawing.Point(39, 146);
            this.edadd.Name = "edadd";
            this.edadd.Size = new System.Drawing.Size(351, 22);
            this.edadd.TabIndex = 92;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 17);
            this.label9.TabIndex = 91;
            this.label9.Text = "Employee Type:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 101;
            this.label1.Text = "Employee No:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 17);
            this.label2.TabIndex = 102;
            this.label2.Text = "E0000000000";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.glassButton3);
            this.panel1.Controls.Add(this.glassButton1);
            this.panel1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.panel1.Location = new System.Drawing.Point(-14, 186);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 56);
            this.panel1.TabIndex = 104;
            // 
            // glassButton3
            // 
            this.glassButton3.BackColor = System.Drawing.Color.Red;
            this.glassButton3.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glassButton3.GlowColor = System.Drawing.Color.OrangeRed;
            this.glassButton3.Location = new System.Drawing.Point(127, 3);
            this.glassButton3.Name = "glassButton3";
            this.glassButton3.OuterBorderColor = System.Drawing.Color.Transparent;
            this.glassButton3.ShineColor = System.Drawing.Color.DarkRed;
            this.glassButton3.Size = new System.Drawing.Size(61, 23);
            this.glassButton3.TabIndex = 105;
            this.glassButton3.Text = "Close";
            this.glassButton3.Click += new System.EventHandler(this.glassButton3_Click_1);
            // 
            // glassButton1
            // 
            this.glassButton1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.glassButton1.GlowColor = System.Drawing.Color.Honeydew;
            this.glassButton1.Location = new System.Drawing.Point(194, 3);
            this.glassButton1.Name = "glassButton1";
            this.glassButton1.OuterBorderColor = System.Drawing.Color.Transparent;
            this.glassButton1.ShineColor = System.Drawing.SystemColors.Highlight;
            this.glassButton1.Size = new System.Drawing.Size(117, 23);
            this.glassButton1.TabIndex = 104;
            this.glassButton1.Text = "Update Employee";
            this.glassButton1.Click += new System.EventHandler(this.glassButton1_Click);
            // 
            // EmployeeOverview
            // 
            this.ClientSize = new System.Drawing.Size(427, 224);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edname);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.edconta);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.edrate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.edtype);
            this.Controls.Add(this.edadd);
            this.Controls.Add(this.label9);
            this.Font = new System.Drawing.Font("Franklin Gothic Book", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EmployeeOverview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee";
            this.Load += new System.EventHandler(this.EmployeeOverview_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox edname;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox edconta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox edrate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox edtype;
        private System.Windows.Forms.TextBox edadd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private Glass.GlassButton glassButton3;
        private Glass.GlassButton glassButton1;
    }
}