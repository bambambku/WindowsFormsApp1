using System;
using System.Reflection;

//Customer customer1 = new("Frames Ltd", "07456546456", "13 Barnsley Road, WF92LD, Pontefract", "frames@gmail.com");
//Customer customer2 = new("Barabash", "7845654654", "52 Peackock Crescent, LS113LS, Leeds", "barabash@gmail.com");
//Customer customer3 = new("Galagan", "786943513413", "12 Harness Hill, WF32LP, Stanley", "galagan@outlook.com");
//Customer customer4 = new("SinkAndSwallow", "78465343126", "67 Bodyguard Road, WF63GD, Castleford", "SAS@gmail.com");
//Customer customer5 = new("AlabamaCollapse", "78641356645", "1 Diggy Road, WF52HG, Outwood", "AlabamaCollapse@gmail.com");

public CustomerList newCustomerList = new();
newCustomerList.AddCustomer(101, "Frames Ltd", "07456546456", "13 Barnsley Road, WF92LD, Pontefract", "frames@gmail.com")

public List<Customer> customerList = {customer1, customer2,  customer3, customer4, customer5};
ObjectMeddling.Add<Customer>(newCustomerList.List,
	new Customer(102, "Barabash", "7845654654", "52 Peackock Crescent, LS113LS, Leeds", "barabash@gmail.com"));

namespace CLasses {
	public class CustomerList
	{
		public CustomerList<Customer> List { get; set; }

		public void AddCustomer(int ID, string name, string phone, string address, string email)
		{
			if (List == null)
			{
				List.Add(new Customer(ID, name, phone, address, email));
			}
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

	public class Customer
	{
		int ID { get; set; }
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


	public static class CSV
	{
		public void ReadCSV(string csvPath, object Object, func )
		{
			if (File.Exists(path))
			{
				List<string> data = File.ReadAllLines(path).ToList();

			}

		}
	}

	public static class ObjectMeddling
	{
		public static void Add<T>(this List<T> list, T item)
		{
			list.Add(item);
		}
	}

	public static class ObjectPropertiesUpdater
	{
		public string Update(object obj, string[] values)
		{
			Type type = obj.GetType();
			var properties = type.GetProperties();
			foreach ( var prop in properties ) 
			{
				int i = 0;
                prop.SetValue(obj, values[i]);
				i++;
            }
			
		}
	}

}