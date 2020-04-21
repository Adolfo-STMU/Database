using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DB_Project
{
    public partial class Report : Form
    {
        public SqlConnection DBConnection;
        private DataTable reportDataTable;
        public Report(SqlConnection newConnection)
        {
            InitializeComponent();
            this.DBConnection = newConnection;
            reportDataTable = new DataTable();
            reportDataTable.Columns.Add("ItemID", typeof(int));
            reportDataTable.Columns.Add("ItemName", typeof(String));
            reportDataTable.Columns.Add("DatePurchased", typeof(String));
            reportDataTable.Columns.Add("Unit", typeof(String));
            reportDataTable.Columns.Add("ActualAmount", typeof(decimal));
            reportDataTable.Columns.Add("ExpectedAmount", typeof(decimal));
            reportDataTable.Columns.Add("Discrepency", typeof(decimal));
            reportDataTable.Columns.Add("MonetaryLoss", typeof(decimal));

            reportGridView.DataSource = reportDataTable;
        }

        private void Report_Load(object sender, EventArgs e)
        {
            calculateRevenue();
            fillReportGrid();
            calculateNetLosses();
            calculateExpectedProfit();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {

        }

        private void calculateRevenue()
        {
            SqlCommand revenueGet = DBConnection.CreateCommand();
            revenueGet.CommandText = "SELECT SUM(Total) FROM Ticket";
            SqlDataReader reader = revenueGet.ExecuteReader();
            if (reader.Read()){
                revenueTextBox.Text = reader[0].ToString();
            }
            reader.Close();
        }

        //Aggregage price of items per ticket per recipe per dish + manual losses in inventory
        private void calculateNetLosses()
        {
            decimal netLoss = 0;
            foreach(DataRow row in reportDataTable.Rows)
            {
                netLoss += decimal.Parse(row[7].ToString());
            }
            netLossText.Text = netLoss.ToString();
        }

        private void calculateExpectedProfit()
        {
            decimal summedExpense = 0;
            SqlCommand cmdSumExpectedExpense = DBConnection.CreateCommand();
            cmdSumExpectedExpense.CommandText = "SELECT SUM(Expense) FROM Ticket";
            SqlDataReader reader = cmdSumExpectedExpense.ExecuteReader();
            if (reader.Read())
            {
                summedExpense = decimal.Parse(reader[0].ToString());
            }
            profitTextBox.Text = (decimal.Parse(revenueTextBox.Text) - summedExpense).ToString();
        }

        private void fillReportGrid()
        {
            SqlCommand cmdFillReport = DBConnection.CreateCommand();
            cmdFillReport.CommandText = "SELECT Items.ItemID, Items.Name, DatePurchased, MeasurementUnit, ActualQuantity, ExpectedQuantity, Price FROM Actual_Inventory JOIN Items ON Actual_Inventory.ItemID = Items.ItemID";
            SqlDataReader reader = cmdFillReport.ExecuteReader();

            while (reader.Read())
            {
                DataRow row = reportDataTable.NewRow();
                row.BeginEdit();
                row[0] = reader[0];
                row[1] = reader[1];
                row[2] = reader[2];
                row[3] = reader[3];
                row[4] = reader[4];
                row[5] = reader[5];
                row[6] = decimal.Parse(reader[4].ToString()) - decimal.Parse(reader[5].ToString());
                row[7] = decimal.Parse(reader[6].ToString()) * decimal.Parse(row[6].ToString());
                reportDataTable.Rows.Add(row);
            }
            reportDataTable.AcceptChanges();

            reader.Close();
        }
    }
}
