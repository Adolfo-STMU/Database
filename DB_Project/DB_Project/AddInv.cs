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
    public partial class AddInv : Form
    {
        public SqlConnection DBConnection;
        public AddInv(SqlConnection newConnection)
        {
            InitializeComponent();
            DBConnection = newConnection;
        }

        private void AddInv_Load(object sender, EventArgs e)
        {
            SqlCommand cmdLoadItems = DBConnection.CreateCommand();
            cmdLoadItems.CommandText = "SELECT name FROM ITEMS";
            SqlDataReader reader = cmdLoadItems.ExecuteReader();
           
            while (reader.Read())
            {
                itemNameCombo.Items.Add(reader[0].ToString());
            }
            reader.Close();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                String id;
                SqlCommand cmdGetID = DBConnection.CreateCommand();
                cmdGetID.CommandText = "SELECT ItemID FROM Items WHERE Name = @name";
                cmdGetID.Parameters.AddWithValue("@name", itemNameCombo.SelectedItem);
                SqlDataReader reader = cmdGetID.ExecuteReader();
                if (reader.Read())
                {
                    id = reader[0].ToString();
                    reader.Close();
                    SqlCommand cmdInsertInv = DBConnection.CreateCommand();
                    cmdInsertInv.CommandText = "INSERT into ACTUAL_INVENTORY (ItemID, ActualQuantity, ExpectedQuantity, DatePurchased) VALUES (@id, @qty, @qty, @date)";
                    cmdInsertInv.Parameters.AddWithValue("@id", id);
                    cmdInsertInv.Parameters.AddWithValue("@qty", quantityNumericUpDown.Value);
                    cmdInsertInv.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                    cmdInsertInv.ExecuteNonQuery();

                }
                else
                {
                    throw new Exception("Item Not Found");
                }
                reader.Close();
                MessageBox.Show("INSERT SUCCESSFUL");
            }
            catch(Exception ex)
            {
                MessageBox.Show("INSERT FAILED: " + ex.Message);
            }
            this.Close();
        }

        private void itemNameCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void quantityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void quantityLabel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void nameLabel_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
