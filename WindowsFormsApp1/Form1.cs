using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace WindowsFormsApp1
{
    

   

    public partial class Form1 : Form
    {
        public List<Customer> CustomersList {  get; set; }
        public Form1()
        {
            CustomersList = GetCustomers();
            InitializeComponent();
            customerDataGrid.DataSource = CustomersList;
        }

        private List<Customer> GetCustomers()
        {
            List<Customer> newCustomerList = new List<Customer>();
            newCustomerList.Add(new Customer(101, "Frames Ltd", "07456546456", "13 Barnsley Road, WF92LD, Pontefract", "frames@gmail.com"));
            newCustomerList.Add(new Customer(102, "Barabash", "7845654654", "52 Peackock Crescent, LS113LS, Leeds", "barabash@gmail.com"));
            newCustomerList.Add(new Customer(103, "Galagan", "786943513413", "12 Harness Hill, WF32LP, Stanley", "galagan@outlook.com"));
            return newCustomerList;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            customerDataGrid.DataSource = this.CustomersList;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            stockPanel.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Hide();

        }

        private void customersPanel_Paint(object sender, PaintEventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedCustomer = customerDataGrid.SelectedRows[0].DataBoundItem as Customer;
            customerNameTxtbox.Text = selectedCustomer.Name;
            customerPhoneTxtbox.Text = selectedCustomer.Phone;
            customerEmailTxtbox.Text = selectedCustomer.Email;  
            customerAddressTxtbox.Text = selectedCustomer.Address;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_2(object sender, EventArgs e)
        {

        }

        private void customerAddClick(object sender, EventArgs e)
        {
            int lastID = CustomersList.Last().ID + 1;
            CustomersList.Add(new Customer(
                lastID,
                customerNameTxtbox.Text,
                customerPhoneTxtbox.Text,
                customerEmailTxtbox.Text,
                customerAddressTxtbox.Text));
                customerDataGrid.DataSource = null;
                customerDataGrid.DataSource = CustomersList;
        }
    }

    
}
