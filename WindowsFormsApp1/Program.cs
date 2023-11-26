using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

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

        public void AddCustomer(int ID, string name, string phone, string address, string email)
        {

                List.Add(new Customer(ID, name, phone, address, email));
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }

        public Product(int id, string name, string description, string category, int qty, decimal price)
        {
            Id = id;
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
    }

    

    public class Order
    {
        public int ID { get; set; }
        public Dictionary<Product, int> ProductOrderDictionary { get; set; }
        public DateTime DateCreated { get; set; }
        public Customer ByCustomer { get; set; }
        public decimal Price { get; set; }

        public Order(int id, Dictionary<Product, int> productOrderDictionary, DateTime datecreated, Customer byCustomer)
        {
            id = ID;
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
    }

    public class Stock
    {
        public List<Product> StockList { get; set; }
    }


    //public static class CSV
    //{
    //    public void ReadCSV(string csvPath, object Object, func )
    //    {
    //        if (File.Exists(path))
    //        {
    //            List<string> data = File.ReadAllLines(path).ToList();

    //        }

    //    }
    //}

    public static class ObjectMeddling
    {
        public static void Add<T>(this List<T> list, T item)
        {
            list.Add(item);
        }
    }

    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public Customer(int ID, string name, string phone, string address, string email)
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
                } else if (prop.PropertyType == typeof(decimal))
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

    public static class CSVHAndler
    {
     
    }

}
