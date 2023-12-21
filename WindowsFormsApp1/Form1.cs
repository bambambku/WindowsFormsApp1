using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public List<Customer> CustomersList { get; set; }
        public List<Product> ProductsList { get; set; }
        public List<Order> OrdersList { get; set; }
        public int integerO = 1;
        public decimal decimalO = 1.1m;
        public string CustomersPath = "customersListCSV.txt";
        public string ProductsPath = "productsListCSV.txt";
        public string OrdersPath = "ordersListCSV.txt";
        public Form1()
        {
            CustomersList = GetCustomers(CustomersPath);
            ProductsList = GetProducts(ProductsPath);
            OrdersList = GetOrders(OrdersPath);

            InitializeComponent();
            customerDataGrid.DataSource = CustomersList;
            productDataGrid.DataSource = ProductsList;
            orderGridViewLeft.DataSource = OrdersList;
            orderProductComboBox.DataSource = ProductsList;
            orderCustomerComboBox.DataSource = CustomersList;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveCustomers(CustomersList, CustomersPath);
            SaveProducts(ProductsList, ProductsPath);
            SaveOrders(OrdersList, OrdersPath);
        }

    // Get functions to read data from CSV files
        private List<Order> GetOrders(string path)
        {
            Order handler = new Order(null, DateTime.Now, null);
            return ReadOrdersList(path, handler);
        }

        private List<Product> GetProducts(string path)
        {
            Product handler = new Product("", "", "", 0, 0);
            return ReadProductsList(path, handler);
        }

        private List<Customer> GetCustomers(string path)
        {
            Customer handler = new Customer("", "", "", "");
            return ReadCustomersList(path, handler);
        }

    // Connecting page buttons with tabs in Tab Control panel
        private void customersButton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void productsBtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            orderProductComboBox.DataSource = ProductsList;
            orderCustomerComboBox.DataSource = CustomersList;
        }

    // Customer panel methods    
        private void customerGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedCustomer = customerDataGrid.SelectedRows[0].DataBoundItem as Customer;

            customerNameTxtbox.Text = selectedCustomer.Name;
            customerPhoneTxtbox.Text = selectedCustomer.Phone;
            customerEmailTxtbox.Text = selectedCustomer.Email;
            customerAddressTxtbox.Text = selectedCustomer.Address;
        }

        private void customerAddClick(object sender, EventArgs e)
        {
            if (!CustomerAllFieldsValidator("WRONG DATA ENTERED")) return;
            if (CustomersList == null) CustomersList = new List<Customer>();
            if (CustomersList.Any(customer => customer.Name == customerNameTxtbox.Text))
            {
                Warning(customerWarningLbl, "CUSTOMER ALREADY EXISTS");
                return;
            }
            CustomersList.Add(new Customer(
                customerNameTxtbox.Text,
                customerPhoneTxtbox.Text,
                customerAddressTxtbox.Text,
                customerEmailTxtbox.Text));
            customerDataGrid.DataSource = null;
            customerDataGrid.DataSource = CustomersList;
            orderCustomerComboBox.DataSource = null;
            orderCustomerComboBox.DataSource = CustomersList;
        }

        private void customerUpdateBtn_Click(object sender, EventArgs e)
        {
            if (CustomersList == null || CustomersList.Count == 0) return;
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
                customerAddressTxtbox.Text,
                customerEmailTxtbox.Text
            };
            PropertiesHandler.Update(selectedCustomer, values);
            customerDataGrid.DataSource = null;
            customerDataGrid.DataSource = CustomersList;
            orderCustomerComboBox.DataSource = null;
            orderCustomerComboBox.DataSource = CustomersList;
        }

        private void customerDeleteBtn_Click(object sender, EventArgs e)
        {
            var selectedCustomer = customerDataGrid.SelectedRows[0].DataBoundItem as Customer;
            bool customerInUse = CustomersList.Any(c => c == selectedCustomer);
            if (customerInUse)
            {
                Warning(customerWarningLbl, "CUSTOMER EXISTS IN AN ORDER");
                return;
            }
            CustomersList.Remove(selectedCustomer);
            customerDataGrid.DataSource = null;
            customerDataGrid.DataSource = CustomersList;
            orderCustomerComboBox.DataSource = null;
            orderCustomerComboBox.DataSource = CustomersList;
        }

        private void customerPhoneTxtbox_TextChanged(object sender, EventArgs e)
        {
            NumberTxtboxValidator(integerO, customerPhoneTxtbox);
        }

        private void customerEmailTxtbox_TextChanged(object sender, EventArgs e)
        {
            customerEmailTxtbox.ForeColor = (customerEmailTxtbox.Text.Contains('@')) ?
                Color.Black : Color.Red;
            if (customerEmailTxtbox.Text.Contains(',')) customerEmailTxtbox.ForeColor = Color.Red;
        }

        private void customerNameTxtbox_TextChanged(object sender, EventArgs e)
        {
            MaxCharactersPerTxtboxSetter(customerNameTxtbox, 20);
            if (customerNameTxtbox.Text.Contains(',')) customerNameTxtbox.ForeColor = Color.Red;
        }

        private void customerAddressTxtbox_TextChanged(object sender, EventArgs e)
        {
            customerAddressTxtbox.ForeColor = customerAddressTxtbox.Text.Contains(',') ? Color.Red : Color.Black;
        }

        private bool CustomerAllFieldsValidator(string comment)
        {
            List<TextBox> list = new List<TextBox>()
            {
                customerNameTxtbox,
                customerPhoneTxtbox,
                customerEmailTxtbox,
                customerAddressTxtbox
            };
            if (list.Any(b => b.ForeColor == Color.Red) ||
                list.Any(b => b.Text.Length == 0))
            {
                Warning(customerWarningLbl, comment);
                return false;
            }
            return true;
        }

    // Product panel methods
        private void productDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedProduct = productDataGrid.SelectedRows[0].DataBoundItem as Product;

            productNameTxtbox.Text = selectedProduct.Name;
            productCategoryTxtbox.Text = selectedProduct.Category;
            productQtyTxtbox.Text = Convert.ToString(selectedProduct.Qty);
            productPriceTxtbox.Text = Convert.ToString(selectedProduct.Price);
            productDescriptionTxtbox.Text = selectedProduct.Description;
        }

        private void productAddClick(object sender, EventArgs e)
        {
            if (!ProductAllFieldsValidator("WRONG DATA ENTERED")) return;
            if (ProductsList == null) ProductsList = new List<Product>();
            if (ProductsList.Any(product => product.Name == productNameTxtbox.Text))
            {
                Warning(productWarningLbl, "PRODUCT ALREADY EXISTS");
                return;
            }
            else
            {
                ProductsList.Add(new Product(
                productNameTxtbox.Text,
                productDescriptionTxtbox.Text,
                productCategoryTxtbox.Text,
                Int32.Parse(productQtyTxtbox.Text),
                Decimal.Round(Decimal.Parse(productPriceTxtbox.Text), 2)));
            }
            productDataGrid.DataSource = null;
            productDataGrid.DataSource = ProductsList;
            productDataGrid.Rows[productDataGrid.Rows.Count - 1].Selected = true;
            var selectedProduct = productDataGrid.SelectedRows[0].DataBoundItem as Product;
            productPriceTxtbox.Text = selectedProduct.Price.ToString();
            orderProductComboBox.DataSource = null;
            orderProductComboBox.DataSource = ProductsList;
        }

        private void productUpdateClick(object sender, EventArgs e)
        {
            if (ProductsList == null || ProductsList.Count == 0) return;
            if (!ProductAllFieldsValidator("WRONG DATA ENTERED")) return;
            var selectedProduct = productDataGrid.SelectedRows[0].DataBoundItem as Product;
            if (ProductsList.Where(p => p.Name != selectedProduct.Name).Any(p => p.Name == productNameTxtbox.Text))
            {
                Warning(productWarningLbl, "PRODUCT'S NAME ALREADY EXISTS IN THE LIST");
                return;
            }
            string[] values = {
                productNameTxtbox.Text,
                productDescriptionTxtbox.Text,
                productCategoryTxtbox.Text,
                productQtyTxtbox.Text,
                Decimal.Round(Decimal.Parse(productPriceTxtbox.Text), 2).ToString()
            };
            PropertiesHandler.Update(selectedProduct, values);
            productDataGrid.DataSource = null;
            productDataGrid.DataSource = ProductsList;
            productPriceTxtbox.Text = selectedProduct.Price.ToString();
            orderProductComboBox.DataSource = null;
            orderProductComboBox.DataSource = ProductsList;
        }

        private void productDeleteClick(object sender, EventArgs e)
        {
            var selectedProduct = productDataGrid.SelectedRows[0].DataBoundItem as Product;
            bool productInUse = OrdersList.Any(o => o.ProductOrderDictionary.Any(kvp => kvp.Key == selectedProduct));
            if (productInUse)
            {
                Warning(productWarningLbl, "PRODUCT EXISTS IN AN ORDER");
                return;
            }
            ProductsList.Remove(selectedProduct);
            productDataGrid.DataSource = null;
            productDataGrid.DataSource = ProductsList;
            orderProductComboBox.DataSource = null;
            orderProductComboBox.DataSource = ProductsList;
        }

        private bool ProductAllFieldsValidator(string comment)
        {
            List<TextBox> list = new List<TextBox>()
            {
                productNameTxtbox,
                productCategoryTxtbox,
                productQtyTxtbox,
                productPriceTxtbox,
                productDescriptionTxtbox
            };

            if (list.Any(b => b.ForeColor == Color.Red) ||
                list.Any(b => b.Text.Length == 0))
            {
                Warning(productWarningLbl, comment);
                return false;
            }
            return true;
        }

        private void productNameTxtbox_TextChanged_1(object sender, EventArgs e)
        {
            MaxCharactersPerTxtboxSetter(productNameTxtbox, 20);
            if (productNameTxtbox.Text.Contains(',')) productNameTxtbox.ForeColor = Color.Red;
        }

        private void productCategoryTxtbox_TextChanged(object sender, EventArgs e)
        {
            MaxCharactersPerTxtboxSetter(productCategoryTxtbox, 14);
            if (productCategoryTxtbox.Text.Contains(',')) productCategoryTxtbox.ForeColor = Color.Red;
        }

        private void productQtyTxtbox_TextChanged(object sender, EventArgs e)
        {
            NumberTxtboxValidator(integerO, productQtyTxtbox);
        }

        private void productPriceTxtbox_TextChanged(object sender, EventArgs e)
        {
            NumberTxtboxValidator(decimalO, productPriceTxtbox);
            if (productPriceTxtbox.ForeColor == Color.Black &&
                productPriceTxtbox.Text.Length > 0)
            {
                var decimalO = Decimal.Parse(productPriceTxtbox.Text);
                if (Decimal.Round(decimalO, 2) != decimalO)
                {
                    productPriceTxtbox.ForeColor = Color.Red;
                }
            }
        }

        private void productDescriptionTxtbox_TextChanged(object sender, EventArgs e)
        {
            MaxCharactersPerTxtboxSetter(productDescriptionTxtbox, 300);
            if (productDescriptionTxtbox.Text.Contains(',')) productDescriptionTxtbox.ForeColor = Color.Red;
        }

    //Orders panel methods
        private void orderGridViewLeft_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var selectedOrder = orderGridViewLeft.SelectedRows[0].DataBoundItem as Order;
            orderCustomerComboBox.SelectedItem = selectedOrder.ByCustomer;
            orderDateTxtbox.Text = Convert.ToString(selectedOrder.DateCreated);
            orderPriceTxtbox.Text = selectedOrder.GetPrice(selectedOrder.ProductOrderDictionary).ToString();
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
            if (ProductsList == null || ProductsList.Count == 0) return;
            var selectedOrder = orderGridViewLeft.SelectedRows[0].DataBoundItem as Order;
            if (orderProductQtyTxtbox.ForeColor == Color.Red)
            {
                Warning(orderProductQtyWarningLbl, "WRONG QUANTITY");
                return;
            }
            if (selectedOrder.ProductOrderDictionary == null)
            {
                selectedOrder.ProductOrderDictionary.Add(
                 orderProductComboBox.SelectedItem as Product,
                    Int32.Parse(orderProductQtyTxtbox.Text));
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
            selectedOrder.Price = selectedOrder.GetPrice(selectedOrder.ProductOrderDictionary);
            orderGridViewLeft.DataSource = null;
            orderGridViewLeft.DataSource = OrdersList;
            orderProductDataGrid_Referesher(selectedOrder);

        }

        private void orderProductQtyTxtbox_TextChanged(object sender, EventArgs e)
        {
            orderProductPriceTxtboxUpdater();
            orderPriceTxtboxUpdater();
        }

        private void orderProductPriceTxtboxUpdater()
        {
            var selectedProductComboBox = orderProductComboBox.SelectedItem as Product;
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
            var price = selectedProductComboBox == null ? 0 : selectedProductComboBox.Price;
            orderProductPriceTxtbox.Text = (orderProductQty * price).ToString();
        }

        private void orderPriceTxtboxUpdater()
        {
            if (orderGridViewLeft.SelectedRows != null &&
                orderGridViewLeft.SelectedRows.Count > 0 &&
                orderProductComboBox.SelectedItem != null)
            {
                var selectedOrderComboBox = orderGridViewLeft.SelectedRows[0].DataBoundItem as Order;
                var selectedProductComboBox = orderProductComboBox.SelectedItem as Product;
                if (selectedOrderComboBox.ProductOrderDictionary == null)
                {
                    orderPriceTxtbox.Text = string.Empty;
                    return;
                }
                bool orderContainsProduct = selectedOrderComboBox.ProductOrderDictionary.ContainsKey(selectedProductComboBox);
                decimal newOrderPrice = 0.0m;
                if (!orderContainsProduct)
                {
                    newOrderPrice = selectedOrderComboBox.GetPrice(selectedOrderComboBox.ProductOrderDictionary) + decimal.Parse(orderProductPriceTxtbox.Text);

                }
                else
                {
                    foreach (var kpv in selectedOrderComboBox.ProductOrderDictionary)
                    {
                        int qty = kpv.Value;
                        if (kpv.Key == selectedProductComboBox)
                        {
                            newOrderPrice += Decimal.Parse(orderProductPriceTxtbox.Text);
                            continue;
                        }
                        newOrderPrice += qty * kpv.Key.Price;
                    }
                }
                orderPriceTxtbox.Text = newOrderPrice.ToString();
            }
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
            orderProductPriceTxtboxUpdater();
            orderProductLbl.Text = "Product: " + (orderProductComboBox.SelectedItem as Product)?.Qty.ToString() + " available";
            if (orderGridViewLeft.SelectedRows != null)
            {
                orderPriceTxtboxUpdater();
            }
        }

        private void orderProductDataGrid_Referesher(Order selectedOrder)
        {
            List<Product> orderProductList = new List<Product>();
            if (selectedOrder.ProductOrderDictionary != null)
            {
                foreach (var orderProduct in selectedOrder.ProductOrderDictionary)
                {
                    orderProductList.Add(orderProduct.Key);
                };
                orderProductDataGrid.DataSource = orderProductList;
                int index = 0;
                foreach (var kvp in selectedOrder.ProductOrderDictionary)
                {
                    orderProductDataGrid[1, index].Value = kvp.Value;
                    index++;
                }
            }
            else
            {
                orderProductDataGrid.DataSource = orderProductList;
            }

        }

        private void orderProductDeleteBtn_Click(object sender, EventArgs e)
        {
            if (OrdersList == null || OrdersList.Count == 0) return;
            var selectedOrder = orderGridViewLeft.SelectedRows[0].DataBoundItem as Order;
            if (selectedOrder.ProductOrderDictionary.ContainsKey(orderProductComboBox.SelectedItem as Product))
            {
                selectedOrder.ProductOrderDictionary.Remove(orderProductComboBox.SelectedItem as Product);
                orderGridViewLeft.DataSource = OrdersList;
                orderProductDataGrid_Referesher(selectedOrder);
            }
            selectedOrder.Price = selectedOrder.GetPrice(selectedOrder.ProductOrderDictionary);
            orderGridViewLeft.DataSource= OrdersList;
            orderPriceTxtboxUpdater();
        }

        private void orderAddBtn_Click(object sender, EventArgs e)
        {
            if (OrdersList == null) OrdersList = new List<Order>();
            var customer = orderCustomerComboBox.SelectedItem as Customer;
            Dictionary<Product, int> productDictionary = new Dictionary<Product, int>();
            var dateTime = DateTime.Now;
            OrdersList.Add(new Order(productDictionary, dateTime, customer));
            orderGridViewLeft.DataSource = null;
            orderGridViewLeft.DataSource = OrdersList;
        }

        private void orderDeleteBtn_Click(object sender, EventArgs e)
        {
            if (OrdersList == null || OrdersList.Count == 0) return;
            var selectedOrder = orderGridViewLeft.SelectedRows[0].DataBoundItem as Order;
            OrdersList.Remove(selectedOrder);
            orderGridViewLeft.DataSource = null;
            orderGridViewLeft.DataSource = OrdersList;
        }

        // Other methods      

        // Wrong data warnings handler on chosen label
        private void Warning(Label label, string message)
        {
            label.ForeColor = Color.Red;
            label.Text = message;
            Task.Delay(1000).Wait();
            label.ForeColor = Color.Black;
            label.Text = "nothing, change later";
        }

        // Setting max chars per Textbox
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

        // Validating integers/decimals in Textbox
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
            }
            else if (number.GetType() == integer.GetType())
            {
                textbox.ForeColor = (
                    Int32.TryParse(textbox.Text, out int any) ||
                    textbox.Text.Length == 0) ?
                    Color.Black : Color.Red;
            }
        }

        // Saving operations
        private void SaveCustomers(List<Customer> customerList, string customersPath)
        {
            if (customerList == null) return;
            string newData = "";
            foreach (Customer item in customerList)
            {
                string itemData = item.ToCSVString();
                newData += $"{itemData}\n";
            }
            CSVHandler.Write(customersPath, newData);
        }

        private void SaveProducts(List<Product> productsList, string productsPath)
        {
            string newData = "";
            if (productsList != null)
            {
                foreach (Product item in productsList)
                {
                    string itemData = item.ToCSVString();
                    newData += $"{itemData}\n";
                }
                CSVHandler.Write(productsPath, newData);
            }
            
        }

        private void SaveOrders(List<Order> ordersList, string ordersPath)
        {
            if (ordersList == null) return;
            string newData = "";
            foreach (Order item in ordersList)
            {
                string itemData = item.ToCSVString(ProductsList, CustomersList);
                newData += $"{itemData}\n";
            }
            CSVHandler.Write(ordersPath, newData);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SaveCustomers(CustomersList, CustomersPath);
            SaveProducts(ProductsList, ProductsPath);
            SaveOrders(OrdersList, OrdersPath);
        }

        // Read operations
        private List<Customer> ReadCustomersList(string path, Customer handler)
        {
            List<Customer> CSVableList = new List<Customer>();
            List<string> list = CSVHandler.Read(path);
            if (list != null)
            {
                foreach (var item in list)
                {
                    CSVableList.Add(handler.FromCSVString(item));
                }
            }            
            return CSVableList;
        }

        private List<Product> ReadProductsList(string path, Product handler)
        {
            List<Product> CSVableList = new List<Product>();
            List<string> list = CSVHandler.Read(path);
            if (list != null)
            {
                foreach (var item in list)
                {
                    CSVableList.Add(handler.FromCSVString(item));
                }
            }            
            return CSVableList;
        }

        private List<Order> ReadOrdersList(string path, Order handler)
        {
            List<Order> CSVableList = new List<Order>();
            List<string> list = CSVHandler.Read(path);
            if (list != null)
            {
                foreach (var item in list)
                {
                    CSVableList.Add(handler.FromCSVString(item, ProductsList, CustomersList));
                }
            }            
            return CSVableList;
        }

        // Future implemenation functions
        private void SaveList(List<ICSVable<object>> list, string path)
        {
            string newData = "";
            foreach (var item in list)
            {
                string itemData = item.ToCSVString();
                newData += $"{itemData}\n";
            }
            CSVHandler.Write(path, newData);
        }

        private List<object> ReadList(string path, ICSVable<object> handler)
        {
            List<object> CSVableList = new List<object>();
            List<string> list = CSVHandler.Read(path);
            foreach (var item in list)
            {
                CSVableList.Add(handler.FromCSVString(item));
            }
            return CSVableList;
        }
    }
}
