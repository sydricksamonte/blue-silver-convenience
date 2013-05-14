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
    public partial class Warning : Form
    {
        public Warning()
        {
            InitializeComponent();
        }
        string line, line2;
        MySqlDataReader dbReader;
        MySqlConnection dbConn;
        string dbP;
        string dbU;
        string name = "";
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
        private void Warning_Load(object sender, EventArgs e)
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
                query = "Select * from itemlist WHERE quan < origprice ORDER BY categ ASC,srp ASC";
                dbFill(query);
                while (dbReader.Read())
                {
                    dataGridView1.Rows.Add(dbReader["categ"].ToString(), dbReader["item_name"].ToString(), dbReader["supp"].ToString(), dbReader["origprice"].ToString(), dbReader["quan"].ToString(), dbReader["srp"].ToString(), dbReader["item_no"].ToString());
                   
                    //{
                    //    string query2;


                    //    StreamReader sr2 = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                    //    line = sr2.ReadLine();
                    //    StreamReader sr32 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                    //    dbP = sr32.ReadLine();
                    //    StreamReader sr42 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                    //    dbU = sr42.ReadLine();
                    //    string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                    //    MySqlConnection sqlConnection2 = new MySqlConnection(sConnection2);
                    //    query2 = "Select * from itemlist WHERE quan < '" + 20 + "' ORDER BY quan ASC";
                    //    dbFill(query2);
                    //    while (dbReader2.Read())
                    //    {
                    //        dataGridView1.Rows.Add(dbReader["categ"].ToString(), dbReader["item_name"].ToString(), dbReader["srp"].ToString(), dbReader["supp"].ToString(), dbReader["quan"].ToString(), dbReader["item_no"].ToString());
                    //        crit++;
                    //        label9.Text = "You need to refill " + crit + " items!";



                    //    }
                    //    dbReader2.Close();
                    //    dbConn2.Close();
                    //}



                }
                dbReader.Close();
                dbConn.Close();
            }
        }
    }
}