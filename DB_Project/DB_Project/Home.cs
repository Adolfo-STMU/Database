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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                sqlConnection1.Open();
                //MessageBox.Show("DB Connection Opened");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("The App cannot open the connection to the database");
                MessageBox.Show(ex.Message);
            }
        }

        private void inventoryBtn_Click(object sender, EventArgs e)
        {
            Inventory frm = new Inventory(sqlConnection1);
            frm.ShowDialog();
        }
        
        private void itemsBtn_Click(object sender, EventArgs e)
        {
            Items frm = new Items(sqlConnection1);
            frm.ShowDialog();
        }

        private void dishesBtn_Click(object sender, EventArgs e)
        {
            DishesAndRecipes frm = new DishesAndRecipes(sqlConnection1);
            frm.ShowDialog();
        }

        private void ticketBtn_Click(object sender, EventArgs e)
        {
            Ticket frm = new Ticket(sqlConnection1);
            frm.ShowDialog();
        }

        private void reportBtn_Click(object sender, EventArgs e)
        {
            Report frm = new Report(sqlConnection1);
            frm.ShowDialog();
        }

        
    }
}
