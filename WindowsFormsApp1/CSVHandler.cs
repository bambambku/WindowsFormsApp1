using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WindowsFormsApp1
{
    public static class CSVHandler
    {

        public static List<string> Read(string path)
        {
            if (File.Exists(path))
            {
                return File.ReadAllLines(path).ToList();
            }
            else
            {
                return null;
            }
        }

        public static void Write(string path, string data)
        {
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

        

    

