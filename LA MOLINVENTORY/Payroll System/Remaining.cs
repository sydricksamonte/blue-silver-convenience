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
    public partial class Remaining : Form
    {
        public Remaining()
        {
            InitializeComponent();
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
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                UpdateGrid();
            }
            else
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
                    query = "Select * from itemlist  WHERE item_no LIKE '%" + textBox6.Text + "%' ORDER BY item_name";
                    dbFill(query);
                    while (dbReader.Read())
                    {

                        {
                            dataGridView1.Rows.Add(dbReader["item_no"].ToString(), dbReader["item_name"].ToString(), dbReader["categ"].ToString(), dbReader["quan"].ToString(), dbReader["srp"].ToString(), dbReader["oprice"].ToString());

                        }


                    }
                    dbReader.Close();
                    dbConn.Close();
                }
            }
        }
        private void UpdateGrid()
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
                query = "Select * from itemlist  WHERE item_name LIKE '%" + textBox6.Text + "%' ORDER BY item_name";
                dbFill(query);
                while (dbReader.Read())
                {
                   

                    {
                        dataGridView1.Rows.Add(dbReader["item_no"].ToString(), dbReader["item_name"].ToString(), dbReader["categ"].ToString(), dbReader["quan"].ToString(), dbReader["srp"].ToString(), dbReader["oprice"].ToString());

                    }


                }
                dbReader.Close();
                dbConn.Close();
            }

        } int timex = 0;
        private void Remaining_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            timer1.Enabled = true;
            timex = 0;
        }
        string allitems = "";
        string allitems2 = "";
        private void timer1_Tick(object sender, EventArgs e)
        {
            timex++;
            if (timex == 1)
            {


            }
            else
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
                    query = "Select * from itemlist  WHERE item_no LIKE '%" + textBox6.Text + "%' ORDER BY item_name";
                    dbFill(query);
                    while (dbReader.Read())
                    {
                        {
                            allitems2 = dbReader["quan"].ToString() + allitems2;
                        }
                    }
                    dbReader.Close();
                    dbConn.Close();
                    if (allitems != allitems2)
                    {
                        UpdateGrid();
                        allitems = allitems2;
                    }

                    allitems2 = "";
                    timex = 0;
                }

            }
        }
    }
}