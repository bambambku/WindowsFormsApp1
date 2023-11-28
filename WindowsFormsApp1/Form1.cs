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
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    

   

    public partial class Form1 : Form
    {
        //public Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        public List<Customer> CustomersList {  get; set; }
        public List<Product> ProductsList { get; set; }
        public List<Order> OrdersList { get; set; }
        public Form1()
        {
            CustomersList = GetCustomers();
            
            ProductsList = GetProducts();
            OrdersList = GetOrders();
            
            InitializeComponent();
            customerDataGrid.DataSource = CustomersList;
            productDataGrid.DataSource = ProductsList;
            orderGridViewLeft.DataSource = OrdersList;
            orderProductComboBox.DataSource = ProductsList;
            orderCustomerComboBox.DataSource = CustomersList;
        }

        private List<Order> GetOrders()
        {
            List<Order> newOrdersList = new List<Order>();
            newOrdersList.Add(new Order(1, new Dictionary<Product, int>()
            {
                { ProductsList[1], 12 },
                { ProductsList[2], 13 }
            }, DateTime.Now, CustomersList[0]));
            newOrdersList.Add(new Order(2, new Dictionary<Product, int>()
            {
                { ProductsList[3], 123 },
                { ProductsList[4], 133 }
            }, DateTime.Now, CustomersList[2]));
            return newOrdersList;

        }

        private List<Product> GetProducts()
        {
            List<Product> newProductsList = new List<Product>();
            newProductsList.Add(new Product(1, "Scissors", "Extremely sharp scissors", "Office", 123, 9.99m));
            newProductsList.Add(new Product(2, "Blue ballpoint pen", "Cheap pen for customers", "Office", 1050, 0.59m));
            newProductsList.Add(new Product(3, "Paperclip", "Clip your documents together", "Office", 12456, 0.02m));
            newProductsList.Add(new Product(4, "Desk lamp", "Led light, brightness regulated", "Office", 145, 11.99m));
            newProductsList.Add(new Product(5, "PC speakers", "5W speaker set for desktop", "Office", 13, 8.99m));
            newProductsList.Add(new Product(6, "Notepad", "200 pages, lines, hardback", "Office", 1123, 5.99m));
            return newProductsList;
        }

        private List<Customer> GetCustomers()
        {
            List<Customer> newCustomersList = new List<Customer>();
            newCustomersList.Add(new Customer(101, "Frames Ltd", "07456546456", "13 Barnsley Road, WF92LD, Pontefract", "frames@gmail.com"));
            newCustomersList.Add(new Customer(102, "Barabash", "7845654654", "52 Peackock Crescent, LS113LS, Leeds", "barabash@gmail.com"));
            newCustomersList.Add(new Customer(103, "Galagan", "786943513413", "12 Harness Hill, WF32LP, Stanley", "galagan@outlook.com")
            {
              
            });
            return newCustomersList;
        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            

        }

        private void customersPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void productDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedProduct = productDataGrid.SelectedRows[0].DataBoundItem as Product;

            productNameTxtbox.Text = selectedProduct.Name;
            productCategoryTxtbox.Text = selectedProduct.Category;
            productQtyTxtbox.Text = Convert.ToString(selectedProduct.Qty);
            productPriceTxtbox.Text = Convert.ToString(selectedProduct.Price);
            productDescriptionTxtbox.Text = selectedProduct.Description;

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
            if(!AllFieldsValidator("WRONG DATA ENTERED")) return;
            
            int nextID = CustomersList.Last().ID + 1;
            if(CustomersList.Any(customer => customer.Name == customerNameTxtbox.Text))
            {
                Warning(customerWarningLbl, "CUSTOMER ALREADY EXISTS");
                return;
            }
            CustomersList.Add(new Customer(
                nextID,
                customerNameTxtbox.Text,
                customerPhoneTxtbox.Text,
                customerEmailTxtbox.Text,
                customerAddressTxtbox.Text));
                customerDataGrid.DataSource = null;
                customerDataGrid.DataSource = CustomersList;
        }

        private void customerUpdateBtn_Click(object sender, EventArgs e)
        {
            if (!AllFieldsValidator("WRONG DATA ENTERED")) return;
            var selectedCustomer = customerDataGrid.SelectedRows[0].DataBoundItem as Customer;
            string[] values = {
                Convert.ToString(selectedCustomer.ID),
                customerNameTxtbox.Text,
                customerPhoneTxtbox.Text,
                customerEmailTxtbox.Text,
                customerAddressTxtbox.Text
            };
            PropertiesHandler.Update(selectedCustomer, values);
            customerDataGrid.DataSource = null;
            customerDataGrid.DataSource = CustomersList;
        }

        private void customerDeleteBtn_Click(object sender, EventArgs e)
        {
            var selectedCustomer = customerDataGrid.SelectedRows[0].DataBoundItem as Customer;
            CustomersList.Remove(selectedCustomer);
            customerDataGrid.DataSource = null;
            customerDataGrid.DataSource = CustomersList;
        }

        private void customersButton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void productsBtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void label2_Click_3(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void productNameTxtbox_TextChanged(object sender, EventArgs e)
        {
            if(productNameTxtbox.Text.Length > 30 || productNameTxtbox.Text.Length == 0)
            {
                productNameTxtbox.ForeColor = Color.Red;
            } else
            {
                productNameTxtbox.ForeColor= Color.Black;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void productAddClick(object sender, EventArgs e)
        {
            int nextID = ProductsList.Last().Id + 1;
            ProductsList.Add(new Product(
                nextID,
                productNameTxtbox.Text,
                productDescriptionTxtbox.Text,
                productCategoryTxtbox.Text,
                Int32.Parse(productQtyTxtbox.Text),
                Decimal.Parse(productPriceTxtbox.Text)));
            productDataGrid.DataSource = null;
            productDataGrid.DataSource = ProductsList;
        }

        private void productUpdateClick(object sender, EventArgs e)
        {
            var selectedProduct = productDataGrid.SelectedRows[0].DataBoundItem as Product;
            string[] values = {
                Convert.ToString(selectedProduct.Id),
                productNameTxtbox.Text,
                productDescriptionTxtbox.Text,
                productCategoryTxtbox.Text,
                productQtyTxtbox.Text,
                productPriceTxtbox.Text
            };
            PropertiesHandler.Update(selectedProduct, values);
            productDataGrid.DataSource = null;
            productDataGrid.DataSource = ProductsList;
        }

        private void productDeleteClick(object sender, EventArgs e)
        {
            var selectedProduct = productDataGrid.SelectedRows[0].DataBoundItem as Product;
            ProductsList.Remove(selectedProduct);
            productDataGrid.DataSource = null;
            productDataGrid.DataSource = ProductsList;
        }

        private void label2_Click_4(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void orderGridViewLeft_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var selectedOrder = orderGridViewLeft.SelectedRows[0].DataBoundItem as Order;
            orderCustomerComboBox.SelectedItem = selectedOrder.ByCustomer;
            orderDateTxtbox.Text = Convert.ToString(selectedOrder.DateCreated);
            orderPriceTxtbox.Text = selectedOrder.Price.ToString();
            orderProductDataGrid_Referesher(selectedOrder);


        }

        private void orderProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedOrderProduct = orderProductDataGrid.SelectedRows[0].DataBoundItem as Product;
            var selectedOrder = orderGridViewLeft.SelectedRows[0].DataBoundItem as Order;
            orderProductComboBox.SelectedItem = selectedOrderProduct;
            orderProductQtyTxtbox.Text = Convert.ToString(selectedOrder.ProductOrderDictionary[selectedOrderProduct]);
            string currentPrice = Convert.ToString(selectedOrder.ProductOrderDictionary[selectedOrderProduct] * selectedOrderProduct.Price);
            orderProductPriceTxtbox.Text = currentPrice;
        }

        private void orderProductAddBtn_Click(object sender, EventArgs e)
        {
            var selectedOrder = orderGridViewLeft.SelectedRows[0].DataBoundItem as Order;
            if (orderProductQtyTxtbox.ForeColor == Color.Red)
            {
                orderProductQtyWarningLbl.Text = "WRONG QUANTITY";
                Task.Delay(1000).Wait();
                orderProductQtyWarningLbl.Text = "";
                return;
            }
            if (selectedOrder.ProductOrderDictionary.ContainsKey(orderProductComboBox.SelectedItem as Product))
            {
                selectedOrder.ProductOrderDictionary[orderProductComboBox.SelectedItem as Product] = Int32.Parse(orderProductQtyTxtbox.Text);
            } else
            {
                selectedOrder.ProductOrderDictionary.Add(
                 orderProductComboBox.SelectedItem as Product,
                    Int32.Parse(orderProductQtyTxtbox.Text));
            }
            
            orderGridViewLeft.DataSource = OrdersList;
            orderProductDataGrid_Referesher(selectedOrder);
        }

        private void orderProductQtyTxtbox_TextChanged(object sender, EventArgs e)
        {
           orderPriceTxtboxUpdater();
        }

        private void orderPriceTxtboxUpdater()
        {
            var selectedProductComboBoxPrice = (orderProductComboBox.SelectedItem as Product).Price;
            var orderProductQtyInput = Int32.TryParse(orderProductQtyTxtbox.Text, out int qty) ? qty : 0;
            if (orderProductQtyInput == 0)
            {
                orderProductQtyTxtbox.ForeColor = Color.Red;
            } else
            {
                orderProductQtyTxtbox.ForeColor = Color.Black;
            }
            var orderProductQty = (orderProductQtyTxtbox.Text.Length == 0) ? 0 : qty;
            orderProductPriceTxtbox.Text = (orderProductQty * selectedProductComboBoxPrice).ToString();
        }

        private void orderProductPriceTxtbox_TextChanged(object sender, EventArgs e)
        {
            if (Decimal.TryParse(orderProductPriceTxtbox.Text, out decimal converted) == false)
            {
                orderProductPriceTxtbox.Text = (0.00).ToString();
            } else
            {
                orderProductPriceTxtbox.Text = converted.ToString();
            }
        }

        private void orderProductComboBoxChangePriceTextboxUpdate(object sender, EventArgs e)
        {
            orderPriceTxtboxUpdater();
        }

        private void orderProductDataGrid_Referesher(Order selectedOrder)
        {
            List<Product> orderProductList = new List<Product>();
            foreach (var orderProduct in selectedOrder.ProductOrderDictionary)
            {
                orderProductList.Add(orderProduct.Key);
            };
            orderProductDataGrid.DataSource = orderProductList;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label2_Click_5(object sender, EventArgs e)
        {

        }

        private void orderProductUpdateBtn_Click(object sender, EventArgs e)
        {
            var selectedOrder = orderGridViewLeft.SelectedRows[0].DataBoundItem as Order;
            if (orderProductQtyTxtbox.ForeColor == Color.Red)
            {
                orderProductQtyWarningLbl.Text = "WRONG QUANTITY";
                Task.Delay(1000).Wait();
                orderProductQtyWarningLbl.Text = "";
                return;
            }
            if (selectedOrder.ProductOrderDictionary.ContainsKey(orderProductComboBox.SelectedItem as Product))
            {
                selectedOrder.ProductOrderDictionary[orderProductComboBox.SelectedItem as Product] = Int32.Parse(orderProductQtyTxtbox.Text);
            }
            else
            {
                selectedOrder.ProductOrderDictionary.Add(
                 orderProductComboBox.SelectedItem as Product,
                    Int32.Parse(orderProductQtyTxtbox.Text));
            }

            orderGridViewLeft.DataSource = OrdersList;
            orderProductDataGrid_Referesher(selectedOrder);
        }

        private void orderProductDeleteBtn_Click(object sender, EventArgs e)
        {
            var selectedOrder = orderGridViewLeft.SelectedRows[0].DataBoundItem as Order;
            if (selectedOrder.ProductOrderDictionary.ContainsKey(orderProductComboBox.SelectedItem as Product))
            {
                selectedOrder.ProductOrderDictionary.Remove(orderProductComboBox.SelectedItem as Product);
                orderGridViewLeft.DataSource = OrdersList;
                orderProductDataGrid_Referesher(selectedOrder);
            }
        }

        private void customerPhoneTxtbox_TextChanged(object sender, EventArgs e)
        {
            customerPhoneTxtbox.ForeColor = Int32.TryParse(customerPhoneTxtbox.Text, out int phoneNumber) ? 
                Color.Black : Color.Red; 
        }

        private void customerEmailTxtbox_TextChanged(object sender, EventArgs e)
        {
            customerEmailTxtbox.ForeColor = (customerEmailTxtbox.Text.Contains('@')) ? 
                Color.Black : Color.Red;  
        }

        
        private bool AllFieldsValidator(string comment)
        {
            if ((customerNameTxtbox.ForeColor == Color.Red ||
            customerPhoneTxtbox.ForeColor == Color.Red ||
            customerEmailTxtbox.ForeColor == Color.Red) ||
            (customerNameTxtbox.Text.Length == 0 ||
            customerPhoneTxtbox.Text.Length == 0 ||
            customerEmailTxtbox.Text.Length == 0 ||
            customerAddressTxtbox.Text.Length == 0))
            {
                Warning(customerWarningLbl, comment);
                return false;
            }
            return true;
        }
         
        private void Warning(Label label, string message)
        {
            label.ForeColor = Color.Red;
            label.Text = message;
            Task.Delay(1000).Wait();
            label.ForeColor = Color.Black;
            label.Text = "nothing, change later";
        }
    }

    

    
}
