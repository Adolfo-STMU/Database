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
    public partial class Inventory : Form
    {
        public SqlConnection DBConnection;
        private DataTable table;
        public Inventory(SqlConnection newConnection)
        {
            InitializeComponent();
            this.DBConnection = newConnection;
            table = new DataTable();
            inventoryGrid.DataSource = table;
            loadInvItems();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            table.Clear();
            SqlCommand cmdLoadInvItems = DBConnection.CreateCommand();
            cmdLoadInvItems.CommandText = "select InvID, Name, ActualQuantity, DatePurchased FROM ITEMS join ACTUAL_INVENTORY on ITEMS.ItemID = ACTUAL_INVENTORY.ItemID where Name like @name";
            cmdLoadInvItems.Parameters.AddWithValue("@name", "%"+searchBox.Text+"%");
            SqlDataReader reader = cmdLoadInvItems.ExecuteReader();
            table.Load(reader);
            reader.Close();
        }

        private void loadInvItems()
        {
            table.Clear();
            SqlCommand cmdLoadInvItems = DBConnection.CreateCommand();
            cmdLoadInvItems.CommandText = "SELECT InvID, Name, ActualQuantity, DatePurchased FROM ITEMS join ACTUAL_INVENTORY on ITEMS.ItemID = ACTUAL_INVENTORY.ItemID";
            SqlDataReader reader = cmdLoadInvItems.ExecuteReader();

            table.Load(reader);
            
            reader.Close();
        }

        private void inventoryGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRow[] rows = table.Select();
            if (e.RowIndex >= 0)
            {
                InvIDTextBox.Text = rows[e.RowIndex].Field<int>("InvID").ToString();
                ItemNameTextBox.Text = rows[e.RowIndex].Field<String>("Name");
                //quantityUpDown.Value = rows[e.RowIndex].Field<decimal>("Quantity");
            }

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            SqlCommand cmdLoadInvItems = DBConnection.CreateCommand();
            cmdLoadInvItems.CommandText = "UPDATE Actual_Inventory SET ActualQuantity = @currentQty WHERE InvID = @id";
            cmdLoadInvItems.Parameters.AddWithValue("@currentQty", quantityUpDown.Value);
            cmdLoadInvItems.Parameters.AddWithValue("@id", int.Parse(InvIDTextBox.Text));
            SqlDataReader reader2 = cmdLoadInvItems.ExecuteReader();
            reader2.Close();

            loadInvItems();
            MessageBox.Show("UPDATE SUCCESSFUL");
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddInv addInvFrm = new AddInv(DBConnection);
            addInvFrm.FormClosed += new FormClosedEventHandler((x,y)=> { loadInvItems(); });
            addInvFrm.ShowDialog();
        }

        private void inventoryGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void quantityUpDown_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
