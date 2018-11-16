using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTaskManager
{

    public static class ConsoleEx
    {

        public static void WriteLine(string message, ConsoleColor color)                          //Zad 4.3
        {
            Console.ForegroundColor = color;     
            Console.WriteLine(message);//Zad 4.3
            Console.ResetColor();                                                                 //Zad 4.3
        }

        public static void Write(string message, ConsoleColor color)                          //Zad 4.3
        {
            Console.ForegroundColor = color;      
            Console.Write(message);//Zad 4.3
            Console.ResetColor();                                                                 //Zad 4.3
        }

        //Zad 4.2
    }

}
