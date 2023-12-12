﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WindowsFormsApp1
{
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

        

    
