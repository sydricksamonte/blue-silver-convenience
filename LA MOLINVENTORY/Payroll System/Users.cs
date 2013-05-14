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
    public partial class Users : Form
    {
        string user;
        public Users(string a)
        {
            InitializeComponent();
            user = a;
        }
        string line, line2;
        MySqlDataReader dbReader;
        MySqlConnection dbConn;
        string dbP;
        string dbU;
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            
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
        private void glassButton2_Click(object sender, EventArgs e)
        {
            if (adUser.Text.Length < 6)
            {
                MessageBox.Show("Username must be atleast 6 characters long.", "User Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (adPass.Text.Length < 6)
            {
                MessageBox.Show("Password must be atleast 6 characters long.", "User Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (adFull.Text.Length < 5)
            {
                MessageBox.Show("Please enter a valid name of the user.", "User Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (adpasV.Text!=adPass.Text)
            {
                MessageBox.Show("Password verification did not match.\nPlease try again", "User Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int i = 0;
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
                    query = "Select * from logs WHERE userna = '" + adUser.Text + "'";
                    dbFill(query);
                    while (dbReader.Read())
                    {

                        i = 1;
                        break;

                    }
                    dbReader.Close();
                    dbConn.Close();
                }
                if (i!=1)
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
                        query33 = "Insert Into security Values('" + System.DateTime.Now.ToString() + "(" + System.DateTime.Now.Millisecond.ToString() + ")_" + name + "','" + "Added user account"+adFull.Text.ToUpper()+ "','" + System.DateTime.Now.ToString() + "','" + name + "','"+terms()+"')";

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
                        query = "Insert Into logs Values('" + "U" + System.DateTime.Now.Year + System.DateTime.Now.Month + System.DateTime.Now.Day + System.DateTime.Now.Millisecond + "','" + adUser.Text.Trim() + "','" + adPass.Text.Trim() + "','" + adFull.Text.Trim().ToUpper() + "','" + adAdd.Text.Trim().ToUpper() + "','" + adContact.Text.Trim().ToUpper() + "','" + adEmail.Text.Trim().ToUpper() + "','" + adType.Text.Trim().ToUpper() + "' )";

                        dbQuery(query);
                        MessageBox.Show("Successfully added a new user", "User Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        adUser.Text = "";
                        adPass.Text= ""; 
                        adFull.Text= ""; 
                        adAdd.Text= ""; 
                        adContact.Text= "";
                        adEmail.Text= "";
                        adType.Text = "";

                    }
                }
                else
                {
                    MessageBox.Show("A user with the same username already exist.\nPlease choose another one.", "User Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    adUser.Focus();
                }
            }
        }
        string name = "";
        public void getName()
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
                query = "Select * from logs where userna = '" + user + "'";
                dbFill(query);
                while (dbReader.Read())
                {

                   
                     name = (dbReader["names"].ToString());
                       
                   
                }
                dbReader.Close();
                dbConn.Close();
            }
        }
        private void Users_Load(object sender, EventArgs e)
        {
            getName();
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
                query = "Select * from logs ORDER BY userna ASC ";
                dbFill(query);
                while (dbReader.Read())
                {
                    
                    if ((dbReader["types"].ToString() == "ADMIN") && (dbReader["userna"].ToString() != user))
                    {
                    }
                    else if ((dbReader["types"].ToString() == "ADMIN") )
                    {
                    }
                    else
                    {
                        comboBox3.Items.Add(dbReader["names"].ToString());
                        comboBox1.Items.Add(dbReader["user_code"].ToString());
                        comboBox4.Items.Add(dbReader["names"].ToString()); 
                        comboBox2.Items.Add(dbReader["user_code"].ToString());
                    }
                    

                }
                dbReader.Close();
                dbConn.Close();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = comboBox3.SelectedIndex;
            comboBox3.SelectedIndex = comboBox1.SelectedIndex;
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
                query = "Select * from logs WHERE user_code = '" + comboBox1.Text + "'";
                dbFill(query);
                while (dbReader.Read())
                {
                    edUse.Text = (dbReader["userna"].ToString());
                    edPass.Text = (dbReader["passw"].ToString());
                    edPasV.Text = (dbReader["passw"].ToString());
                    edname.Text = (dbReader["names"].ToString());
                    edadd.Text = (dbReader["addr"].ToString());
                    edcON.Text = (dbReader["connum"].ToString());
                    edem.Text = (dbReader["eadd"].ToString());
                    edtype.Text = (dbReader["types"].ToString());
                    if (edtype.Text == "Admin")
                    {
                        edtype.Enabled = false;
                    }
                    else
                    {
                        edtype.Enabled = true;
                    }

                }
                dbReader.Close();
                dbConn.Close();
            }
        }
       
        private void glassButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to modify this user information?", "User Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (edUse.Text.Length < 6)
                {
                    MessageBox.Show("Username must be atleast 6 characters long.", "User Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (edPass.Text.Length < 6)
                {
                    MessageBox.Show("Password must be atleast 6 characters long.", "User Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (edname.Text.Length < 5)
                {
                    MessageBox.Show("Please enter a valid name of the user.", "User Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (edPass.Text != edPasV.Text)
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
                        query33 = "Insert Into security Values('" + System.DateTime.Now.ToString() + "(" + System.DateTime.Now.Millisecond.ToString() + ")_" + user + "','" +"Modified user account: " + edname.Text.ToUpper() + "','" + System.DateTime.Now.ToString() + "','" + name + "','"+terms()+"')";

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
                        query = "Update logs Set userna = '" + edUse.Text.Trim() + "', passw = '" + edPass.Text.Trim() + "', names = '" + edname.Text.Trim().ToUpper() + "', addr = '" + edadd.Text.Trim().ToUpper() + "', connum = '" + edcON.Text.Trim().ToUpper() + "', eadd = '" + edem.Text.Trim().ToUpper() + "', types = '" + edtype.Text.Trim().ToUpper() + "' Where user_code = '" + comboBox1.Text + "'";

                        dbQuery(query);
                        MessageBox.Show("Successfully updated a user information", "User Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Users fm = new Users(user);
                        fm.Show();
                        this.Close();
                    }
                 
                }

            }
        }
       
        private void glassButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this employee?", "Employee Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
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
                        query33 = "Insert Into security Values('" + System.DateTime.Now.ToString() + "(" + System.DateTime.Now.Millisecond.ToString() + ")_" + name + "','" + "Delete user account: " + comboBox2.Text + "','" + System.DateTime.Now.ToString() + "','" + name + "','"+terms()+"')";

                        dbQuery(query33);

                    }
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
                    query = "Delete From logs Where user_code = '" + comboBox2.Text + "'";

                    dbQuery(query);
                    MessageBox.Show("Successfully deleted a user", "User Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Users fm = new Users(user);
                    fm.Show();
                    this.Close();

                }
               
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = comboBox4.SelectedIndex;
            comboBox4.SelectedIndex = comboBox2.SelectedIndex;
        }
    }
}