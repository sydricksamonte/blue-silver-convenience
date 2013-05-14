using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using MySql.Data.MySqlClient;

namespace Payroll_System
{
    public partial class Suppliers : Form
    {
        string userss = "";
        public Suppliers(string a)
        {
            InitializeComponent();
            userss = a;
        }
        string line, line2;
        MySqlDataReader dbReader;
        MySqlConnection dbConn;
        string dbP;
        string dbU;
        string types;
        public void dbQuery(string statement)
        {

            string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";


            dbConn = new MySqlConnection(sConnection);
            MySqlCommand dbCmd = new MySqlCommand();
            dbConn.Open();
            string sql = statement;
            dbCmd.CommandText = sql;
            dbCmd.Connection = dbConn;
            dbCmd.ExecuteNonQuery();
            dbConn.Close();
        }
        public void dbFill(string statement)
        {

            string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";

            dbConn = new MySqlConnection(sConnection);


            MySqlCommand dbCmd = new MySqlCommand();
            dbConn.Open();

            string sql = statement;

            dbCmd.CommandText = sql;
            dbCmd.CommandTimeout = 45;
            dbCmd.Connection = dbConn;
            dbCmd.ExecuteNonQuery();
            dbReader = dbCmd.ExecuteReader();

        }
        private string idcomponent()
        {
            string ax = System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();
            return ax;
        }
        public void AddNow()
        {
            if ((textBox1.Text == "") || (textBox3.Text == ""))
            {
                MessageBox.Show("Information is not complete");
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to add this category?", "Inventory System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string query33;


                    StreamReader sr33 = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                    line = sr33.ReadLine();
                    StreamReader sr34 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                    dbP = sr34.ReadLine();
                    StreamReader sr35 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                    dbU = sr35.ReadLine();
                    string sConnection33 = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                    MySqlConnection sqlConnection33 = new MySqlConnection(sConnection33);

                    {
                        query33 = "Insert Into suppliers Values('" + textBox1.Text.ToUpper() + "','" + textBox3.Text.ToUpper().Trim() + "','" + textBox2.Text.ToUpper().Trim() + "','" + "SUPP" + idcomponent() + "')";
                    }

                    dbQuery(query33);

                    MessageBox.Show("Supplier was successfuly added to the system");
                    Suppliers it = new Suppliers(userss);
                    it.Show();
                    this.Hide();


                }
            }
        }
        private void glassButton1_Click(object sender, EventArgs e)
        {
            AddNow();
         
        }
        private void disGrid()
        {
            dataGridView1.Rows.Clear();
            {
                string query;

                StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                line = sr.ReadLine();
                StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                dbP = sr3.ReadLine();
                StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                dbU = sr4.ReadLine();
                string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                query = "Select * from suppliers ORDER BY supplier";
                dbFill(query);
                while (dbReader.Read())
                {

                    dataGridView1.Rows.Add(dbReader["supplier"].ToString(), dbReader["con"].ToString(), dbReader["addresss"].ToString(), dbReader["supp_id"].ToString());


                }
                dbReader.Close();
                dbConn.Close();
            }
        }
        private void Suppliers_Load(object sender, EventArgs e)
        {
            disGrid();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {

                textBox3.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {

                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {

                AddNow();
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            bool notallowed = false;
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Are you sure you want to delete this supplier?", "Inventory System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    {
                        string query;

                        StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                        line = sr.ReadLine();
                        StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                        dbP = sr3.ReadLine();
                        StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                        dbU = sr4.ReadLine();
                        string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                        MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                        query = "Select * from itemlist WHERE  supp = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                        dbFill(query);
                        while (dbReader.Read())
                        {

                            notallowed = true;

                        }
                        dbReader.Close();
                        dbConn.Close();
                    }
                    if (notallowed == false)
                    {
                        string query33;


                        StreamReader sr33 = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                        line = sr33.ReadLine();
                        StreamReader sr34 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                        dbP = sr34.ReadLine();
                        StreamReader sr35 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                        dbU = sr35.ReadLine();
                        string sConnection33 = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                        MySqlConnection sqlConnection33 = new MySqlConnection(sConnection33);

                        {
                            query33 = "DELETE FROM suppliers Where supp_id = '" + dataGridView1.CurrentRow.Cells[3].Value.ToString() + "'";

                        }

                        dbQuery(query33);

                        MessageBox.Show("Supplier was successfuly removed.");
                        disGrid();
                    }
                    else
                    {
                        MessageBox.Show("There are items who uses this supplier. \nThe supplier cannot be deleted.");

                    }
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Items it = new Items(userss,"",dataGridView1.CurrentRow.Cells[0].Value.ToString());
            it.Show();
            this.Hide();
        }

        private void glassButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Items it = new Items(userss, "", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                it.Show();
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Please select a supplier below");
            }
        }

        private void glassButton3_Click(object sender, EventArgs e)
        {
            {
               
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label2.Text = "Edit Supplier";
                glassButton1.Visible = false;
                glassButton3.Visible = true;
               // glassButton2.Text = "Add Supplier";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label2.Text = "Add Supplier";
                glassButton1.Visible = true;
                glassButton3.Visible = false;
                // glassButton2.Text = "Add Supplier";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }
        string idd = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                innames = "";
                {

                    string query;


                    StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                    line = sr.ReadLine();
                    StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                    dbP = sr3.ReadLine();
                    StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                    dbU = sr4.ReadLine();
                    string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                    MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                    query = "Select * from itemlist WHERE supp = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                    dbFill(query);
                    while (dbReader.Read())
                    {



                        innames = dbReader["item_no"].ToString() + "','" + innames;

                    }
                    dbReader.Close();
                    dbConn.Close();

                    //MessageBox.Show(innames);
                }
            }
            catch { }
            if (radioButton1.Checked == true)
            {
                {
                    string query;

                    StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                    line = sr.ReadLine();
                    StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                    dbP = sr3.ReadLine();
                    StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                    dbU = sr4.ReadLine();
                    string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                    MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                    query = "Select * from suppliers  WHERE supp_id ='" + dataGridView1.CurrentRow.Cells[3].Value.ToString() + "'";
                    dbFill(query);
                    while (dbReader.Read())
                    {

                        textBox1.Text = dbReader["supplier"].ToString();
                        textBox3.Text = dbReader["con"].ToString();
                        textBox2.Text = dbReader["addresss"].ToString();
                         idd = dbReader["supp_id"].ToString();


                    }
                    dbReader.Close();
                    dbConn.Close();
                }
            }
            
        }
        string innames = "";
        private void glassButton3_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to edit this supplier?", "Supplier", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                {
                    string query33;


                    StreamReader sr33 = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                    line = sr33.ReadLine();
                    StreamReader sr34 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                    dbP = sr34.ReadLine();
                    StreamReader sr35 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                    dbU = sr35.ReadLine();
                    string sConnection33 = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                    MySqlConnection sqlConnection33 = new MySqlConnection(sConnection33);

                    {
                        query33 = "UPDATE itemlist SET supp  = '" + textBox1.Text + "' Where item_no IN ('" + innames + "')";

                    }

                    dbQuery(query33);


                }
                {
                    string query33;


                    StreamReader sr33 = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                    line = sr33.ReadLine();
                    StreamReader sr34 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                    dbP = sr34.ReadLine();
                    StreamReader sr35 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                    dbU = sr35.ReadLine();
                    string sConnection33 = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                    MySqlConnection sqlConnection33 = new MySqlConnection(sConnection33);

                    {
                        query33 = "UPDATE suppliers SET supplier  = '" + textBox1.Text + "', con = '" + textBox3.Text + "',addresss='" + textBox2.Text + "' Where supp_id  = '" + idd + "'";

                    }

                    dbQuery(query33);
                    MessageBox.Show("Supplier information has been updated.");
                    disGrid();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
            }
        }
    }
}