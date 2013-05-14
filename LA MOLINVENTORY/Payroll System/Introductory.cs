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
    public partial class Introductory : Form
    {
        public Introductory()
        {
            InitializeComponent();
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
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Introductory_Load(object sender, EventArgs e)
        {
            p1.Visible = true;
            p0.Visible = false;
            p2.Visible = false; p3.Visible = false;
        }

        private void glassButton2_Click(object sender, EventArgs e)
        {
            label17.Text = System.DateTime.Now.ToString();
           // p0.Visible = true;
            p1.Visible = false;
            p2.Visible = false;
            p3.Visible = true;
        }
        private string terms()
        {
            string year1 = "";
            string year2 = "";
            string termCur = "";

            if ((System.DateTime.Now.Month.ToString() == "6") || (System.DateTime.Now.Month.ToString() == "7") || (System.DateTime.Now.Month.ToString() == "8") || (System.DateTime.Now.Month.ToString() == "9"))
            {
                year1 = System.DateTime.Now.Year.ToString();
                year2 = System.DateTime.Now.AddYears(1).Year.ToString();
                termCur = "1T";
            }
            else if ((System.DateTime.Now.Month.ToString() == "10") || (System.DateTime.Now.Month.ToString() == "11") || (System.DateTime.Now.Month.ToString() == "12"))
            {
                year1 = System.DateTime.Now.Year.ToString();
                year2 = System.DateTime.Now.AddYears(1).Year.ToString();
                termCur = "2T";
            }
            else if ((System.DateTime.Now.Month.ToString() == "1") || (System.DateTime.Now.Month.ToString() == "2") || (System.DateTime.Now.Month.ToString() == "3"))
            {
                year2 = System.DateTime.Now.Year.ToString();
                year1 = System.DateTime.Now.AddYears(-1).Year.ToString();
                termCur = "3T";
            }
            else
            {
                year2 = System.DateTime.Now.Year.ToString();
                year1 = System.DateTime.Now.AddYears(-1).Year.ToString();
                termCur = "3T";
            }

            string termyear = year1 + "-" + year2 + "/" + termCur;
            return termyear;
        }
        private void glassButton1_Click(object sender, EventArgs e)
        {
            if (txtu.Text.Length < 6)
            {
                MessageBox.Show("Username must be atleast 6 characters long.", "User Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtP.Text.Length < 6)
            {
                MessageBox.Show("Password must be atleast 6 characters long.", "User Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (fname.Text.Length < 5)
            {
                MessageBox.Show("Please enter a valid name of the user.", "User Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (textBox3.Text != txtP.Text)
            {
                MessageBox.Show("Password verification did not match.\nPlease try again", "User Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
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
                    query33 = "Insert Into security Values('" + System.DateTime.Now.ToString() + "(" + System.DateTime.Now.Millisecond.ToString() + ")_" + txtu.Text + "','" + "Started using Inventory System" + "','" + System.DateTime.Now.ToString() + "','" + fname.Text + "','"+terms()+"')";

                    dbQuery(query33);

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
                    query = "Insert Into logs Values('" + "U" + System.DateTime.Now.Year + System.DateTime.Now.Month + System.DateTime.Now.Day + System.DateTime.Now.Millisecond + "','" + txtu.Text.Trim() + "','" + txtP.Text.Trim() + "','" + fname.Text.ToUpper() + "','" + txtAdd.Text.Trim().ToUpper() + "','" + txtCon.Text.Trim() + "','" + txtEm.Text.Trim() + "','" + "ADMIN" + "' )";

                    dbQuery(query);
                    MessageBox.Show("You've just created this Inventory System's first account! \nFor questions and help, click System help on the Help menu.", "Welcome!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Workpane fm = new Workpane(txtu.Text);
                    fm.Show();
                    this.Close();

                }
            }
        }

        private void glassButton4_Click(object sender, EventArgs e)
        {
            p2.Visible = true;
            p1.Visible = false; p3.Visible = false;
        }

        private void glassButton5_Click(object sender, EventArgs e)
        {
           
        }

        private void glassButton6_Click(object sender, EventArgs e)
        {
            p0.Visible = false;
            p1.Visible = false;
            p2.Visible = false;
            p3.Visible = true;
        }

        private void glassButton3_Click(object sender, EventArgs e)
        {
            p0.Visible = false;
            p1.Visible = false;
            p2.Visible = true;
            p3.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}