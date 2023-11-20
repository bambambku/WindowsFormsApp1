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

        public void ReadCSV(string csvPath)
        {

        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }

        public Product(string name, string description, string category, int qty, int price)
        {

        }
    }

    

    public class Order
    {
        public int ID { get; set; }
        public List<Product> ProductList { get; set; }
        public DateTime DateCreated { get; set; }
        public Customer OrderedBy { get; set; }
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

    }

    public static class PropertiesUpdater
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
                else
                {
                    prop.SetValue(obj, values[i]);
                }
                i++;
            }

        }
    }

}
