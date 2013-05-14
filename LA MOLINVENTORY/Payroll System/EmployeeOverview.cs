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
    public partial class EmployeeOverview : Form
    {
        string a;
        public EmployeeOverview(string user)
        {
            InitializeComponent();
            a = user;
        } string line, line2;
        MySqlDataReader dbReader;
        MySqlConnection dbConn;
        string dbP;
        string dbU;
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

        private void EmployeeOverview_Load(object sender, EventArgs e)
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
                query = "Select * from employee WHERE emp_id = '" + a + "'";
                dbFill(query);
                while (dbReader.Read())
                {
                    edname.Text = (dbReader["emp_name"].ToString());
                    edrate.Text = (dbReader["emp_rate"].ToString());
                    edadd.Text = (dbReader["addr"].ToString());
                    edconta.Text = (dbReader["contactno"].ToString());
                    edtype.Text = (dbReader["emp_type"].ToString());
                   label2.Text = (dbReader["emp_id"].ToString());
                    

                }
                dbReader.Close();
                dbConn.Close();
            }
        }

        private void glassButton1_Click(object sender, EventArgs e)
        {
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
                    query = "Update employee Set emp_name = '" + edname.Text.Trim().ToUpper() + "', emp_rate = '" + edrate.Text + "', addr = '" + edadd.Text.Trim().ToUpper() + "', contactno = '" + edconta.Text.Trim().ToUpper() + "', emp_type = '" + edtype.Text.Trim().ToUpper() + "' Where emp_id = '" + label2.Text + "'";

                    dbQuery(query);
                 
                }

            }
        }

        private void glassButton3_Click(object sender, EventArgs e)
        {
            
        }

        private void glassButton3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}