using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace Payroll_System
{
    public partial class Stocks : Form
    {
        string user = "";
        string itemss = "";
        public Stocks(string a,string b)
        {
            InitializeComponent();
            user = a;
            itemss = b;
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
        int tira = 0;
        private void Stocks_Load(object sender, EventArgs e)
        {
            tira = 0;
            textBox1.Focus();
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
                query = "Select * from itemlist ORDER BY item_name ASC";
                dbFill(query);
                while (dbReader.Read())
                {
                    comboBox1.Items.Add ( dbReader["item_name"].ToString());
                  



                }
                dbReader.Close();
                dbConn.Close();
            }
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
                query = "Select * from itemlist WHERE item_no= '" + itemss + "' ";
                dbFill(query);
                while (dbReader.Read())
                {
                   comboBox1.Text = dbReader["item_name"].ToString();
                    label4.Text = dbReader["quan"].ToString();
                    tira = int.Parse(dbReader["quan"].ToString());
                   



                }
                dbReader.Close();
                dbConn.Close();
            }
        }

        private void glassButton1_Click(object sender, EventArgs e)
        {
            Items fm = new Items(user, itemss,"");
            fm.Show();
        }
        public void AddNow()
        {
            if ((textBox1.Text == "0") )
            {
                //MessageBox.Show("Pke");
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to update the stocks of this item?", "Inventory System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string query33;

                        tira = int.Parse(textBox1.Text) + tira;
                        StreamReader sr33 = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                        line = sr33.ReadLine();
                        StreamReader sr34 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                        dbP = sr34.ReadLine();
                        StreamReader sr35 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                        dbU = sr35.ReadLine();
                        string sConnection33 = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                        MySqlConnection sqlConnection33 = new MySqlConnection(sConnection33);

                        {
                            query33 = " Update itemlist Set quan = '" + tira + "' Where  item_name  = '" + comboBox1.Text + "'";
                        }

                        dbQuery(query33);

                        MessageBox.Show("Stocks was successfuly upadated, it now contains (" +tira+") items");

                        this.Hide();
                    }
                    catch
                    {
                        MessageBox.Show("Invalid input");
                    }


                }
            }
        }
        private void glassButton2_Click(object sender, EventArgs e)
        {
            AddNow();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddNow();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            try
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
                    query = "Select * from itemlist WHERE item_name= '" + comboBox1.Text + "'";
                    dbFill(query);
                    while (dbReader.Read())
                    {

                        label4.Text = dbReader["quan"].ToString();
                        tira = int.Parse(dbReader["quan"].ToString());
                    }
                    dbReader.Close();
                    dbConn.Close();
                }
            }
            catch { }
        }
    }
}