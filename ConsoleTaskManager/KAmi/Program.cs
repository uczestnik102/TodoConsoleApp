using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAmi
{
    class Program
    {
        static void Main(string[] args)
        {
            private static void ShowTask(List<TaskModel> tasks)
            {
                Print1("Opis zadania", "Data Rozpoczęcia", "Data Zakończenia", "Czas Trwania", "Ważność");

                foreach (TaskModel task in tasks)
                {
                    if (!task.DateEnd.HasValue)
                    {
                        Print(task.Task, task.DateStart.ToString(), task.DateEnd.ToString(), task.TaskDuration, task.Priority);
                    }
                    else
                    {
                        Print1(task.Task, task.DateStart.ToString(), task.DateEnd.ToString(), task.TaskDuration, task.Priority);
                    }
                }

                void Print(string task, string dateStart, string dateEnd, string taskDuration, string priority)
                {
                    Console.Write(task.PadLeft(30));
                    ConsoleEx.Write("|", ConsoleColor.DarkRed);
                    Console.Write(dateStart.PadLeft(20));
                    ConsoleEx.Write("|", ConsoleColor.DarkRed);
                    Console.Write(dateEnd.PadLeft(20));
                    ConsoleEx.Write("|", ConsoleColor.DarkRed);
                    Console.Write(taskDuration.PadLeft(20));
                    ConsoleEx.Write("|", ConsoleColor.DarkRed);
                    Console.Write(priority.PadLeft(10));
                    ConsoleEx.WriteLine("|", ConsoleColor.DarkRed);
                    ConsoleEx.WriteLine("".PadLeft(120, '-'), ConsoleColor.DarkRed);
                }
                void Print1(string task, string dateStart, string dateEnd, string taskDuration, string priority)
                {
                    Console.Write(task.PadLeft(30));
                    ConsoleEx.Write("|", ConsoleColor.Green);
                    Console.Write(dateStart.PadLeft(20));
                    ConsoleEx.Write("|", ConsoleColor.Green);
                    Console.Write(dateEnd.PadLeft(20));
                    ConsoleEx.Write("|", ConsoleColor.Green);
                    Console.Write(taskDuration.PadLeft(20));
                    ConsoleEx.Write("|", ConsoleColor.Green);
                    Console.Write(priority.PadLeft(10));
                    ConsoleEx.WriteLine("|", ConsoleColor.Green);
                    ConsoleEx.WriteLine("".PadLeft(120, '-'), ConsoleColor.Green);
                }
            }

        }

    }
}
