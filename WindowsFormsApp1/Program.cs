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

    public interface ICSVable<T>
    {
        string ToCSVString();
        T FromCSVString(string CSVstring);
    }

    public class Product : ICSVable<Product>
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

        public Product FromCSVString(string CSVstring)
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

    public class Order : ICSVable<Order>
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
            Price = GetPrice(productOrderDictionary);
        }

        public decimal GetPrice(Dictionary<Product, int> productOrderDictionary)
        {
            decimal price = 0;
            if (productOrderDictionary == null)
            {
                price = 0;
            }
            else
            {
                foreach (var kvp in productOrderDictionary)
                {
                    price += kvp.Key.Price * kvp.Value;
                }
            }
            return price;
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
            return $"{dictionaryProduct},{dateCreated},{customerIndex}";
        }

        public Order FromCSVString(string CSVstring, List<Product> productList, List<Customer> customerList)
        {
            List<string> data = CSVstring.Split(',').ToList();
            string dictionaryProductString = data[0];
            DateTime created = DateTime.Parse(data[1]);
            Customer orderedBy = customerList[Int32.Parse(data[2])];
            List<string> dictionaryPairsList = dictionaryProductString.Split(';').ToList();
            Dictionary<Product, int> newDictionary = new Dictionary<Product, int>();
            foreach (string pair in dictionaryPairsList)
            {
                if (pair == "") continue;
                List<string> pairString = pair.Split(' ').ToList();
                Product newProduct = productList[Int32.Parse(pairString[0])];
                int qty = Int32.Parse(pairString[1]);
                newDictionary.Add(newProduct, qty);
            }
            return new Order(newDictionary, created, orderedBy);
        }

        public string ToCSVString()
        {
            return null;
        }

        public Order FromCSVString(string CSVstring)
        {
            return null;
        }
    }

    public class Customer : ICSVable<Customer>
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
            return Name;
        }

        public string ToCSVString()
        {
            return $"{Name},{Phone},{Address},{Email}";
        }

        public Customer FromCSVString(string CSVstring)
        {
            List<string> properties = CSVstring.Split(',').ToList();
            string name = properties[0];
            string phone = properties[1];
            string address = properties[2];
            string email = properties[3];
            return new Customer(name, phone, address, email);
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

    public static class CSVHandler
    {

        public static List<string> Read(string path)
        {
            string fullPath = $"C:\\Users\\bamba\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\{path}";
            if (File.Exists(fullPath))
            {
                return File.ReadAllLines(fullPath).ToList();
            }
            else
            {
                return null;
            }
        }

        public static void Write(string path, string data)
        {
            //File.WriteAllText(path,data);
            string fullPath = $"C:\\Users\\bamba\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\{path}";
            File.WriteAllText(fullPath, data);
            try
            {
                File.WriteAllText(path, data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static string ListToString(List<string> list)
        {
            string newString = "";
            foreach (var item in list)
            {
                newString += ($"{item}\n");
            }
            return newString;
        }
    }
}

        

    

