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
        public List<Customer> CustomersList { get; set; }
        public List<Product> ProductsList { get; set; }
        public List<Order> OrdersList { get; set; }
        public int integerO = 1;
        public decimal decimalO = 1.1m;
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
            newOrdersList.Add(new Order(new Dictionary<Product, int>()
            {
                { ProductsList[1], 12 },
                { ProductsList[2], 13 }
            }, DateTime.Now, CustomersList[0]));
            newOrdersList.Add(new Order(new Dictionary<Product, int>()
            {
                { ProductsList[3], 123 },
                { ProductsList[4], 133 }
            }, DateTime.Now, CustomersList[2]));
            return newOrdersList;

        }

        private List<Product> GetProducts()
        {
            List<Product> newProductsList = new List<Product>();
            newProductsList.Add(new Product("Scissors", "Extremely sharp scissors", "Office", 123, 9.99m));
            newProductsList.Add(new Product("Blue ballpoint pen", "Cheap pen for customers", "Office", 1050, 0.59m));
            newProductsList.Add(new Product("Paperclip", "Clip your documents together", "Office", 12456, 0.02m));
            newProductsList.Add(new Product("Desk lamp", "Led light, brightness regulated", "Office", 145, 11.99m));
            newProductsList.Add(new Product("PC speakers", "5W speaker set for desktop", "Office", 13, 8.99m));
            newProductsList.Add(new Product("Notepad", "200 pages, lines, hardback", "Office", 1123, 5.99m));
            return newProductsList;
        }

        private List<Customer> GetCustomers()
        {
            List<Customer> newCustomersList = new List<Customer>();
            newCustomersList.Add(new Customer("Frames Ltd", "07456546456", "13 Barnsley Road, WF92LD, Pontefract", "frames@gmail.com"));
            newCustomersList.Add(new Customer("Barabash", "7845654654", "52 Peackock Crescent, LS113LS, Leeds", "barabash@gmail.com"));
            newCustomersList.Add(new Customer("Galagan", "786943513413", "12 Harness Hill, WF32LP, Stanley", "galagan@outlook.com")
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
            if (!CustomerAllFieldsValidator("WRONG DATA ENTERED")) return;

            if (CustomersList.Any(customer => customer.Name == customerNameTxtbox.Text))
            {
                Warning(customerWarningLbl, "CUSTOMER ALREADY EXISTS");
                return;
            }
            CustomersList.Add(new Customer(
                customerNameTxtbox.Text,
                customerPhoneTxtbox.Text,
                customerEmailTxtbox.Text,
                customerAddressTxtbox.Text));
            customerDataGrid.DataSource = null;
            customerDataGrid.DataSource = CustomersList;
        }

        private void customerUpdateBtn_Click(object sender, EventArgs e)
        {
            if (!CustomerAllFieldsValidator("WRONG DATA ENTERED")) return;
            var selectedCustomer = customerDataGrid.SelectedRows[0].DataBoundItem as Customer;
            if (CustomersList.Where(p => p.Name != selectedCustomer.Name).Any(p => p.Name == customerNameTxtbox.Text))
            {
                Warning(customerWarningLbl, "CUSTOMER'S NAME ALREADY EXISTS IN THE LIST");
                return;
            }
            string[] values = {
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
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void productAddClick(object sender, EventArgs e)
        {
            if (!ProductAllFieldsValidator("WRONG DATA ENTERED")) return;
            if (ProductsList.Any(product => product.Name == productNameTxtbox.Text))
            {
                Warning(productWarningLbl, "PRODUCT ALREADY EXISTS");
            } else
            {
                ProductsList.Add(new Product(
                productNameTxtbox.Text,
                productDescriptionTxtbox.Text,
                productCategoryTxtbox.Text,
                Int32.Parse(productQtyTxtbox.Text),
                Decimal.Parse(productPriceTxtbox.Text)));
            }
            
            productDataGrid.DataSource = null;
            productDataGrid.DataSource = ProductsList;
        }

        private void productUpdateClick(object sender, EventArgs e)
        {
            if (!ProductAllFieldsValidator("WRONG DATA ENTERED")) return;
            var selectedProduct = productDataGrid.SelectedRows[0].DataBoundItem as Product;
            if(ProductsList.Where(p => p.Name != selectedProduct.Name).Any(p => p.Name == productNameTxtbox.Text))
            {
                Warning(productWarningLbl, "PRODUCT'S NAME ALREADY EXISTS IN THE LIST");
                return;
            }
            string[] values = {
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

        private void orderProductQtyTxtbox_TextChanged(object sender, EventArgs e)
        {
            orderPriceTxtboxUpdater();
        }

        private void orderPriceTxtboxUpdater()
        {
            var selectedProductComboBox = (orderProductComboBox.SelectedItem as Product);
            var orderProductQtyInput = Int32.TryParse(orderProductQtyTxtbox.Text, out int qty) ? qty : 0;
            if (orderProductQtyInput == 0 || orderProductQtyInput > selectedProductComboBox.Qty)
            {
                orderProductQtyTxtbox.ForeColor = Color.Red;
            }
            else
            {
                orderProductQtyTxtbox.ForeColor = Color.Black;
            }
            var orderProductQty = (orderProductQtyTxtbox.Text.Length == 0) ? 0 : qty;
            orderProductPriceTxtbox.Text = (orderProductQty * selectedProductComboBox.Price).ToString();
        }

        private void orderProductPriceTxtbox_TextChanged(object sender, EventArgs e)
        {
            if (Decimal.TryParse(orderProductPriceTxtbox.Text, out decimal converted) == false)
            {
                orderProductPriceTxtbox.Text = (0.00).ToString();
            }
            else
            {
                orderProductPriceTxtbox.Text = converted.ToString();
            }
        }

        private void orderProductComboBoxChangePriceTextboxUpdate(object sender, EventArgs e)
        {
            orderPriceTxtboxUpdater();
            orderProductLbl.Text = "Product: " + (orderProductComboBox.SelectedItem as Product).Qty.ToString() + " available";
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
            NumberTxtboxValidator(integerO, customerPhoneTxtbox);
        }

        private void customerEmailTxtbox_TextChanged(object sender, EventArgs e)
        {
            customerEmailTxtbox.ForeColor = (customerEmailTxtbox.Text.Contains('@')) ?
                Color.Black : Color.Red;
        }


        private bool CustomerAllFieldsValidator(string comment)
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

        private bool ProductAllFieldsValidator(string comment)
        {
            if (productNameTxtbox.ForeColor == Color.Red ||
            productCategoryTxtbox.ForeColor == Color.Red ||
            productQtyTxtbox.ForeColor == Color.Red ||
            productPriceTxtbox.ForeColor == Color.Red ||
            productDescriptionTxtbox.ForeColor == Color.Red)
            {
                Warning(productWarningLbl, comment);
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

        private void productNameTxtbox_TextChanged_1(object sender, EventArgs e)
        {
            MaxCharactersPerTxtboxSetter(productNameTxtbox, 20);
        }

        private void customerNameTxtbox_TextChanged(object sender, EventArgs e)
        {
            MaxCharactersPerTxtboxSetter(customerNameTxtbox, 20);
        }

        private void productCategoryTxtbox_TextChanged(object sender, EventArgs e)
        {
            MaxCharactersPerTxtboxSetter(productCategoryTxtbox, 14);
        }

        private void MaxCharactersPerTxtboxSetter(TextBox textbox, int maxCharactersPerTxtbox)
        {
            if (textbox.Text.Length > maxCharactersPerTxtbox || textbox.Text.Length == 0)
            {
                textbox.ForeColor = Color.Red;
            }
            else
            {
                textbox.ForeColor = Color.Black;
            }
        }

        private void productQtyTxtbox_TextChanged(object sender, EventArgs e)
        {
            NumberTxtboxValidator(integerO, productQtyTxtbox);
        }

        private void productPriceTxtbox_TextChanged(object sender, EventArgs e)
        {
            NumberTxtboxValidator(decimalO, productPriceTxtbox);
        }

        private void NumberTxtboxValidator(IConvertible number, TextBox textbox)
        {
            decimal dec = 1.1m;
            int integer = 1;

            if (number.GetType() == dec.GetType())
            {
                textbox.ForeColor = (
                    Decimal.TryParse(textbox.Text, out decimal any) ||
                    textbox.Text.Length == 0) ?
                    Color.Black : Color.Red;
            } else if (number.GetType() == integer.GetType())
            {
                textbox.ForeColor = (
                    Int32.TryParse(textbox.Text, out int any) ||
                    textbox.Text.Length == 0) ?
                    Color.Black : Color.Red;
            }

        }


        private void productDescriptionTxtbox_TextChanged(object sender, EventArgs e)
        {
            MaxCharactersPerTxtboxSetter(productDescriptionTxtbox, 300);
        }


        


    }
}
