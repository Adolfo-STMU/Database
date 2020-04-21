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
    public partial class Items : Form
    {
        public SqlConnection DBConnection;
        public Items(SqlConnection newConnection)
        {
            InitializeComponent();
            this.DBConnection = newConnection;
        }


        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void itemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmdGetItemDetails = DBConnection.CreateCommand();
            cmdGetItemDetails.CommandText = "SELECT ItemID FROM Items WHERE Name = @name";
            cmdGetItemDetails.Parameters.AddWithValue("@name", itemComboBox.SelectedItem);
            SqlDataReader reader = cmdGetItemDetails.ExecuteReader();
            int id = 0;
            if (reader.Read())
            {
                id = (int)reader[0];
                IDTextBox.Text = reader[0].ToString();
            }
            reader.Close();
            SqlCommand cmdItemDetails = DBConnection.CreateCommand();
            cmdItemDetails.CommandText = "SELECT * FROM Items WHERE ItemID = @id";
            cmdItemDetails.Parameters.AddWithValue("@id", id);
            SqlDataReader reader2 = cmdItemDetails.ExecuteReader();
            if (reader2.Read())
            {
                priceNumericUpDown.Value = (decimal)reader2[2];
                
                measurementTextBox.Text = reader2[3].ToString();
                shelfLifeNnumericUpDown.Value = Convert.ToDecimal((int)reader2[4]);
            }
            reader2.Close();
        }

        private void Items_Load(object sender, EventArgs e)
        {
            SqlCommand cmdLoadItems = DBConnection.CreateCommand();
            cmdLoadItems.CommandText = "SELECT name FROM ITEMS";
            SqlDataReader reader = cmdLoadItems.ExecuteReader();

            while (reader.Read())
            {
                itemComboBox.Items.Add(reader[0].ToString());
            }
            reader.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddItem frm = new AddItem(DBConnection);
            frm.FormClosed += new FormClosedEventHandler((x, y) => { loadItemNames(); });
            frm.ShowDialog();

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            SqlCommand cmdDeleteItems = DBConnection.CreateCommand();
            cmdDeleteItems.CommandText = "DELETE From Items WHERE ItemID = @id";

            cmdDeleteItems.Parameters.AddWithValue("@id", int.Parse(IDTextBox.Text));
            SqlDataReader reader = cmdDeleteItems.ExecuteReader();
            /*
            int max = int.Parse(IDTextBox.Text)-1;
            cmdLoadItems.Parameters.AddWithValue("@max", max);
            cmdLoadItems.CommandText = "DBCC CHECKIDENT('RestaurantDB.dbo.Items', RESEED, @max)";
            reader.Close();*/
            reader.Close();
            MessageBox.Show("DELETE SUCCESSFUL");

            loadItemNames();

            //TODO:Reset Autoincrement
        }

        private void loadItemNames()
        {
            SqlCommand cmdLoadItems = DBConnection.CreateCommand();
            cmdLoadItems.CommandText = "SELECT name FROM ITEMS";
            SqlDataReader reader2 = cmdLoadItems.ExecuteReader();

            itemComboBox.Items.Clear();

            while (reader2.Read())
            {
                itemComboBox.Items.Add(reader2[0].ToString());
            }
            reader2.Close();
            itemComboBox.Text = "";
            priceNumericUpDown.Value = 0;
            
            measurementTextBox.Text = "";
            shelfLifeNnumericUpDown.Value = 0;
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            //TODO: Update actual inventory in database
            SqlCommand cmdLoadItems = DBConnection.CreateCommand();
            cmdLoadItems.CommandText = "UPDATE Items SET Price = @newP, MeasurementUnit = @MeasureU,ShelfLife =@newShelf WHERE ItemID = @id";
            cmdLoadItems.Parameters.AddWithValue("@newP", priceNumericUpDown.Value);
            
            cmdLoadItems.Parameters.AddWithValue("@MeasureU", measurementTextBox.Text);
            cmdLoadItems.Parameters.AddWithValue("@newShelf", shelfLifeNnumericUpDown.Value);
            cmdLoadItems.Parameters.AddWithValue("@id", int.Parse(IDTextBox.Text));
            SqlDataReader reader = cmdLoadItems.ExecuteReader();
            reader.Close();
            MessageBox.Show("UPDATE SUCCESSFUL");

        }
    }
}
