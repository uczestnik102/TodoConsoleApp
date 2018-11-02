using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaskModel> taskMenagerList = new List<TaskModel>();
            string command = "";
            do
            {
                Console.Write("Wpisz tekst: ");
                command = Console.ReadLine().ToLower();
                if (command == "exit")
                {
                    return;
                }

                if (command == "addtask" || command == "add")
                {
                    AddTaskCommand(taskMenagerList);
                }

                else if (command == "removetask" || command == "remove")
                { }
                //{ RemoveTaskCommand(); }

                else if (command == "showtask" || command == "show")
                { }
                //{ ShowTaskCommand(); }

                else if (command == "savetask" || command == "save")
                { }
                //{ SaveTaskCommand(); }

                else if (command == "deletetask" || command == "delete")
                { }
                //{ DeleteTaskCommand(); }

                else if (command == "helptask" || command == "help")
                {
                    HelpTask();
                }
                else
                {
                    Console.WriteLine("Nieprawidłowa komenda. For help write \"help\"");
                }





            } while (true);
        }

        public static void AddTaskCommand(List<TaskModel> taskMenagerList)
        {
            Console.WriteLine("Dodaj wydatek wg formatu: opis;data_rozpoczęcia;data_zakończenia;ważność");
            Console.WriteLine("                     lub: opis;data_rozpoczęcia;;ważność");

            Console.WriteLine(" ______________________________________________________________________________");
            Console.WriteLine("|            opis| - podaj opis nie przekraczający 20 znaków                   |");
            Console.WriteLine("|data_rozpoczęcia| - podaj datę rozpoczęcia wg formatu: dd.mm.rrrr             |");
            Console.WriteLine("|data_zakończenia| - podaj datę zakończenia wg formatu: dd.mm.rrrr (niepodanie |");
            Console.WriteLine("|                |   daty zakończenia oznacza że zadanie jest całodniowe)      |");
            Console.WriteLine("|         ważność| - określ priorytet zadania: (pilne/zwykły)                  |");
            Console.WriteLine("|______________________________________________________________________________|");


            string line = Console.ReadLine();
            line = line + ';';
            Console.WriteLine(line);
            string[] data = line.Split(';');
            if (data.Length == 5)
            {
                var opis = data[0];
                var startDate = DateTime.Parse(data[1]);
                var endDate = DateTime.Parse(data[2]);

                TaskModel task = new TaskModel(opis, startDate, endDate, startDate == endDate, data[4]);
                //TaskModel task = new TaskModel(opis, startDate, endDate, startDate == endDate, Priority.Pilne);
                //askModel task = new TaskModel(data[0], DateTime.Parse(data[1]), DateTime.Parse(data[2]), , Boolean.Parse(data[3]));
            }

            //TaskModel tm1 = new TaskModel(true, Priority.Pilne);
            //var tm2 = new TaskModel("asdf", DateTime.Now, DateTime.Now.AddDays(1));

        }




        //public static void AddTaskCommand(List<TaskModel> taskMenagerList) 
        //                                                                   
        //{
        //    do
        //    {
        //        Console.WriteLine("Podaj opis zadania: (max. 20 znaków");
        //        string opis = Console.ReadLine();
        //        if (opis.Length > 20)
        //        {
        //            Console.WriteLine("Opis jest za długi. Podaj krótszy opis: ");
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    } while (true);

        //    Console.WriteLine("Czy zadanie jest całodniowe (T/N): ");
        //    string allDaySt = Console.ReadLine().ToLower();
        //    if (allDaySt == "t")
        //    {
        //        bool allDay = true;
        //        Console.WriteLine("Oznaczono zadanie jako całodniowe");
        //    }
        //    else if (allDaySt == "n")
        //    {
        //        bool allDay = false;
        //        Console.WriteLine("Oznaczono zadanie jako niecałodniowe");
        //    }
        //    else
        //    {
        //        bool allDay = false;
        //        Console.WriteLine("Oznaczono zadanie jako całodniowe");
        //    }



        //}

        public static void HelpTask()
        {
            Console.WriteLine("Dostępne polecenia:AddTask(or Add), RemoveTask(or Remove), ShowTask(or Show), SaveTask(or Save), DeleteTask(or Del), HelpTask(or help)");

        }
    }
}




//if (Console.ReadLine() == "AddTask")
//{
//Console.WriteLine("asas");
