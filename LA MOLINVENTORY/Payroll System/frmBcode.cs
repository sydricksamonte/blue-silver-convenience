using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Payroll_System
{
    public partial class FrmBcode : Form
    {
        public FrmBcode()
        {
            InitializeComponent();
        }

        private void DisplayBarcode()
        {
            pictureBox1.Image = GenerateBarcode("*" + txtBCode.Text.ToUpper() + "*", txtItemName.Text);
            pictureBox1.Size = new Size(pictureBox1.Image.Width, pictureBox1.Image.Height);
            pictureBox1.Location = new Point((this.Width - pictureBox1.Width) / 2, 74);
            pictureBox1.Visible = true;
        }

        private Bitmap GenerateBarcode(string bCode, string item)
        {
            string malayan = "Malayan Colleges Laguna";
            Bitmap barCode = new Bitmap(1,1);
            System.Drawing.Font code39 = new Font("3 of 9 Barcode", 35, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Graphics grp = Graphics.FromImage(barCode);
            SizeF dataSize = grp.MeasureString(bCode, code39);
            SizeF strSize = grp.MeasureString(bCode, new Font("Arial", 10));
            SizeF strMalayan = grp.MeasureString(malayan, new Font("Arial", 10));
            SizeF strItem = grp.MeasureString(item, new Font("Arial", 10));
            dataSize.Height += (strSize.Height + strMalayan.Height + strItem.Height);
            if (strMalayan.Width > dataSize.Width)
            {
                dataSize.Width = strMalayan.Width;
            }
            if (strItem.Width > dataSize.Width)
            {
                dataSize.Width = strItem.Width;
            }
            barCode = new Bitmap(barCode, dataSize.ToSize());
            grp = Graphics.FromImage(barCode);
            grp.Clear(Color.White);
            grp.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            grp.DrawString(malayan, new Font("Arial", 8), new SolidBrush(Color.Black), 0, 0);
            grp.DrawString(item, new Font("Arial", 8), new SolidBrush(Color.Black), 0, strMalayan.Height);
            grp.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
            grp.DrawString(bCode, code39, new SolidBrush(Color.Black), 0, strItem.Height + strMalayan.Height);
            StringBuilder sb = new StringBuilder();
            foreach (char c in bCode)
            {
                if (c == '*')
                {
                   bCode = bCode.Remove(bCode.IndexOf(c), 1);
                }
            }
            grp.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            grp.DrawString(bCode, new Font("Arial", 8), new SolidBrush(Color.Black), ((int)dataSize.Width-(int)strSize.Width)/2, (dataSize.Height - strSize.Height) - 5);
            grp.Flush();
            code39.Dispose();
            grp.Dispose();
            return barCode;
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            DisplayBarcode();
        }

        private void txtBCode_TextChanged(object sender, EventArgs e)
        {
            DisplayBarcode();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if (txtItemName.Text != "" && txtBCode.Text != "")
        //    {
        //        SaveFileDialog sv = new SaveFileDialog();
        //        sv.Title = "Upload Operator Logo";
        //        sv.Filter = "JPEG|*.jpg";
        //        sv.ShowDialog();
        //        if (sv.FileName != "")
        //        {
        //            FileStream fs = (FileStream)sv.OpenFile();
        //            pictureBox1.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
        //            fs.Close();
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Item name and Barcode is required.");
        //    }
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        private void FrmBcode_Load(object sender, EventArgs e)
        {

        }

        private void glassButton1_Click(object sender, EventArgs e)
        {
            if (txtItemName.Text != "" && txtBCode.Text != "")
            {
                SaveFileDialog sv = new SaveFileDialog();
                sv.Title = "Upload Operator Logo";
                sv.Filter = "JPEG|*.jpg";
                sv.ShowDialog();
                if (sv.FileName != "")
                {
                    FileStream fs = (FileStream)sv.OpenFile();
                    pictureBox1.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                    fs.Close();
                }
            }
            else
            {
                MessageBox.Show("Item name and Barcode is required.");
            }
        }

        private void glassButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}