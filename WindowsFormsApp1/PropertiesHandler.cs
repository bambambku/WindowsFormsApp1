using System;
using System.Collections.Generic;

namespace WindowsFormsApp1
{
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
}

        

    

