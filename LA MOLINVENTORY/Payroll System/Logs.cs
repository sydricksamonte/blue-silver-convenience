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
    public partial class Logs : Form
    {
        string user;
        public Logs(string aa)
        {
            InitializeComponent();
            user = aa;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        string line, line2, name;
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
        private void Logs_Load(object sender, EventArgs e)
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
                query = "Select * from logs WHERE userna = '" + user + "'";
                dbFill(query);
                while (dbReader.Read())
                {
                    name = dbReader["names"].ToString();
                  

                }
                dbReader.Close();
                dbConn.Close();
            }
            label3.Text = (calendate());
            label4.Text = name;
            //label3.Text = monthCalendar1.SelectionStart.ToShortDateString();
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
            
                    query = "Select * from security ";
             
                dbFill(query);
                while (dbReader.Read())
                {

                    dataGridView1.Rows.Add(dbReader["dates"].ToString(), dbReader["users"].ToString(), dbReader["notes"].ToString(), dbReader["ids"].ToString());


                }
                dbReader.Close();
                dbConn.Close();
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            //label3.Text = monthCalendar1.SelectionStart.ToShortDateString();

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

                query = "Select * from security WHERE dates LIKE'" + label3.Text + "%' ORDER BY dates DESC";

                dbFill(query);
                while (dbReader.Read())
                {

                    dataGridView1.Rows.Add(dbReader["dates"].ToString(), dbReader["users"].ToString(), dbReader["notes"].ToString(), dbReader["ids"].ToString());


                }
                dbReader.Close();
                dbConn.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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

                query = "Select * from security WHERE users LIKE'"+textBox1.Text+"%' ORDER BY dates DESC";

                dbFill(query);
                while (dbReader.Read())
                {

                    dataGridView1.Rows.Add(dbReader["dates"].ToString(), dbReader["users"].ToString(), dbReader["notes"].ToString(), dbReader["ids"].ToString());


                }
                dbReader.Close();
                dbConn.Close();
            }
        }

        private void glassButton1_Click(object sender, EventArgs e)
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

                query = "Select * from security WHERE users LIKE'" + textBox1.Text + "%' ORDER BY dates DESC";

                dbFill(query);
                while (dbReader.Read())
                {

                    dataGridView1.Rows.Add(dbReader["dates"].ToString(), dbReader["users"].ToString(), dbReader["notes"].ToString(), dbReader["ids"].ToString());


                }
                dbReader.Close();
                dbConn.Close();
            }
        }

        private void glassButton2_Click(object sender, EventArgs e)
        {
            Reports fm = new Reports("log", user, "");
            fm.Show();
            fm.Text = "Reports [System Log]";
        }
         private string calendate()
        {
            string ax = dateTimePicker1.Value.Month.ToString() + "/" + dateTimePicker1.Value.Day.ToString() + "/" + dateTimePicker1.Value.Year.ToString();
            return ax;
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        { dataGridView1.Rows.Clear();
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

                query = "Select * from security WHERE  dates  BETWEEN '" + calendate() + "' AND '" + calendate() + " 23:59:59" + "'  ORDER BY dates DESC";
                label3.Text = (calendate());
                dbFill(query);
                while (dbReader.Read())
                {

                    dataGridView1.Rows.Add(dbReader["dates"].ToString(), dbReader["users"].ToString(), dbReader["notes"].ToString(), dbReader["ids"].ToString());


                }
                dbReader.Close();
                dbConn.Close();
            }
         
          
        }
    }
}