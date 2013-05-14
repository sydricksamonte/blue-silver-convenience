using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace Payroll_System
{
    public partial class Unit : Form
    {
        public Unit()
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
        private void disCells()
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
                query = "Select * from unittable ORDER BY unit_name ASC";
                dbFill(query);
                while (dbReader.Read())
                {
                    dataGridView1.Rows.Add(dbReader["unit_id"].ToString(), dbReader["unit_name"].ToString());



                }
                dbReader.Close();
                dbConn.Close();
            }
        }
        private void Unit_Load(object sender, EventArgs e)
        {
            disCells();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want update this unit?", "Units", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
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
                        query33 = "UPDATE itemlist SET unit  = '" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "' Where item_no IN ('" + innames + "')";

                    }

                    dbQuery(query33);


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

                    query33 = " Update unittable Set unit_name = '" + dataGridView1.CurrentRow.Cells[1].Value.ToString().ToUpper() + "' Where  unit_id = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString().ToUpper() + "'";

                    dbQuery(query33);
                    MessageBox.Show("Unit was successfully updated.");
                    //Unit ss = new Unit();
                    //ss.Show();
                    //this.Hide();
                    dataGridView1.Rows.Clear();
                    disCells();
                }
            }

        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
           
        }

        private void glassButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want add this unit?", "Units", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
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
                        query33 = "Insert Into unittable Values('" + textBox1.Text.Trim().ToUpper() + "','" + textBox1.Text.Trim().ToUpper() + "')";

                        dbQuery(query33);
                        MessageBox.Show("Unit was successfully added.");
                        dataGridView1.Rows.Clear();
                        disCells();
                        textBox1.Text = "";
                        textBox1.Focus();
                    }
                }
            }
            catch
            {
                MessageBox.Show("The unit exists.");
            }

        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
        string innames = "";
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            bool notallowed = false;
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Are you sure you want delete this unit?", "Units", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
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
                        query = "Select * from itemlist WHERE  unit = '" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'";
                        dbFill(query);
                        while (dbReader.Read())
                        {

                            notallowed = true;

                        }
                        dbReader.Close();
                        dbConn.Close();
                    }
                    if (notallowed == false)
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

                        query33 = "DELETE FROM unittable Where unit_id = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";

                        dbQuery(query33);
                        MessageBox.Show("Unit was successfully deleted.");
                        dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                    }
                    else
                    {
                        MessageBox.Show("There are items who uses this unit. \nThe unit cannot be deleted.");
                    
                    }
                }
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                innames = "";
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
                    query = "Select * from itemlist WHERE unit = '" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'";
                    dbFill(query);
                    while (dbReader.Read())
                    {



                        innames = dbReader["item_no"].ToString() + "','" + innames;

                    }
                    dbReader.Close();
                    dbConn.Close();

                    //MessageBox.Show(innames);
                }
            }
            catch { }
        }
    }
}