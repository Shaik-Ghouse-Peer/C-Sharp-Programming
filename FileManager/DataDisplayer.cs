using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    class DataDisplayer
    {
        public static void DisplayRecievedData(string[] data)
        {
            if (data != null)
            {
                foreach (string line in data)
                {
                    Console.WriteLine(line);
                }
                Console.WriteLine("-----------------------------------------\n");
            }
            else
            {
                Console.WriteLine("\nINFO: File Is Empty\n");
            }
        }
        public static void DisplayRecievedData(string data)
        {
            if (data != null)
            {
                Console.WriteLine(data);
                Console.WriteLine("-----------------------------------------\n");
            }
            else
            {
                Console.WriteLine("\nINFO: File Is Empty\n");
            }
        }
    }
}
