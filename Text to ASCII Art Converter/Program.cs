using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_to_ASCII_Art_Converter
{
    using System.Runtime.InteropServices;

    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            Translator t = new Translator();
            t.LoadAlphabet("default.txt");

            while (!exit)
            {
                Console.WriteLine("Please input the message you want to be converted(\"EXIT\" to exit):");
                string message = "";
                while(message == "")
                    message = Console.ReadLine();

                if (message == "EXIT")
                    exit = true;
                else
                {

                    t.WriteMessage(message);
                    Console.WriteLine();
                }
            }
            
        }
    }
}
