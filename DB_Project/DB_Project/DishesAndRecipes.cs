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
   
    public partial class DishesAndRecipes : Form
    {
        public SqlConnection DBConnection;
        private DataTable table;
        public DishesAndRecipes(SqlConnection newConnection)
        {
            InitializeComponent();
            this.DBConnection = newConnection;
            table = new DataTable();
            dishRecipeGridView.DataSource = table;
        }

        

        private void addBtm_Click(object sender, EventArgs e)
        {
            NewDish frm = new NewDish(DBConnection);
            frm.FormClosed += new FormClosedEventHandler((x, y) => { loadRecipeNames(); });
            frm.ShowDialog();
        }

        private void DishesAndRecipes_Load(object sender, EventArgs e)
        {
            loadRecipeNames();
        }

        private void loadRecipeNames()
        {
            dishComboBox.Items.Clear();
            SqlCommand cmdLoadDishes = DBConnection.CreateCommand();
            cmdLoadDishes.CommandText = "SELECT Name FROM Dishes";
            SqlDataReader reader = cmdLoadDishes.ExecuteReader();

            while (reader.Read())
            {
                dishComboBox.Items.Add(reader[0].ToString());
            }
            reader.Close();
        }

        private void dishComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            table.Clear();
            SqlCommand cmdGetDishID = DBConnection.CreateCommand();
            cmdGetDishID.CommandText = "SELECT DishID FROM Dishes WHERE Name = @name";
            cmdGetDishID.Parameters.AddWithValue("@name", dishComboBox.SelectedItem);
            SqlDataReader reader = cmdGetDishID.ExecuteReader();
            int id = 0;
            if (reader.Read())
            {
                id = (int)reader[0];
                
            }
            reader.Close();
            SqlCommand cmdLoadRecipe = DBConnection.CreateCommand();
            cmdLoadRecipe.CommandText = "SELECT ITEMS.name, MeasurementUnit, Quantity FROM ITEMS join RECIPES on ITEMS.ItemID = RECIPES.ItemID join DISHES on DISHES.DishID = RECIPES.DishID Where RECIPES.DishID = @id";
            cmdLoadRecipe.Parameters.AddWithValue("@id", id);
            SqlDataReader reader2 = cmdLoadRecipe.ExecuteReader();

            table.Load(reader2);

            reader2.Close();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            SqlCommand cmdDeleteDish = DBConnection.CreateCommand();
            cmdDeleteDish.CommandText = "DELETE from DISHES where Name = @name";
            cmdDeleteDish.Parameters.AddWithValue("@name", dishComboBox.SelectedItem);
            SqlDataReader reader = cmdDeleteDish.ExecuteReader();
            reader.Close();

            dishComboBox.Text = "";
            loadRecipeNames();
            table.Clear();
        }
    }
}
