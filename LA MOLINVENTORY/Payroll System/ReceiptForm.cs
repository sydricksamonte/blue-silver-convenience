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
    public partial class ReceiptForm : Form
    {
        string rubik;
        string user;
        string type;
        public ReceiptForm(string a, string b, string c)
        {

            InitializeComponent();
            rubik = a;
            user = b;
            type = c;
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

            ItemsReceipt ds = new ItemsReceipt();
            adapter.Fill(ds.Tables[0]);
            if (type == "rec")
            {
                cryRpt.Load(Application.StartupPath.ToString() + "//Reports/Receipt.rpt");
            }
            else
            {
                cryRpt.Load(Application.StartupPath.ToString() + "//Reports/ReceiptVoid.rpt");
            }
            cryRpt.SetDataSource(ds.Tables[0]);

            crystalReportViewer1.ReportSource = cryRpt;

            crystalReportViewer1.RefreshReport();
            cryRpt.PrintToPrinter(1, false, 1, 1);
        }

        private void ReceiptForm_Load(object sender, EventArgs e)
        {
           // MessageBox.Show(rubik);
            if (type == "rec")
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
                    query = "SELECT        trans_items.trans_item_id, trans_items.item_id, trans_items.item_name, trans_items.trans_id, trans_items.quan, trans_items.sum_amount, logs.names,  transaction.dat_trans, logs.userna, trans_misc.change, trans_misc.payment, itemlist.srp FROM   ((((trans_items INNER JOIN transaction ON trans_items.trans_id = transaction.trans_id) INNER JOIN logs ON transaction.user_code = logs.userna) INNER JOIN  trans_misc ON trans_items.trans_id = trans_misc.trans_id AND transaction.trans_id = trans_misc.trans_id) INNER JOIN itemlist ON trans_items.item_id = itemlist.item_no) WHERE transaction.trans_id = '" + rubik + "'";
                    dbFillPrint(query);
                    while (dbReader.Read())
                    {

                    }
                    dbReader.Close();
                    dbConn.Close();


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
                    query = "SELECT        trans_items.trans_item_id, trans_items.item_id, trans_items.item_name, trans_items.trans_id, trans_items.quan, trans_items.sum_amount, logs.names,  transaction.dat_trans, logs.userna, trans_misc.change, trans_misc.payment, itemlist.srp FROM   ((((trans_items INNER JOIN transaction ON trans_items.trans_id = transaction.trans_id) INNER JOIN logs ON transaction.user_code = logs.userna) INNER JOIN  trans_misc ON trans_items.trans_id = trans_misc.trans_id AND transaction.trans_id = trans_misc.trans_id) INNER JOIN itemlist ON trans_items.item_id = itemlist.item_no) WHERE transaction.trans_id = '" + rubik + "'";
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
}