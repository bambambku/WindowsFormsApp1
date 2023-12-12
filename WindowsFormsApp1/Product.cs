using System;
using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsApp1
{
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
            Price = Decimal.Round(price, 2);

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
}

        

    

