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
    public partial class AddItem : Form
    {
        public SqlConnection DBConnection;
        public AddItem(SqlConnection newConnection)
        {
            InitializeComponent();
            DBConnection = newConnection;
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
   
                SqlCommand cmdInserItem = DBConnection.CreateCommand();
                cmdInserItem.CommandText = "INSERT into ITEMS (Name, Price, MeasurementUnit, ShelfLife) VALUES (@name, @price, @measurementUnit, @shelfLife)";
                cmdInserItem.Parameters.AddWithValue("@name", itemNameTextBox.Text);
                cmdInserItem.Parameters.AddWithValue("@price", priceNumericUpDown.Value);
                
                cmdInserItem.Parameters.AddWithValue("@measurementUnit", measurementTextBox.Text);
                cmdInserItem.Parameters.AddWithValue("@shelfLife", shelfLifeNnumericUpDown.Value);
                cmdInserItem.ExecuteNonQuery();

                MessageBox.Show("INSERT SUCCESSFUL");
            }
            catch (Exception ex)
            {
                MessageBox.Show("INSERT FAILED: " + ex.Message);
            }
            this.Close();
        }
    }
}
