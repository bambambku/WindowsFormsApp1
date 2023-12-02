using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Xml.Linq;

namespace WindowsFormsApp1
{

    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class CustomerList
    {
        public List<Customer> List { get; set; }

        public void AddCustomer(string name, string phone, string address, string email)
        {

            List.Add(new Customer(name, phone, address, email));
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }

        public Product(string name, string description, string category, int qty, decimal price)
        {
            Name = name;
            Description = description;
            Category = category;
            Qty = qty;
            Price = price;

        }

        public override string ToString()
        {
            return this.Name;
        }

        public string ToCSVString()
        {
            return $"{Name},{Description},{Category},{Qty},{Price}";
        }

        public Product FromCSV(string CSVstring)
        {
            List<string> properties = CSVstring.Split(',').ToList();
            string name = properties[0];
            string description = properties[1];
            string category = properties[2];
            int qty = Int32.Parse(properties[3]);
            decimal price = Decimal.Parse(properties[4]);
            return new Product(name, description, category, qty, price);
        }

    }

        public class Order
        {
            public Dictionary<Product, int> ProductOrderDictionary { get; set; }
            public DateTime DateCreated { get; set; }
            public Customer ByCustomer { get; set; }
            public decimal Price { get; set; }

            public Order(Dictionary<Product, int> productOrderDictionary, DateTime datecreated, Customer byCustomer)
            {
                ProductOrderDictionary = productOrderDictionary;
                DateCreated = datecreated;
                ByCustomer = byCustomer;
                decimal price = 0;
                foreach (var kvp in productOrderDictionary)
                {
                    price += kvp.Key.Price * kvp.Value;
                }
                Price = price;
            }

            public Order(Dictionary<Product, int> productOrderDictionary, DateTime dateCreated, Customer byCustomer, decimal price)
            {
                ProductOrderDictionary = productOrderDictionary;
                DateCreated = dateCreated;
                ByCustomer = byCustomer;
                Price = price;
            }

         public string ProductsToString(List<Product> productList)
            {
                string newProductsString = String.Empty;
                foreach (var kvp in ProductOrderDictionary)
                {   
                    int index = productList.IndexOf(kvp.Key);
                    newProductsString += ($"{index} {kvp.Value};");
                }
                return newProductsString;
            }

            public Dictionary<Product, int> ProductsFromString(List<Product> productList, string productsString)
            {
                Dictionary<Product, int> newDictionary = new Dictionary<Product, int>();
                List<string> productsStringList = productsString.Split(';').ToList();
                foreach (var pair in productsStringList)
                {
                    List<string> pairList = pair.Split(' ').ToList();
                    Product newProduct = productList[int.Parse(pairList[0])];
                    int qty = int.Parse(pairList[1]);
                    newDictionary.Add(newProduct, qty);
                }
                return newDictionary;
                
            }

            public string ToCSVString(List<Product> productList, List<Customer> customerList)
            {
                string dictionaryProduct = ProductsToString(productList);
                int customerIndex = customerList.IndexOf(ByCustomer);
                string dateCreated = DateCreated.ToString();
                return $"{dictionaryProduct},{dateCreated},{customerIndex},{Price}";
            }

        public Order FromCSV(string CSVstring, List<Product> productList, List<Customer> customerList)
        {
            List<string> data = CSVstring.Split(',').ToList();
            string dictionaryProductString = data[0];
            DateTime created = DateTime.Parse(data[1]);
            Customer orderedBy = customerList[Int32.Parse(data[2])];
            decimal price = Decimal.Parse(data[3]);
            List<string> dictionaryPairsList = dictionaryProductString.Split(';').ToList();
            Dictionary<Product, int> newDictionary= new Dictionary<Product, int>();
            foreach (string pair in dictionaryPairsList)
            {
                List<string> pairString = pair.Split(' ').ToList();
                Product newProduct = productList[Int32.Parse(pairString[0])];
                int qty = Int32.Parse(pairString[1]);
                newDictionary.Add(newProduct, qty);
            }
            return new Order(newDictionary, created, orderedBy, price);
        }
    }

        public class Stock
        {
            public List<Product> StockList { get; set; }
        }

        public class Customer
        {
            public string Name { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public string Email { get; set; }

            public Customer(string name, string phone, string address, string email)
            {
                Name = name;
                Phone = phone;
                Address = address;
                Email = email;
            }

            public override string ToString()
            {
                return this.Name;
            }
        }

        public static class PropertiesHandler
        {
            public static void Update(object obj, string[] values)
            {
                Type type = obj.GetType();
                var properties = type.GetProperties();
                int i = 0;
                foreach (var prop in properties)
                {
                    if (prop.PropertyType == typeof(int))
                    {
                        prop.SetValue(obj, Int32.Parse(values[i]));
                    }
                    else if (prop.PropertyType == typeof(decimal))
                    {
                        prop.SetValue(obj, Decimal.Parse(values[i]));
                    }
                    else
                    {
                        prop.SetValue(obj, values[i]);
                    }
                    i++;
                }
            }

            public static List<string> ObjectToList(object obj)
            {
                Type type = obj.GetType();
                var properties = type.GetProperties();
                List<string> list = new List<string>();
                foreach (var prop in properties)
                {
                    if (prop.PropertyType == typeof(int))
                    {
                        list.Add(Convert.ToString(prop.GetValue(obj)));
                    }
                    else
                    {
                        list.Add(Convert.ToString(prop.GetValue(obj)));
                    }
                }
                return list;
            }
        }

        //public static class CSVHAndler
        //{
        //    public static void WriteToCSV_Products(List<Product> productList, string path)
        //    {
        //        foreach (var product in productList)
        //        {
        //            File.AppendAllText(path, product.ToCSVString());
        //        }
        //    }

        //    public static List<Product> CSVToList_Products(string path)
        //{
        //    var productsList = new List<Product>();
        //    if (File.Exists(path))
        //    {
        //        List<string> data = File.ReadAllLines(path).ToList();
        //        foreach (string product in data)
        //        {
                    
        //        }
        //        return;
        //    }

        //}
    }

        

    

