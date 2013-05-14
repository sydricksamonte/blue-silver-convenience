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
    public partial class Form1 : Form
    {
  
        public Form1()
        {
            InitializeComponent();
        }      string line, line2;
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
        private string timecomponent()
        {
            string ax = System.DateTime.Now.Year.ToString() + "/" + System.DateTime.Now.Month.ToString() + "/" + System.DateTime.Now.Day.ToString() + " " + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString();
            return ax;
        }
        public void del()
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
                    query33 = "DELETE FROM systime";

                }

                dbQuery(query33);
              
            }
        }
        int wrong = 5; DateTime tryer; DateTime newTime; DateTime nowTime; TimeSpan ss;
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
        
        public void proceedNow()
        {
            bool dog = true;
            try
            {
                //    string query33;


                //    StreamReader sr33 = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                //    line = sr33.ReadLine();
                //    StreamReader sr34 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                //    dbP = sr34.ReadLine();
                //    StreamReader sr35 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                //    dbU = sr35.ReadLine();
                //    string sConnection33 = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                //    MySqlConnection sqlConnection33 = new MySqlConnection(sConnection33);
                //    query33 = "Select * from systime";
                //    dbFill(query33);
                //    while (dbReader.Read())
                //    {
                //        wrong = int.Parse(dbReader["tleft"].ToString());
                //        tryer =Convert.ToDateTime( dbReader["timeleft"].ToString());
                //    }
                //    dbReader.Close();
                //    dbConn.Close();
                //    newTime = tryer.AddMinutes(5);
                //    nowTime = System.DateTime.Now;
                //     ss = nowTime - newTime;
                //    MessageBox.Show(ss.ToString());
                //}
                //if ((wrong == 0)||(ss >TimeSpan.("00:05:00.0")))
                //{
                //    MessageBox.Show("System Block. \nPlease try again after "+ss.ToString()+" minutes", "Log-In", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                //}
                //else
                {
                    {
                        string username;
                        string password = "";
                        string types = "";
                        string name = "";


                        string query;


                        StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                        line = sr.ReadLine();
                        StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                        dbP = sr3.ReadLine();
                        StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                        dbU = sr4.ReadLine();
                        string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                        MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                        query = "Select * from logs WHERE userna = '" + txtUser.Text + "'";
                        dbFill(query);
                        while (dbReader.Read())
                        {
                            username = dbReader["userna"].ToString();
                            password = dbReader["passw"].ToString();
                            name = dbReader["names"].ToString();
                            types = dbReader["types"].ToString();
                            if (password == txtPass.Text)
                            {
                                MessageBox.Show("Welcome " + name + " !", "Log In", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                                    query33 = "Insert Into security Values('" + System.DateTime.Now.ToString() + "(" + System.DateTime.Now.Millisecond.ToString() + ")_" + txtUser.Text.Trim() + "','" + "The user logged in." + "','" + System.DateTime.Now.ToString() + "','" + name + "','"+terms()+"')";

                                    dbQuery(query33);
                                    del();
                                }
                                if (types == "ADMIN")
                                {
                                    Admin admin = new Admin(username);
                                    admin.Text = "Workpane [" + name + "]";
                                    admin.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    Workpane admin = new Workpane(username);
                                    admin.Text = "Workpane [" + name + "]";
                                    admin.Show();
                                    this.Hide();
                                }

                                dog = false;
                                break;

                            }
                            //else
                            //{
                            //    MessageBox.Show("Username or password did not match.\nPlease try again.", "Log In", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            //    dog = false;
                            //    break;

                            //}
                        }
                        dbReader.Close();
                        dbConn.Close();
                        if ((txtPass.Text == "") || (txtUser.Text == ""))
                        {
                            MessageBox.Show("Missing field.\nPlease try again.", "Log In", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dog = false;

                        }
                        if (dog == true)
                        {
                            MessageBox.Show("Username or password did not match.\nPlease try again.", "Log In", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            dog = false;
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
                                query33 = "Insert Into security Values('" + System.DateTime.Now.ToString() + "(" + System.DateTime.Now.Millisecond.ToString() + ")_" + "ANONYMOUS" + "','" + "Someone is trying to log-in a username [ " + txtUser.Text.Trim() + " ] but failed." + "','" + System.DateTime.Now.ToString() + "','" + "ANONYMOUS" + "','"+terms()+"')";

                                dbQuery(query33);

                            }


                            bool meron = false;
                            //{
                            //    string query33;


                            //    StreamReader sr33 = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                            //    line = sr33.ReadLine();
                            //    StreamReader sr34 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                            //    dbP = sr34.ReadLine();
                            //    StreamReader sr35 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                            //    dbU = sr35.ReadLine();
                            //    string sConnection33 = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                            //    MySqlConnection sqlConnection33 = new MySqlConnection(sConnection33);
                            //    query = "Select * from systime";
                            //    dbFill(query);
                            //    while (dbReader.Read())
                            //    {
                            //        wrong = int.Parse(dbReader["tleft"].ToString());
                            //        meron = true;
                            //    }
                            //    dbReader.Close();
                            //    dbConn.Close();
                            //}
                            //if (meron == true)
                            //{
                            //    if (wrong == 0)
                            //    {
                            //        MessageBox.Show("Username or password did not match. \nPlease try again after 5 minutes", "Log-In", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            //    }

                            //MessageBox.Show("Username or password did not match. \nYou have " + wrong.ToString() + " tries left.", "Log-In", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            //wrong--;
                            //{
                            //    string query33;


                            //    StreamReader sr33 = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                            //    line = sr33.ReadLine();
                            //    StreamReader sr34 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                            //    dbP = sr34.ReadLine();
                            //    StreamReader sr35 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                            //    dbU = sr35.ReadLine();
                            //    string sConnection33 = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                            //    MySqlConnection sqlConnection33 = new MySqlConnection(sConnection33);

                            //    query33 = " Update systime Set tleft = '" + wrong.ToString() + "' WHERE timeleft like '" + "2" + "%'";

                            //    dbQuery(query33);
                            //    //  MessageBox.Show("may update annu");
                            //}
                            //}
                            //else
                            //{
                            //    {
                            //        string query33;


                            //        StreamReader sr33 = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                            //        line = sr33.ReadLine();
                            //        StreamReader sr34 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                            //        dbP = sr34.ReadLine();
                            //        StreamReader sr35 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                            //        dbU = sr35.ReadLine();
                            //        string sConnection33 = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                            //        MySqlConnection sqlConnection33 = new MySqlConnection(sConnection33);
                            //        query33 = "Insert Into systime Values('" + timecomponent() + "','" + wrong.ToString() + "')";

                            //        dbQuery(query33);

                            //    }
                        }
                    }

                }
            }
            catch
            {
                MessageBox.Show("There's something wrong with the database connection.\nPlease check your settings.", "Log In", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }
        public void glassButton2_Click(object sender, EventArgs e)
        {
            string stat = "";
            string query;
            StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
            line = sr.ReadLine();
            StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
            dbP = sr3.ReadLine();
            StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
            dbU = sr4.ReadLine();
            string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
            MySqlConnection sqlConnection = new MySqlConnection(sConnection);
            query = "Select * from status";
            dbFill(query);
            while (dbReader.Read())
            {
                stat = dbReader["IsOpen"].ToString();
            }
            dbReader.Close();
            dbConn.Close();
            if (stat == "0")
            {
                string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                query = "Update status set IsOpen = '1'";
                dbQuery(query);
                proceedNow();
            }
            else
            {
                MessageBox.Show("Access is denied. The database is in use by another person.");
            }
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            bool mer = false;
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
                query = "Select * from logs ";
                dbFill(query);
                while (dbReader.Read())
                {


                    mer = true;
                }
                dbReader.Close();
                dbConn.Close();
            }
            if (mer == false)
            {
                Introductory iddn = new Introductory();
                iddn.Show();
                this.Hide();
            }
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
                txtPass.Focus();
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
                proceedNow();
            }
        }

        private void glassButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}