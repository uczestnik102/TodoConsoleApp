using System;

namespace ConsoleTaskManager
{
    public class TaskModel
    {
        public string Description { get; set; } 
        public DateTime BeginningDate { get; set; }
        public DateTime EndingDate { get; set; }
        public bool DayLong { get; set; }
        public Priority Waga { get; set; }

        public TaskModel(string description, DateTime beginningDate, DateTime endingDate, bool dayLong, string importance)
        {
            Description = description;
            BeginningDate = beginningDate;
            EndingDate = endingDate;
            DayLong = dayLong;

            Priority tmpPriority;
            if (Priority.TryParse(importance, true, out tmpPriority))
            {
                Waga = tmpPriority;
            }
            else
            {
                Waga = Priority.Zwykły;
            }
        }

        //public TaskModel(string description, DateTime beginningDate, DateTime endingDate)
        //{
        //    Description = description;
        //    BeginningDate = beginningDate;
        //    EndingDate = endingDate;
        //}

        //public TaskModel(bool dayLong, Priority waga)
        //{
        //    DayLong = dayLong;
        //    Waga = waga;
        //}
    }
}