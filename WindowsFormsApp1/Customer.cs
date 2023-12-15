using System.Collections.Generic;
using System.Linq;



namespace WindowsFormsApp1
{
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
}

        

    

