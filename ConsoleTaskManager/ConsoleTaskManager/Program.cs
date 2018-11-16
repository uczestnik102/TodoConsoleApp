using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            //todo: usuwanie zadań po indeksie
            //todo: zapytać czy przy wczytywaniu czyścić istniejącą listę
            //


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

                if (command == "addtask" || command == "add" || command == "1")
                {
                    AddTaskCommand(taskMenagerList);
                }

                else if (command == "removetask" || command == "remove" || command == "2")
                { }
                //{ RemoveTaskCommand(); }

                else if (command == "showtask" || command == "show" || command == "3")

                {
                    ShowTaskCommand(taskMenagerList);
                }

                else if (command == "loadtask" || command == "load" || command == "4")
                {
                    LoadTaskCommand(taskMenagerList);
                }


                else if (command == "savetask" || command == "save" || command == "5")
                {
                    SaveTaskCommand(taskMenagerList);
                }


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
            Console.WriteLine("Dodaj zadanie wg formatu: opis;data_rozpoczęcia;data_zakończenia;ważność");
            Console.WriteLine("                     lub: opis;data_rozpoczęcia;;ważność");

            Console.WriteLine(" ______________________________________________________________________________");
            Console.WriteLine("|            opis| - podaj opis nie przekraczający 20 znaków                   |");
            Console.WriteLine("|data_rozpoczęcia| - podaj datę rozpoczęcia wg formatu: rrrr.MM.dd HH.mm       |");
            Console.WriteLine("|data_zakończenia| - podaj datę zakończenia wg formatu: rrrr.MM.dd HH.mm       |");
            Console.WriteLine("|                |   (niepodaniedaty zakończenia oznacza że zadanie            |");
            Console.WriteLine("|                |   jest całodniowe)                                          |");
            Console.WriteLine("|         ważność| - określ priorytet zadania: (pilne/zwykły)                  |");
            Console.WriteLine("|______________________________________________________________________________|");




            string line = Console.ReadLine();
            Console.WriteLine(line);
            string[] data = line.Split(';');
            if (data.Length == 4)
            {
                var description = data[0];
                var beginningDate = DateTime.ParseExact(data[1], "yyyy-MM-dd HH:mm", null); //var beginningDate = DateTime.Parse(data[1]);
                var endingDate = DateTime.ParseExact(data[2], "yyyy-MM-dd HH:mm", null);    //var endDate = DateTime.Parse(data[2]);

                var importance = data[3];
                Priority pr = Priority.Zwykły;
                switch (importance.ToLower())
                {
                    case "pilne":
                        pr = Priority.Pilne;
                        break;
                }
                var ifDayLong = bool.Parse("false");

                if (description.Length > 20)
                {
                    Console.WriteLine("Zbyt długa nazwa zadania. Proszę podać nazwę zadania nie przekraczającą 20 znaków");
                }

                TaskModel task = new TaskModel(description, beginningDate, endingDate, pr, ifDayLong);
                taskMenagerList.Add(task);

            }

            if (data.Length == 3)
            {
                var description = data[0];
                var beginningDate = DateTime.ParseExact(data[1], "yyyy-MM-dd HH:mm", null); //var beginningDate = DateTime.Parse(data[1]);
                var endingDate = beginningDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

                var importance = data[2];
                Priority pr = Priority.Zwykły;
                switch (importance.ToLower())
                {
                    case "pilne":
                        pr = Priority.Pilne;
                        break;
                }
                var ifDayLong = bool.Parse("true");

                TaskModel task = new TaskModel(description, beginningDate, endingDate, pr, ifDayLong);
                taskMenagerList.Add(task);

            }


        }
        //niestatyczne działają na instancji klasy
        //statyczne przypisane do klasy

        //  public static void sorter()
        //wybierz sortowanie
        //If po weight
        //return ShowTaskCommand( taskMenagerList.orderby)//
        //if inny



        public static void ShowTaskCommand(List<TaskModel> taskMenagerList)
        {
            Console.Clear();

            Console.WriteLine(" _________________________________________________________________________________________________________________");
            Console.WriteLine("|                                     |                     |                      |                    |         |");
            Console.WriteLine("| Id |                   Opis zadania |   Data rozpoczęcia  |   Data zakończenia   |    Czas trwania    | Ważność |");
            Console.WriteLine("|_____________________________________|_____________________|___________________ __|____________________|_________|");
            Console.WriteLine("|                                     |                     |                      |                    |         |");
            var index = 0;
            foreach (var row in taskMenagerList)
            //foreach (var row in taskMenagerList.OrderBy(x => x.Weight))
                {
                index++;

                if (row.Weight.ToString() == "Pilne")
                {
                    Console.Write("| ", ConsoleColor.DarkRed);
                    Console.Write(index.ToString());
                    if (index <= 9)
                    {
                        Console.Write("  | ");
                    }
                    else
                    {
                        Console.Write(" | ");
                    }

                    ConsoleEx.Write(row.Description.PadLeft(30), ConsoleColor.DarkRed);
                    Console.Write(" |   ");
                    ConsoleEx.Write($"{row.BeginningDate.ToString("yyyy-MM-dd HH:mm") }", ConsoleColor.DarkRed);
                    Console.Write("  |   ");
                    ConsoleEx.Write($"{row.EndingDate.ToString("yyyy-MM-dd HH:mm")}", ConsoleColor.DarkRed);
                    Console.Write("   | ");
                    if (row.IfDayLong)
                    {
                        ConsoleEx.Write("Zadanie całodniowe", ConsoleColor.DarkRed);
                    }
                    else
                    {
                        Console.Write("                  ");
                    }
                    Console.Write(" |  ");
                    ConsoleEx.Write(row.Weight.ToString(), ConsoleColor.DarkRed);
                    Console.WriteLine("  |");
                    Console.WriteLine("|-------------------------------------+---------------------+----------------------+--------------------+---------|");
                }
                else
                {
                    Console.Write("| ");
                    Console.Write(index.ToString());
                    if (index <= 9)
                    {
                        Console.Write("  | ");
                    }
                    else
                    {
                        Console.Write(" | ");
                    }
                    ConsoleEx.Write(row.Description.PadLeft(30), ConsoleColor.DarkGreen);
                    Console.Write(" |   ");
                    ConsoleEx.Write($"{row.BeginningDate.ToString("yyyy-MM-dd HH:mm") }", ConsoleColor.DarkGreen);
                    Console.Write("  |   ");
                    ConsoleEx.Write($"{row.EndingDate.ToString("yyyy-MM-dd HH:mm")}", ConsoleColor.DarkGreen);
                    Console.Write("   | ");
                    if (row.IfDayLong)
                    {
                        ConsoleEx.Write("Zadanie całodniowe", ConsoleColor.DarkGreen);
                    }
                    else
                    {
                        Console.Write("                  ");
                    }
                    Console.Write(" |  ", ConsoleColor.DarkRed);
                    ConsoleEx.Write(row.Weight.ToString(), ConsoleColor.DarkGreen);
                    Console.WriteLine(" |", ConsoleColor.DarkRed);
                    Console.WriteLine("|-------------------------------------+---------------------+----------------------+--------------------+---------|");
                }

            }
        }

        public static void SaveTaskCommand(List<TaskModel> taskMenagerList)
        {
            Console.WriteLine("saave");

            string tekst = "";
            foreach (var row in taskMenagerList)
            {
                tekst += string.Format("{0};{1};{2};{3};{4} " + Environment.NewLine, row.Description, row.BeginningDate.ToString("yyyy-MM-dd HH:dd"), row.EndingDate.ToString("yyyy-MM-dd HH:dd"),
                    row.Weight, row.IfDayLong);

            }
            File.WriteAllText("data.txt", tekst);
        }

        //strimwriter zapisywanie pliku



        public static void LoadTaskCommand(List<TaskModel> taskMenagerList)
        {
            Console.Write("Podaj ścieżkę i nazwę pliku do wczytania( lub wciśnij enter): ");
            var path = Console.ReadLine();

            if (path == "")
            {
                path = "data.txt";
            }


            string[] loadTable;
            loadTable = File.ReadAllLines(path);

            var counter = 0;
            foreach (var line in loadTable)
            {
                string[] data = line.Split(';');
                var description = data[0];
                var beginningDate = DateTime.ParseExact(data[1], "yyyy-MM-dd HH:mm", null); //var beginningDate = DateTime.Parse(data[1]);
                var endingDate = DateTime.ParseExact(data[2], "yyyy-MM-dd HH:mm", null);    //var endDate = DateTime.Parse(data[2]);

                var importance = data[3];
                Priority pr = Priority.Zwykły;
                switch (importance.ToLower())
                {
                    case "pilne":
                        pr = Priority.Pilne;
                        break;
                }

                var ifDayLong = bool.Parse("false");

                TaskModel task = new TaskModel(description, beginningDate, endingDate, pr, ifDayLong);

                taskMenagerList.Add(task);
                counter++;
            
            }
            Console.WriteLine($"Liczba wczytanych zadań: {counter}");


            //Console.WriteLine(loadTable[0]);
            //Console.WriteLine(loadTable[1]);
            //Console.WriteLine(loadTable[2]);
            //Console.WriteLine(loadTable[3]);
            //Console.WriteLine(loadTable[4]);
            //Console.WriteLine(loadTable[5]);







            //var i = 0;
            //foreach (var row in loadTable)
            //{
            //    taskMenagerList[i] = loadTable;
            //    i++;
            //}

            //var i = 0;     
            //foreach (var row in taskMenagerList)
            //{
            //    taskMenagerList[i] = loadTable[i];
            //    i++;
            //}

            //for (int j = 0; j < loadTable.Length; j++)
            //{
            //    taskMenagerList[j] = loadTable[j];
            //}


            //var i = 0;
            //foreach (var row in loadTable)
            //{
            //    taskMenagerList[i] = row;
            //    i++;
            //}

            //var i = 0;
            //foreach (var row in loadTable)
            //{
            //    taskMenagerList.Add() = row;
            //    i++;
            //}


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
            Console.WriteLine($"Dostępne polecenia:\n 1 AddTask(or Add), \n 2 RemoveTask(or Remove), \n 3 ShowTask(or Show), \n 4 LoadTask(or Load), \n 5 SaveTask(or Save), \n   HelpTask(or help)");

        }
    }
}



