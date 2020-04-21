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
    public partial class Ticket : Form
    {
        public SqlConnection DBConnection;
        private DataTable dishTable;
        private DataTable recipeTable;
        public Ticket(SqlConnection newConnection)
        {
            InitializeComponent();
            this.DBConnection = newConnection;
            dishTable = new DataTable();
            ticketGridView.DataSource = dishTable;
            totalTextBox.Text = "0";
            subtotalTextBox.Text = "0";
            dishTable.Columns.Add("DishID", typeof(int));
            dishTable.Columns.Add("Name", typeof(String));
            dishTable.Columns.Add("Price", typeof(decimal));
            dishTable.Columns.Add("Quantity", typeof(int));

            //decimal subTotal = 0;
            //decimal total = 0;

            dishTable.RowDeleted += new DataRowChangeEventHandler((x,y) => 
            {
                //subtotalTextBox.Text = y.Row[3].ToString();
            });

        }

        private void Ticket_Load(object sender, EventArgs e)
        {
            SqlCommand cmdLoadItems = DBConnection.CreateCommand();
            cmdLoadItems.CommandText = "SELECT name FROM Dishes";
            SqlDataReader reader = cmdLoadItems.ExecuteReader();

            while (reader.Read())
            {
                dishCombo.Items.Add(reader[0].ToString());
            }
            reader.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            SqlCommand cmdGetDishInfo = DBConnection.CreateCommand();
            cmdGetDishInfo.CommandText = "SELECT DishID, Name, Price FROM Dishes WHERE Name = @name";
            cmdGetDishInfo.Parameters.AddWithValue("@name", dishCombo.Text);
            SqlDataReader reader = cmdGetDishInfo.ExecuteReader();

            while (reader.Read())
            {
                DataRow row = dishTable.NewRow();
                row.BeginEdit();
                row[0] = reader[0];
                row[1] = reader[1];
                row[2] = reader[2];
                row[3] = quantityNumericUpDown.Value;
                dishTable.Rows.Add(row);
                subtotalTextBox.Text = (decimal.Parse(subtotalTextBox.Text) + (decimal.Parse(reader[2].ToString()) * quantityNumericUpDown.Value)).ToString();
                totalTextBox.Text = (decimal.Parse(subtotalTextBox.Text) + tipNumericUpDown.Value).ToString();
            }
            dishTable.AcceptChanges();

            reader.Close();
            dishCombo.Text = "";
            quantityNumericUpDown.Value = 0;

            
        }
        
        private void dishCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void submitBtn_Click(object sender, EventArgs e)
        {

            submitTicket();
            submitTicketDishes();

            MessageBox.Show("Ticket was Submitted");
            dishTable.Clear();
            dishCombo.Text = "";
            subtotalTextBox.Text = "0";
            totalTextBox.Text = "";
            tipNumericUpDown.Value = 0;
            quantityNumericUpDown.Value = 0;

        }

        private void submitTicket()
        {
            SqlCommand cmdInsertTicket = DBConnection.CreateCommand();
            cmdInsertTicket.CommandText = "INSERT Into Ticket (Date, Subtotal, Tip , Total) Values (@date,@subtotal,@tip,@total)";
            cmdInsertTicket.Parameters.AddWithValue("@date", dateTimePickerTicket.Value);
            cmdInsertTicket.Parameters.AddWithValue("@subtotal", subtotalTextBox.Text);
            cmdInsertTicket.Parameters.AddWithValue("@tip", tipNumericUpDown.Value);
            cmdInsertTicket.Parameters.AddWithValue("@total", totalTextBox.Text);
            cmdInsertTicket.ExecuteNonQuery();
        }

        private void submitTicketDishes()
        {
            SqlCommand cmdGetTicketID = DBConnection.CreateCommand();
            cmdGetTicketID.CommandText = "Select MAX(TicketID) FROM Ticket";
            SqlDataReader reader = cmdGetTicketID.ExecuteReader();

            if (reader.Read())
            {
                int TicketID = int.Parse(reader[0].ToString());
                decimal expense = 0;

                reader.Close();

                for (int i = 0; i < dishTable.Rows.Count; i++)
                {
                    DataRow row = dishTable.Rows[i];
                    int dishID = int.Parse(row[0].ToString());
                    int dishQuantity = int.Parse(row[3].ToString());

                    

                    SqlCommand cmdInsertTDish = DBConnection.CreateCommand();
                    cmdInsertTDish.CommandText = "INSERT Into TICKET_DISHES (TicketID,DishID,Quantity) Values(@ticketId,@dishId,@quantity)";
                    cmdInsertTDish.Parameters.AddWithValue("@ticketId", TicketID);
                    cmdInsertTDish.Parameters.AddWithValue("@dishId", dishID);
                    cmdInsertTDish.Parameters.AddWithValue("@quantity", dishQuantity);
                    cmdInsertTDish.ExecuteNonQuery();

                    

                    SqlCommand cmdGetPrice = DBConnection.CreateCommand();
                    cmdGetPrice.CommandText = "SELECT SUM(ItemPrice) FROM(SELECT(SUM(Items.Price) * Recipes.Quantity) AS ItemPrice FROM ITEMS JOIN RECIPES ON ITEMS.ItemID = RECIPES.ItemID JOIN DISHES ON DISHES.DishID = RECIPES.DishID WHERE RECIPES.DishID = @dishId GROUP BY Items.ItemID, RECIPES.Quantity) A";
                    cmdGetPrice.Parameters.AddWithValue("@dishId", dishID);
                    SqlDataReader reader2 = cmdGetPrice.ExecuteReader();                  

                    if (reader2.Read())
                    {
                        expense += decimal.Parse(reader2[0].ToString()) * dishQuantity;
                    }
                    reader2.Close();
                    deductFromInventory(dishID, dishQuantity);
                    
                }

                SqlCommand cmdSetExpense = DBConnection.CreateCommand();
                cmdSetExpense.CommandText = "UPDATE TICKET set Expense = @expense where TicketID = @ticketId";
                cmdSetExpense.Parameters.AddWithValue("@expense", expense);
                cmdSetExpense.Parameters.AddWithValue("@ticketId", TicketID);
                cmdSetExpense.ExecuteNonQuery();

            }
        }

        public void deductFromInventory(int dishID, int dishQuantity){

            recipeTable = new DataTable();
            recipeTable.Columns.Add("ItemID", typeof(int));
            recipeTable.Columns.Add("Quantity", typeof(decimal));

            SqlCommand cmdGetRecipeItems = DBConnection.CreateCommand();
            cmdGetRecipeItems.CommandText = "SELECT ItemID, Quantity FROM RECIPES where DishID = @dishId";
            cmdGetRecipeItems.Parameters.AddWithValue("@dishId", dishID);
            SqlDataReader reader = cmdGetRecipeItems.ExecuteReader();

            while (reader.Read())
            {
                DataRow row = recipeTable.NewRow();
                row.BeginEdit();
                row[0] = reader[0];
                row[1] = reader[1];

                recipeTable.Rows.Add(row);
            }
            recipeTable.AcceptChanges();
            reader.Close();

            for (int i = 0; i < dishQuantity; i++)
            {
                for (int j = 0; j < recipeTable.Rows.Count; j++)
                {
                    DataRow row = recipeTable.Rows[j];

                    SqlCommand cmdDeductExpected = DBConnection.CreateCommand();
                    cmdDeductExpected.CommandText = "UPDATE ACTUAL_INVENTORY SET ExpectedQuantity = ExpectedQuantity - @quantity WHERE InvID = (SELECT min(InvID) FROM ACTUAL_INVENTORY WHERE ItemID = @itemId)";
                    cmdDeductExpected.Parameters.AddWithValue("@itemId", row[0]);
                    cmdDeductExpected.Parameters.AddWithValue("@quantity", row[1]);
                    cmdDeductExpected.ExecuteNonQuery();                    

                }
            }
           
        }

        private void tipNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            totalTextBox.Text = (decimal.Parse(subtotalTextBox.Text) + tipNumericUpDown.Value).ToString();
        }
    }
}
