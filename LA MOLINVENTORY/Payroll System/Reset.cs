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
    public partial class Reset : Form
    {
        string user = "";
        public Reset(string a)
        {
            InitializeComponent();
            user = a;
        }
        string line, line2;
        MySqlDataReader dbReader;
        MySqlConnection dbConn;
        string dbP;
        string dbU;
        string types; bool totoo = false; int wrong = 5; int goja = 0;
        private void glassButton2_Click(object sender, EventArgs e)
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
                query = "Select * from logs WHERE userna = '" + user + "' AND passw = '" + txtPass.Text + "'";
                dbFill(query);
                while (dbReader.Read())
                {
                    totoo = true;

                }
                dbReader.Close();
                dbConn.Close();
            }
            if (totoo == false)
            {
                if (wrong == 0)
                {
                    MessageBox.Show("The password you entered did not match. \nSystem will restart.", "System Reset", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Application.Restart();
                }
                MessageBox.Show("The password you entered did not match \nYou have " + wrong.ToString() + " tries left.", "System Reset", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                wrong--;
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

                    {
                        query33 = "DELETE FROM itemlist";

                    }

                    dbQuery(query33);
                    moves();
                    progressBar1.Visible = true;

                }
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
                        query33 = "DELETE FROM logs";

                    }

                    dbQuery(query33);
                    moves();
             

                }
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
                        query33 = "DELETE FROM security";

                    }

                    dbQuery(query33);
                    moves();
                    moves();

                }
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
                    moves();
                  

                }
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
                        query33 = "DELETE FROM totaltrans";

                    }

                    dbQuery(query33);
                    moves(); moves();


                }
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
                        query33 = "DELETE FROM transaction";

                    }

                    dbQuery(query33);
                    moves();
                    moves();


                }
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
                        query33 = "DELETE FROM trans_items";

                    }

                    dbQuery(query33);
                    moves();


                } 
                MessageBox.Show("The database has been nullified. \nApplication will restart.", "System Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
                Application.Restart();

            }
        }
        public void moves()
        {
            goja = goja + 10;
            progressBar1.Value = goja;
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
        private void Reset_Load(object sender, EventArgs e)
        {

        }
    }
}