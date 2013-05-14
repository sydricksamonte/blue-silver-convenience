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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        string line, line2;
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
        private void glassButton2_Click(object sender, EventArgs e)
        {
            if (adName.Text.Length < 7)
            {
                MessageBox.Show("Please enter an employee name.", "Employee Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (adRate.Text=="   .")
            {
                MessageBox.Show("Please enter employee rate.", "Employee Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (adTyp.Text=="")
            {
                MessageBox.Show("Please enter employee type.", "Employee Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else

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
                query = "Insert Into employee Values('" + System.DateTime.Now.Year + System.DateTime.Now.Month + System.DateTime.Now.Day + System.DateTime.Now.Millisecond + "','" + adName.Text.Trim().ToUpper() + "','" + adRate.Text + "','" + adAdd.Text.Trim().ToUpper() + "','" + adCon.Text.Trim().ToUpper() + "','" + adTyp.Text.Trim().ToUpper() + "' ,'" + System.DateTime.Now.ToString() + "','" + System.DateTime.Now.ToString() + "')";

                dbQuery(query);
                MessageBox.Show("Successfully added an employee", "Employee Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Employee fm = new Employee();
                fm.Show();
                this.Close();
            }
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            string username;
            string password = "";
            string types = "";
            string name = "";
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
                query = "Select * from employee ORDER BY emp_name ASC ";
                dbFill(query);
                while (dbReader.Read())
                {
                    comboBox3.Items.Add(dbReader["emp_name"].ToString());
                    comboBox4.Items.Add(dbReader["emp_name"].ToString());
                    comboBox2.Items.Add(dbReader["emp_id"].ToString());
                    comboBox5.Items.Add(dbReader["emp_id"].ToString());


                }
                dbReader.Close();
                dbConn.Close();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = comboBox3.SelectedIndex;
            comboBox3.SelectedIndex = comboBox2.SelectedIndex;
            string username;
            string password = "";
            string types = "";
            string name = "";
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
                query = "Select * from employee WHERE emp_id = '"+comboBox2.Text+"'";
                dbFill(query);
                while (dbReader.Read())
                {
                    edname.Text = (dbReader["emp_name"].ToString());
                    edrate.Text = (dbReader["emp_rate"].ToString());
                    edadd.Text = (dbReader["addr"].ToString());
                    edconta.Text = (dbReader["contactno"].ToString());
                    edtype.Text = (dbReader["emp_type"].ToString());


                }
                dbReader.Close();
                dbConn.Close();
            }
        }

        private void glassButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to modify this employee information?", "Employee Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                    query = "Update employee Set emp_name = '" + edname.Text.Trim().ToUpper() + "', emp_rate = '" + edrate.Text + "', addr = '" + edadd.Text.Trim().ToUpper() + "', contactno = '" + edconta.Text.Trim().ToUpper() + "', emp_type = '" + edtype.Text.Trim().ToUpper() + "' Where emp_id = '" + comboBox2.Text + "'";

                    dbQuery(query);
                    MessageBox.Show("Successfully updated an employee info", "Employee Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Employee fm = new Employee();
                    fm.Show();
                    this.Close();
                }
            
            }
        }

        private void glassButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this employee?", "Employee Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                    query = "Delete From employee Where emp_id = '" + comboBox5.Text + "'";
             
                    dbQuery(query);
                    MessageBox.Show("Successfully deleted an employee", "Employee Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Employee fm = new Employee();
                    fm.Show();
                    this.Close();
                
                
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox5.SelectedIndex = comboBox4.SelectedIndex;
            comboBox4.SelectedIndex = comboBox5.SelectedIndex;
        }
    }
}