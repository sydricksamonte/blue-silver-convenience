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
    public partial class EmployeeList : Form
    {
        string a;
        public EmployeeList(string type)
        {
            InitializeComponent();
            a = type;
        }
        string line, line2;
        MySqlDataReader dbReader;
        MySqlConnection dbConn;
        string dbP;
        string dbU;
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

        private void glassButton3_Click(object sender, EventArgs e)
        {

        }

        private void glassButton1_Click(object sender, EventArgs e)
        {

        }

        private void glassButton2_Click(object sender, EventArgs e)
        {
            Employee em = new Employee();
            em.Show();
        }

        private void EmployeeList_Load(object sender, EventArgs e)
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
                if (a == "Skilled")
                {
                    query = "Select * from employee WHERE emp_type = '" +"Skilled" + "' ORDER BY emp_name";
                }
                else if (a == "Helper")
                {
                    query = "Select * from employee WHERE emp_type = '" + "Helper" + "' ORDER BY emp_name";
                }
                else
                {
                    query = "Select * from employee ORDER BY emp_name";
                }
                    dbFill(query);
                while (dbReader.Read())
                {

                    dataGridView1.Rows.Add(dbReader["emp_name"].ToString(), dbReader["emp_type"].ToString(), dbReader["emp_rate"].ToString(), dbReader["contactno"].ToString(), dbReader["addr"].ToString(), dbReader["emp_id"].ToString());
           

                }
                dbReader.Close();
                dbConn.Close();
            }
                    
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                EmployeeOverview fm = new EmployeeOverview(dataGridView1.CurrentRow.Cells[5].Value.ToString());
                fm.Show();
            }
            catch
            {
                MessageBox.Show("Please select a row.", "Employee Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}