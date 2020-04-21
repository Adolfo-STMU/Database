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
    public partial class NewDish : Form
    {
        public SqlConnection DBConnection;
        public DataTable recipeTable;
        public NewDish(SqlConnection newConnection)
        {
            InitializeComponent();
            DBConnection = newConnection;
            recipeTable = new DataTable();
            recipeGridView.DataSource = recipeTable;
            typeCombo.Items.Add("Breakfast");
            typeCombo.Items.Add("Lunch");
            typeCombo.Items.Add("Dinner");
        }

        private void typeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void AddDishBtn_Click(object sender, EventArgs e)
        {
            SqlCommand cmdInserDish = DBConnection.CreateCommand();
            cmdInserDish.CommandText = "INSERT into DISHES (Name, Price,Type) VALUES (@dname, @price, @type)";
            cmdInserDish.Parameters.AddWithValue("@dname", dishNameTextBox.Text);
            cmdInserDish.Parameters.AddWithValue("@price", priceNumericUpDown.Value);
            cmdInserDish.Parameters.AddWithValue("@type", typeCombo.Text);
            cmdInserDish.ExecuteNonQuery();

            MessageBox.Show("INSERT SUCCESSFUL");

            SqlCommand cmdGetDishID = DBConnection.CreateCommand();
            cmdGetDishID.CommandText = "SELECT DishID FROM DISHES Where Name = @name";
            cmdGetDishID.Parameters.AddWithValue("@name", dishNameTextBox.Text);
            SqlDataReader reader = cmdGetDishID.ExecuteReader();
            if (reader.Read())
            {
                dishIDTextBox.Text = reader[0].ToString();
            }
            reader.Close();

        }

        private void dishIDTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void NewDish_Load(object sender, EventArgs e)
        {
            SqlCommand cmdLoadItems = DBConnection.CreateCommand();
            cmdLoadItems.CommandText = "SELECT name FROM ITEMS";
            SqlDataReader reader = cmdLoadItems.ExecuteReader();

            while (reader.Read())
            {
                itemsCombo.Items.Add(reader[0].ToString());
            }
            reader.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                String id;
                SqlCommand cmdGetID = DBConnection.CreateCommand();
                cmdGetID.CommandText = "SELECT ItemID FROM Items WHERE Name = @name";
                cmdGetID.Parameters.AddWithValue("@name", itemsCombo.SelectedItem);
                SqlDataReader reader = cmdGetID.ExecuteReader();
                if (reader.Read())
                {
                    id = reader[0].ToString();
                    reader.Close();
                    SqlCommand cmdAddRecipe = DBConnection.CreateCommand();
                    cmdAddRecipe.CommandText = "INSERT INTO RECIPES (ItemID, DishID, Quantity) VALUES (@itemid, @dishid, @qty)";
                    cmdAddRecipe.Parameters.AddWithValue("@itemid", id);
                    cmdAddRecipe.Parameters.AddWithValue("@dishid", dishIDTextBox.Text);
                    cmdAddRecipe.Parameters.AddWithValue("@qty", quantityNumericUpDown.Value);
                    cmdAddRecipe.ExecuteNonQuery();
                }
                else
                {
                    throw new Exception("Item Not Found");
                }
                reader.Close();
                MessageBox.Show("INSERT SUCCESSFUL");
            }
            catch (Exception ex)
            {
                MessageBox.Show("INSERT FAILED: " + ex.Message);
            }

            recipeTable.Clear();
            SqlCommand cmdFillGrid = DBConnection.CreateCommand();
            cmdFillGrid.CommandText = "SELECT ITEMS.Name, MeasurementUnit, Quantity FROM ITEMS join RECIPES on ITEMS.ItemID = RECIPES.ItemID where DishID = @dishid";
            cmdFillGrid.Parameters.AddWithValue("@dishid", dishIDTextBox.Text);
            SqlDataReader reader2 = cmdFillGrid.ExecuteReader();
            recipeTable.Load(reader2);
            reader2.Close();
        }

        private void subBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("New Dish and Recipe Submitted!");
            this.Close();
               
        }

        private void itemsCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmdGetUnit = DBConnection.CreateCommand();
            cmdGetUnit.CommandText = "SELECT MeasurementUnit FROM ITEMS where Name = @name";
            cmdGetUnit.Parameters.AddWithValue("@name", itemsCombo.Text);
            SqlDataReader reader = cmdGetUnit.ExecuteReader();
           if (reader.Read())
            {
                unitBox.Text = reader[0].ToString();
            }

            reader.Close();
        }
    }
}
