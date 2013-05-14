using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using MySql.Data.MySqlClient;

namespace Payroll_System
{
    public partial class Reports : Form
    {
        string type = "";
          string user = "";
        string newquery = "";
        public Reports(string a, string b,string c)
        {
            InitializeComponent();
            type = a;
            user = b;
            newquery = c;
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
        private string timecomponent()
        {
            string ax = System.DateTime.Now.Year.ToString() + "/" + System.DateTime.Now.Month.ToString() + "/" + System.DateTime.Now.Day.ToString() + " " + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString();
            return ax;
        }
        private string datecomponent()
        {
            string ax = System.DateTime.Now.Year.ToString() + "/" + System.DateTime.Now.Month.ToString() + "/" + System.DateTime.Now.Day.ToString();
            return ax;
        }
        private string calendate()
        {
            string ax = dateTimePicker1.Value.Year.ToString() + "/" + dateTimePicker1.Value.Month.ToString() + "/" + dateTimePicker1.Value.Day.ToString();
            return ax;
        }
        private string calenMonth()
        {
            string ax = "";
            try
            {
                ax = listBox1.SelectedItem.ToString() + "/" + listBox2.SelectedItem.ToString();
                
            }
            catch { }
            return ax;
        }
        private string calenYear()
        {
            string ax = "";
          
                ax = listBox1.SelectedItem.ToString() + "/";
               
        
            return ax;
        }
        private string idcomponent()
        {
            string ax = System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Millisecond.ToString();
            return ax;
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
        public void dbFillPrint(string statement)
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

            MySqlConnection con = new MySqlConnection(sConnection);
            con.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
            MySqlDataAdapter Subadapter = new MySqlDataAdapter(sql, con);
            ReportDocument cryRpt = new ReportDocument();
            ReportDocument SubcryRpt = new ReportDocument();
            if (type == "tsales")
            {
                RepItems ds = new RepItems();
                adapter.Fill(ds.Tables[0]);
                cryRpt.Load(Application.StartupPath.ToString() + "//Reports/TotalSales.rpt");
                cryRpt.SetDataSource(ds.Tables[0]);

                crystalReportViewer1.ReportSource = cryRpt;

                crystalReportViewer1.RefreshReport();
             
            }
            else if (type == "top")
            {
                RepItems ds = new RepItems();
                adapter.Fill(ds.Tables[0]);
                cryRpt.Load(Application.StartupPath.ToString() + "//Reports/Top.rpt");
                cryRpt.SetDataSource(ds.Tables[0]);

                crystalReportViewer1.ReportSource = cryRpt;

                crystalReportViewer1.RefreshReport();

            }
            else if (type == "rem")
            {
                RepRemain ds = new RepRemain();
                adapter.Fill(ds.Tables[0]);
                cryRpt.Load(Application.StartupPath.ToString() + "//Reports/Remaining.rpt");
                cryRpt.SetDataSource(ds.Tables[0]);

                crystalReportViewer1.ReportSource = cryRpt;

                crystalReportViewer1.RefreshReport();
        
            }
            else if (type == "voids")
            {
                RepVoid ds = new RepVoid();
                adapter.Fill(ds.Tables[0]);
                cryRpt.Load(Application.StartupPath.ToString() + "//Reports/VoidList.rpt");
                cryRpt.SetDataSource(ds.Tables[0]);

                crystalReportViewer1.ReportSource = cryRpt;

                crystalReportViewer1.RefreshReport();

            }
            else if (type == "log")
            {
                repsec ds = new repsec();
                adapter.Fill(ds.Tables[0]);
                cryRpt.Load(Application.StartupPath.ToString() + "//Reports/Logs.rpt");
                cryRpt.SetDataSource(ds.Tables[0]);

                crystalReportViewer1.ReportSource = cryRpt;

             
                crystalReportViewer1.RefreshReport();
            }
             else if (type == "trans")
            {
                RepTrans ds = new RepTrans();
                adapter.Fill(ds.Tables[0]);
                cryRpt.Load(Application.StartupPath.ToString() + "//Reports/Trans.rpt");
                cryRpt.SetDataSource(ds.Tables[0]);

                crystalReportViewer1.ReportSource = cryRpt;

                crystalReportViewer1.RefreshReport();
              
            }
            else if (type == "cha")
            {
                RepItems ds = new RepItems();
                adapter.Fill(ds.Tables[0]);
                cryRpt.Load(Application.StartupPath.ToString() + "//Reports/Chart.rpt");
                cryRpt.SetDataSource(ds.Tables[0]);

                crystalReportViewer1.ReportSource = cryRpt;

                crystalReportViewer1.RefreshReport();

            }
            else if (type == "out")
            {
                RepOut ds = new RepOut();
               
                 adapter.Fill(ds.Tables[0]);
     
               //  Subadapter.Fill(ss.Tables[0]);
                cryRpt.Load(Application.StartupPath.ToString() + "//Reports/Out.rpt");
                cryRpt.SetDataSource(ds.Tables[0]);

                crystalReportViewer1.ReportSource = cryRpt;

                
                crystalReportViewer1.RefreshReport();
            }
        }
        private void Reports_Load(object sender, EventArgs e)
        {
            if ((type == "tsales")||(type == "top"))
            {
                lod = 1;
                for (int j = (int.Parse(System.DateTime.Now.Year.ToString()) - 5); j < int.Parse(System.DateTime.Now.Year.ToString()) + 1; j++)
                {
                    listBox1.Items.Add(j.ToString());
                }
                for (int j = 1; j < 13; j++)
                {
                    listBox2.Items.Add(j.ToString());
                } dateTimePicker1.MaxDate = (System.DateTime.Now.Date);
                listBox1.SelectedIndex = 5;
                listBox2.SelectedIndex = int.Parse(System.DateTime.Now.Month.ToString());
                if (type == "tsales")
                {
                
                }
                dateTimePicker1_ValueChanged(glassButton1, e);
            }
            else if (type == "voids")
            {
                crystalReportViewer1.Dock = DockStyle.Fill;
                panel1.Visible = false;
                panel2.Visible = false;
                string query;
                {
                    StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                    line = sr.ReadLine();
                    StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                    dbP = sr3.ReadLine();
                    StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                    dbU = sr4.ReadLine();
                    string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                    MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                    query = "SELECT        voidtable.trans_item_id, voidtable.item_name, voidtable.quanvoid, voidtable.time_void, voidtable.type, itemlist.supp, itemlist.categ, logs.names, logs.connum,  logs.eadd, logs.addr, trans_items.trans_id FROM            ((voidtable INNER JOIN trans_items ON voidtable.trans_item_id = trans_items.trans_item_id) INNER JOIN   itemlist ON trans_items.item_name = itemlist.item_name), logs WHERE userna='" + user + "'";
                   // query = " SELECT        voidtable.trans_id, voidtable.trans_item_id, voidtable.item_name, voidtable.quanvoid, voidtable.time_void, voidtable.type, itemlist.supp, itemlist.categ,   logs.names, logs_1.names AS Expr2, logs_1.connum, logs_1.eadd FROM     (((voidtable INNER JOIN  itemlist ON voidtable.item_name = itemlist.item_name) INNER JOIN transaction ON voidtable.trans_id = transaction.trans_id) INNER JOIN logs ON transaction.user_code = logs.userna), logs logs_1";
                   // query = " SELECT        voidtable.trans_id, voidtable.trans_item_id, voidtable.item_name, voidtable.quanvoid, voidtable.time_void, voidtable.type, itemlist.supp, itemlist.categ,  logs.names FROM      (((voidtable INNER JOIN itemlist ON voidtable.item_name = itemlist.item_name) INNER JOIN transaction ON voidtable.trans_id = transaction.trans_id) INNER JOIN logs ON transaction.user_code = logs.userna)";
                  //  query = " SELECT        voidtable.trans_id, voidtable.trans_item_id, voidtable.item_name, voidtable.quanvoid, voidtable.time_void, voidtable.type, itemlist.supp, itemlist.categ, logs.names, logs.connum, logs.eadd, logs.addr FROM  (voidtable INNER JOIN  itemlist ON voidtable.item_name = itemlist.item_name),logs WHERE userna='" + user + "'";
                    dbFillPrint(query);
                    while (dbReader.Read())
                    {

                    }
                    dbReader.Close();
                    dbConn.Close();


                }
            }
            else if (type == "top")
            {
                //crystalReportViewer1.Dock = DockStyle.Fill;
                //panel1.Visible = false;
                //panel2.Visible = false;
                string query; string getj = "";
                int ranger = 0;
                {
                    StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                    line = sr.ReadLine();
                    StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                    dbP = sr3.ReadLine();
                    StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                    dbU = sr4.ReadLine();
                    string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                    MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                    query = " SELECT        totaltrans.total_trans_id, totaltrans.categ, totaltrans.item_name, totaltrans.quan, totaltrans.time_sum, totaltrans.item_id, totaltrans.sum_amount, logs.names, logs.user_code, logs.userna, logs.eadd, logs.connum FROM    totaltrans, logs  WHERE  typex = '" + "annual" + "' AND userna = '" + user + "' ORDER BY quan DESC";
                    dbFill(query);
                    while (dbReader.Read())
                    {
                        ranger++;
                        if (ranger == 10)
                        {
                            getj = dbReader["quan"].ToString();
                            break;
                        }
                    }
                    dbReader.Close();
                    dbConn.Close();


                }
                {
                    StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                    line = sr.ReadLine();
                    StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                    dbP = sr3.ReadLine();
                    StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                    dbU = sr4.ReadLine();
                    string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                    MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                    query = " SELECT        totaltrans.total_trans_id, totaltrans.categ, totaltrans.item_name, totaltrans.quan, totaltrans.time_sum, totaltrans.item_id, totaltrans.sum_amount, logs.names, logs.user_code, logs.userna, logs.eadd, logs.connum FROM    totaltrans, logs  WHERE  typex = '" + "annual" + "' AND userna = '" + user + "' AND quan >= '" + getj + "'ORDER BY quan DESC";

                    //    query = "SELECT total_trans_id, categ, item_name, quan, time_sum, item_id, sum_amount FROM totaltrans WHERE time_sum  BETWEEN '" + calenYear() + "/1/1" + "' AND '" + calenYear() + "12/31 23:59:59" + "' AND typex = '" + "annual" + "' ORDER BY categ";
                    // dbFill(query);
                    dbFillPrint(query);
                    while (dbReader.Read())
                    {

                    }
                    dbReader.Close();
                    dbConn.Close();


                }
                dateTimePicker1_ValueChanged(glassButton1, e);
                ranger = 0;
                getj = "";
            }
            else if (type == "rem")
            {
                crystalReportViewer1.Dock = DockStyle.Fill;
                panel1.Visible = false;
                panel2.Visible = false;
                string query;
                {
                    StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                    line = sr.ReadLine();
                    StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                    dbP = sr3.ReadLine();
                    StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                    dbU = sr4.ReadLine();
                    string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                    MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                    query = "SELECT        itemlist.item_no, itemlist.item_name, itemlist.categ,  itemlist.origprice, itemlist.srp, itemlist.unit, itemlist.quan, itemlist.supp, logs.user_code,  logs.userna, logs.names, logs.connum, logs.eadd FROM   itemlist, logs WHERE userna = '" + user + "'  ORDER BY categ,quan DESC";
                    dbFillPrint(query);
                    while (dbReader.Read())
                    {

                    }
                    dbReader.Close();
                    dbConn.Close();


                }
            }
            else if (type == "log")
            {
                // crystalReportViewer1.Dock = DockStyle.Fill;
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = true;
                string query;
                {
                    StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                    line = sr.ReadLine();
                    StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                    dbP = sr3.ReadLine();
                    StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                    dbU = sr4.ReadLine();
                    string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                    MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                    query = "SELECT DISTINCT term FROM security ORDER BY term DESC";
                    dbFill(query);
                    while (dbReader.Read())
                    {
                        comboBox1.Items.Add(dbReader["term"].ToString());
                    }
                    dbReader.Close();
                    dbConn.Close();


                }
                comboBox1.SelectedIndex = 0;
                {
                    StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                    line = sr.ReadLine();
                    StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                    dbP = sr3.ReadLine();
                    StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                    dbU = sr4.ReadLine();
                    string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                    MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                    query = "SELECT        security.ids, security.notes, security.dates,security.term, security.users, logs.names, logs.userna, logs.user_code, logs.connum, logs.eadd  FROM    security, logs WHERE userna = '" + user + "' AND term = '" + comboBox1.Text + "' ORDER BY dates DESC";
                    dbFillPrint(query);
                    while (dbReader.Read())
                    {

                    }
                    dbReader.Close();
                    dbConn.Close();


                }
            }
            else if (type == "trans")
            {
                crystalReportViewer1.Dock = DockStyle.Fill;
                panel1.Visible = false;
                panel2.Visible = false;
                if (newquery == "")
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
                    //query = "SELECT trans_items.trans_item_id, trans_items.item_id, trans_items.item_name, trans_items.trans_id, trans_items.quan, logs.names, transaction.dat_trans FROM ((trans_items INNER JOIN transaction ON trans_items.trans_id = transaction.trans_id) INNER JOIN logs ON transaction.user_code = logs.userna) ORDER BY transaction.dat_trans DESC,transaction.trans_id ASC ";
                    query = " SELECT        trans_items.trans_item_id, trans_items.item_id, trans_items.item_name, trans_items.trans_id, trans_items.quan, transaction.dat_trans, logs_1.addr , logs_1.eadd ,  logs.names, logs_1.names AS Expr1, itemlist.supp FROM    (((trans_items INNER JOIN transaction ON trans_items.trans_id = transaction.trans_id) INNER JOIN logs ON transaction.user_code = logs.userna)  INNER JOIN  itemlist ON trans_items.item_id = itemlist.item_no AND trans_items.item_name = itemlist.item_name), logs logs_1 WHERE logs_1.userna='" + user + "' ORDER BY transaction.dat_trans DESC,transaction.trans_id ASC ";

                    dbFillPrint(query);
                    while (dbReader.Read())
                    {

                    }
                    dbReader.Close();
                    dbConn.Close();



                }
                else
                {
                    {
                        string query = newquery;
                        StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                        line = sr.ReadLine();
                        StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                        dbP = sr3.ReadLine();
                        StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                        dbU = sr4.ReadLine();
                        string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                        MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                        dbFillPrint(query);
                        while (dbReader.Read())
                        {

                        }
                        dbReader.Close();
                        dbConn.Close();

                    }
                }



            }
            else if (type == "cha")
            {



                {
                    string query;
                    {
                        StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                        line = sr.ReadLine();
                        StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                        dbP = sr3.ReadLine();
                        StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                        dbU = sr4.ReadLine();
                        string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                        MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                        query = "SELECT        totaltrans.total_trans_id, totaltrans.categ, totaltrans.item_name, totaltrans.quan, totaltrans.time_sum, totaltrans.item_id, totaltrans.sum_amount, logs.names, logs.user_code, logs.userna, logs.eadd, logs.connum FROM    totaltrans, logs WHERE time_sum  BETWEEN '" + System.DateTime.Now.Year.ToString() + "/1/1 01:00:00" + "' AND '" + System.DateTime.Now.Year.ToString() + "/12/31 23:59:59 " + "'  AND typex = '" + "daily" + "' AND userna = '" + user + "' ORDER BY categ";
                        dbFillPrint(query);
                        while (dbReader.Read())
                        {

                        }
                        dbReader.Close();
                        dbConn.Close();


                    }


                }
            }
            else if (type == "out")
            {
                {
                    crystalReportViewer1.Dock = DockStyle.Fill;
                    panel1.Visible = false;
                    panel2.Visible = false;

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
                        query = "SELECT        itemlist.item_no, itemlist.item_name, itemlist.categ, itemlist.origprice, itemlist.srp, itemlist.unit, itemlist.quan, itemlist.supp, logs.userna,  logs.user_code, logs.names, logs.connum, logs.eadd FROM    itemlist, logs WHERE userna = '" + user + "' AND quan < origprice  ORDER BY quan ASC, categ ASC";

                        dbFillPrint(query);
                        while (dbReader.Read())
                        {

                        }
                        dbReader.Close();
                        dbConn.Close();

                    }
                    //{
                    //    crystalReportViewer1.Dock = DockStyle.Fill;

                    //    string query;
                    //    {
                    //        StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                    //        line = sr.ReadLine();
                    //        StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                    //        dbP = sr3.ReadLine();
                    //        StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                    //        dbU = sr4.ReadLine();
                    //        string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                    //        MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                    //        query = "SELECT * FROM logs WHERE userna ='" + user + "' ";
                    //        dbFillPrint(query);
                    //        while (dbReader.Read())
                    //        {

                    //        }
                    //        dbReader.Close();
                    //        dbConn.Close();

                    //    }
                    //}
                }


            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
           
        }
        
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            bool mer = false;
            if (type == "tsales")
            {
                string query;
                {
                    StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                    line = sr.ReadLine();
                    StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                    dbP = sr3.ReadLine();
                    StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                    dbU = sr4.ReadLine();
                    string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                    MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                    query = "SELECT        totaltrans.total_trans_id, totaltrans.categ, totaltrans.item_name, totaltrans.quan, totaltrans.time_sum, totaltrans.item_id, totaltrans.sum_amount, totaltrans.typex,   logs.userna, logs.names, logs.addr, logs.connum, logs.eadd, itemlist.oprice, itemlist.unit, itemlist.srp FROM    (totaltrans INNER JOIN itemlist ON totaltrans.item_id = itemlist.item_no), logs WHERE time_sum  BETWEEN '" + calendate() + "' AND '" + calendate() + " 23:59:59" + "'  AND typex = '" + "daily" + "' AND userna = '" + user + "' ORDER BY categ, quan desc";
                    dbFillPrint(query);
                    while (dbReader.Read())
                    {
                        mer = true; 
                    }
                    dbReader.Close();
                    dbConn.Close();


                }
                if (mer == false)
                {
                    label3.Visible = true;
                    crystalReportViewer1.Visible = false;
                }
                else
                {
                    label3.Visible = false;
                    crystalReportViewer1.Visible = true;
                }
            }
            else if (type == "top")
            {
                if (radioButton1.Checked == true)
                {
                    string query; string getj = "";
                    int ranger = 0;
                    {
                        StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                        line = sr.ReadLine();
                        StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                        dbP = sr3.ReadLine();
                        StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                        dbU = sr4.ReadLine();
                        string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                        MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                        query = " SELECT     totaltrans.typex,   totaltrans.total_trans_id, totaltrans.categ, totaltrans.item_name, totaltrans.quan, totaltrans.time_sum, totaltrans.item_id, totaltrans.sum_amount, logs.names, logs.user_code, logs.userna, logs.eadd, logs.connum FROM    totaltrans, logs  WHERE  time_sum  BETWEEN '" + calendate() + "' AND '" + calendate() + " 23:59:59" + "'  AND typex = '" + "daily" + "' AND userna = '" + user + "' ORDER BY quan DESC";
                        dbFill(query);
                        while (dbReader.Read())
                        {
                            mer = true; 
                            ranger++;
                            if (ranger == 10)
                            {
                               
                                getj = dbReader["quan"].ToString();
                                break;
                            }
                        }
                        dbReader.Close();
                        dbConn.Close();


                    }
                    {
                        StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                        line = sr.ReadLine();
                        StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                        dbP = sr3.ReadLine();
                        StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                        dbU = sr4.ReadLine();
                        string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                        MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                        query = " SELECT      totaltrans.typex,  totaltrans.total_trans_id, totaltrans.categ, totaltrans.item_name, totaltrans.quan, totaltrans.time_sum, totaltrans.item_id, totaltrans.sum_amount, logs.names, logs.user_code, logs.userna, logs.eadd, logs.connum FROM    totaltrans, logs  WHERE time_sum  BETWEEN '" + calendate() + "' AND '" + calendate() + " 23:59:59" + "'    AND typex = '" + "daily" + "' AND userna = '" + user + "' AND quan >= '" + getj + "'ORDER BY quan DESC";

                        //    query = "SELECT total_trans_id, categ, item_name, quan, time_sum, item_id, sum_amount FROM totaltrans WHERE time_sum  BETWEEN '" + calenYear() + "/1/1" + "' AND '" + calenYear() + "12/31 23:59:59" + "' AND typex = '" + "annual" + "' ORDER BY categ";
                        // dbFill(query);
                        dbFillPrint(query);
                        while (dbReader.Read())
                        {

                        }
                        dbReader.Close();
                        dbConn.Close();


                    }
                    ranger = 0;
                    getj = "";
                    if (mer == false)
                    {
                        label3.Visible = true;
                        crystalReportViewer1.Visible = false;
                    }
                    else
                    {
                        label3.Visible = false;
                        crystalReportViewer1.Visible = true;
                    }
                

                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                dateTimePicker1.Enabled = true;
            }
            else
            {
                dateTimePicker1.Enabled = false;
            }
        }

        private void monthCalendar1_DateChanged_1(object sender, DateRangeEventArgs e)
        {
            if (type == "tsales")
            {
                string query;
                {
                    StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                    line = sr.ReadLine();
                    StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                    dbP = sr3.ReadLine();
                    StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                    dbU = sr4.ReadLine();
                    string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                    MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                   // query = "SELECT total_trans_id, categ, item_name, quan, time_sum, item_id, sum_amount FROM totaltrans ORDER BY categ";
                    query = "SELECT        totaltrans.total_trans_id, totaltrans.categ, totaltrans.item_name, totaltrans.quan, totaltrans.time_sum, totaltrans.item_id, totaltrans.sum_amount, logs.names, logs.user_code, logs.userna, logs.eadd, logs.connum FROM    totaltrans, logs  WHERE time_sum  BETWEEN '" + calenMonth() + "/1" + "' AND '" + calenMonth() + "/30 23:59:59" + "' AND typex = '" + "month" + "' AND userna = '" + user + "' ORDER BY categ";
                    
                    dbFillPrint(query);
                    while (dbReader.Read())
                    {
                        break;
                    }
                    dbReader.Close();
                    dbConn.Close();


                }
            }
         
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                listBox1.Enabled = true;
                listBox2.Enabled = true;
            }
            else
            {
                listBox1.Enabled = false;
                listBox2.Enabled = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                listBox1.Enabled = true;
               
            }
            else
            {
                listBox1.Enabled = false;
               
            }
        }
        int lod = 0;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool mer = false;
            if (lod != 1)
            {

                if (type == "tsales")
                {
                    if (radioButton3.Checked == true)
                    {
                        string query;
                        {
                            StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                            line = sr.ReadLine();
                            StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                            dbP = sr3.ReadLine();
                            StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                            dbU = sr4.ReadLine();
                            string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                            MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                            query = " SELECT        totaltrans.total_trans_id, totaltrans.categ, totaltrans.item_name, totaltrans.quan, totaltrans.time_sum, totaltrans.item_id, totaltrans.sum_amount, totaltrans.typex,  logs.userna, logs.names, logs.addr, logs.connum, logs.eadd, itemlist.oprice, itemlist.unit, itemlist.srp FROM   (totaltrans INNER JOIN itemlist ON totaltrans.item_id = itemlist.item_no), logs WHERE time_sum  BETWEEN '" + calenYear() + "1/1" + "' AND '" + calenYear() + "12/31 23:59:59" + "' AND typex = '" + "annual" + "' AND userna = '" + user + "' ORDER BY categ , quan DESC";

                            //    query = "SELECT total_trans_id, categ, item_name, quan, time_sum, item_id, sum_amount FROM totaltrans WHERE time_sum  BETWEEN '" + calenYear() + "/1/1" + "' AND '" + calenYear() + "12/31 23:59:59" + "' AND typex = '" + "annual" + "' ORDER BY categ";
                            dbFillPrint(query);
                            while (dbReader.Read())
                            {
                                mer = true;
                            }
                            dbReader.Close();
                            dbConn.Close();


                        }
                        if (mer == false)
                        {
                            label3.Visible = true;
                            crystalReportViewer1.Visible = false;
                        }
                        else
                        {
                            label3.Visible = false;
                            crystalReportViewer1.Visible = true;
                        }
                    }
                }
                else if (type == "top")
                {
                    if (radioButton3.Checked == true)
                    {
                        string query; string getj = "";
                        int ranger = 0;
                        {
                            StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                            line = sr.ReadLine();
                            StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                            dbP = sr3.ReadLine();
                            StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                            dbU = sr4.ReadLine();
                            string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                            MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                            query = " SELECT      totaltrans.typex,  totaltrans.total_trans_id, totaltrans.categ, totaltrans.item_name, totaltrans.quan, totaltrans.time_sum, totaltrans.item_id, totaltrans.sum_amount, logs.names, logs.user_code, logs.userna, logs.eadd, logs.connum FROM    totaltrans, logs  WHERE  time_sum  BETWEEN '" + calenYear() + "/1/1" + "' AND '" + calenYear() + "12/31 23:59:59" + "'  AND typex = '" + "annual" + "' AND userna = '" + user + "' ORDER BY quan DESC";
                            dbFill(query);
                            while (dbReader.Read())
                            {
                                mer = true;
                                ranger++;
                                if (ranger == 10)
                                {
                                    getj = dbReader["quan"].ToString();
                                    break;
                                }
                            }
                            dbReader.Close();
                            dbConn.Close();


                        }
                        {
                            StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                            line = sr.ReadLine();
                            StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                            dbP = sr3.ReadLine();
                            StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                            dbU = sr4.ReadLine();
                            string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                            MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                            query = " SELECT      totaltrans.typex,  totaltrans.total_trans_id, totaltrans.categ, totaltrans.item_name, totaltrans.quan, totaltrans.time_sum, totaltrans.item_id, totaltrans.sum_amount, logs.names, logs.user_code, logs.userna, logs.eadd, logs.connum FROM    totaltrans, logs  WHERE  time_sum  BETWEEN '" + calenYear() + "/1/1" + "' AND '" + calenYear() + "12/31 23:59:59" + "'   AND typex = '" + "annual" + "' AND userna = '" + user + "' AND quan >= '" + getj + "'ORDER BY quan DESC";

                            //    query = "SELECT total_trans_id, categ, item_name, quan, time_sum, item_id, sum_amount FROM totaltrans WHERE time_sum  BETWEEN '" + calenYear() + "/1/1" + "' AND '" + calenYear() + "12/31 23:59:59" + "' AND typex = '" + "annual" + "' ORDER BY categ";
                            // dbFill(query);
                            dbFillPrint(query);
                            while (dbReader.Read())
                            {

                            }
                            dbReader.Close();
                            dbConn.Close();


                        }
                        ranger = 0;
                        getj = "";
                        if (mer == false)
                        {
                            label3.Visible = true;
                            crystalReportViewer1.Visible = false;
                        }
                        else
                        {
                            label3.Visible = false;
                            crystalReportViewer1.Visible = true;
                        }
                    }
                }

            }
           
            lod = 2;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool mer = false;
            if (type == "tsales")
            {
             
                if (radioButton2.Checked == true)
                {
                    string query;
                    {
                        StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                        line = sr.ReadLine();
                        StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                        dbP = sr3.ReadLine();
                        StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                        dbU = sr4.ReadLine();
                        string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                        MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                        query = "SELECT        totaltrans.total_trans_id, totaltrans.categ, totaltrans.item_name, totaltrans.quan, totaltrans.time_sum, totaltrans.item_id, totaltrans.sum_amount, totaltrans.typex,  logs.userna, logs.names, logs.addr, logs.connum, logs.eadd, itemlist.oprice, itemlist.unit, itemlist.srp FROM            (totaltrans INNER JOIN itemlist ON totaltrans.item_id = itemlist.item_no), logs  WHERE time_sum  BETWEEN '" + calenMonth() + "/1" + "' AND '" + calenMonth() + "/30 23:59:59" + "' AND typex = '" + "month" + "' AND userna = '" + user + "' ORDER BY categ";
                        dbFillPrint(query);
                        while (dbReader.Read())
                        {
                            mer = true;
                        }
                        dbReader.Close();
                        dbConn.Close();

                        if (mer == false)
                        {
                            label3.Visible = true;
                            crystalReportViewer1.Visible = false;
                        }
                        else
                        {
                            label3.Visible = false;
                            crystalReportViewer1.Visible = true;
                        }
                    }
                }
                else 
                {
                    string query;
                    {
                        StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                        line = sr.ReadLine();
                        StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                        dbP = sr3.ReadLine();
                        StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                        dbU = sr4.ReadLine();
                        string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                        MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                     /////   query = "SELECT total_trans_id, categ, item_name, quan, time_sum, item_id, sum_amount FROM totaltrans WHERE time_sum  BETWEEN '" + calenMonth() + "/1" + "' AND '" + calenMonth() + "/30 23:59:59" + "' AND typex = '" + "annual" + "' ORDER BY categ";
                        query = "SELECT        totaltrans.total_trans_id, totaltrans.categ, totaltrans.item_name, totaltrans.quan, totaltrans.time_sum, totaltrans.item_id, totaltrans.sum_amount, totaltrans.typex,  logs.userna, logs.names, logs.addr, logs.connum, logs.eadd, itemlist.oprice, itemlist.unit, itemlist.srp FROM            (totaltrans INNER JOIN itemlist ON totaltrans.item_id = itemlist.item_no), logs  WHERE time_sum  BETWEEN '" + calenYear() + "/1/1" + "' AND '" + calenYear() + "12/31 23:59:59" + "' AND typex = '" + "annual" + "' AND userna = '" + user + "' ORDER BY categ";
                  
                        dbFillPrint(query);
                        while (dbReader.Read())
                        {
                            break;
                        }
                        dbReader.Close();
                        dbConn.Close();


                    }
                }
            }
            else if (type == "top")
            {
                if (radioButton2.Checked == true)
                {
                    string query; string getj = "";
                    int ranger = 0;
                    {
                        StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                        line = sr.ReadLine();
                        StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                        dbP = sr3.ReadLine();
                        StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                        dbU = sr4.ReadLine();
                        string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                        MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                        query = " SELECT      totaltrans.typex,  totaltrans.total_trans_id, totaltrans.categ, totaltrans.item_name, totaltrans.quan, totaltrans.time_sum, totaltrans.item_id, totaltrans.sum_amount, logs.names, logs.user_code, logs.userna, logs.eadd, logs.connum FROM    totaltrans, logs  WHERE time_sum  BETWEEN '" + calenMonth() + "/1" + "' AND '" + calenMonth() + "/30 23:59:59" + "' AND typex = '" + "month" + "' AND userna = '" + user + "' ORDER BY quan DESC";
                        dbFill(query);
                        while (dbReader.Read())
                        {
                            mer = true;
                            ranger++;
                            if (ranger == 10)
                            {
                                getj = dbReader["quan"].ToString();
                                break;
                            }
                        }
                        dbReader.Close();
                        dbConn.Close();


                    }
                    {
                        StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                        line = sr.ReadLine();
                        StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                        dbP = sr3.ReadLine();
                        StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                        dbU = sr4.ReadLine();
                        string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                        MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                        query = " SELECT     totaltrans.typex,   totaltrans.total_trans_id, totaltrans.categ, totaltrans.item_name, totaltrans.quan, totaltrans.time_sum, totaltrans.item_id, totaltrans.sum_amount, logs.names, logs.user_code, logs.userna, logs.eadd, logs.connum FROM    totaltrans, logs  WHERE time_sum  BETWEEN '" + calenMonth() + "/1" + "' AND '" + calenMonth() + "/30 23:59:59" + "'  AND typex = '" + "month" + "' AND userna = '" + user + "' AND quan >= '" + getj + "'ORDER BY quan DESC";

                        //    query = "SELECT total_trans_id, categ, item_name, quan, time_sum, item_id, sum_amount FROM totaltrans WHERE time_sum  BETWEEN '" + calenYear() + "/1/1" + "' AND '" + calenYear() + "12/31 23:59:59" + "' AND typex = '" + "annual" + "' ORDER BY categ";
                        // dbFill(query);
                        dbFillPrint(query);
                        while (dbReader.Read())
                        {

                        }
                        dbReader.Close();
                        dbConn.Close();


                    }
                    ranger = 0;
                    getj = "";
                    if (mer == false)
                    {
                        label3.Visible = true;
                        crystalReportViewer1.Visible = false;
                    }
                    else
                    {
                        label3.Visible = false;
                        crystalReportViewer1.Visible = true;
                    }
                }
            }
        }
     
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                string query = "";
                StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                line = sr.ReadLine();
                StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                dbP = sr3.ReadLine();
                StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                dbU = sr4.ReadLine();
                string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                query = "SELECT        security.ids, security.notes, security.dates,security.term, security.users, logs.names, logs.userna, logs.user_code, logs.connum, logs.eadd FROM    security, logs WHERE userna = '" + user + "' AND term = '" + comboBox1.Text + "' ORDER BY dates DESC";
                dbFillPrint(query);
                while (dbReader.Read())
                {

                }
                dbReader.Close();
                dbConn.Close();


            }
        }
    }
}