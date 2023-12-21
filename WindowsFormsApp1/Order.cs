using System;
using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsApp1
{
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

        //currently not in use, but needed to prevent errors and for future ICSVable reference implementation
        public string ToCSVString()
        {
            return null;
        }

        public Order FromCSVString(string CSVstring)
        {
            return null;
        }
    }
}

        

    

