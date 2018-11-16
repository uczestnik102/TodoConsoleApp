using System;

namespace ConsoleTaskManager
{
    public class TaskModel
    {
        //private string _description;
        //public string Description
        //{
        //    get
        //    {
        //        return _description;
        //    }
        //    set
        //    {
        //        if (value.Length < 20)
        //        {
        //            _description=value;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Zbyt długi opis");
        //            // A gdybym chciał by po zwróceniu komunikatu użytkownik był od razu w Add
        //        }
        //    }
        //}
        public string Description { get; set; }
        public DateTime BeginningDate { get; set; }
        public DateTime EndingDate { get; set; }
        public Priority Weight { get; set; }
        public bool IfDayLong { get; set; }

        public TaskModel(string description, DateTime beginningDate, DateTime endingDate, Priority importance, bool ifDayLong)
        {
            Description = description;
            BeginningDate = beginningDate;
            EndingDate = endingDate;
            IfDayLong = ifDayLong;
            Weight = importance;

            //Priority newPriority;
            //if (Priority.TryParse(importance, true, out newPriority))
            //{
            //    var Weight = newPriority;
            //}
            //else
            //{
            //    Weight = Priority.Zwykły;
            //}
        }

        public TaskModel(string description, DateTime beginningDate, Priority importance, bool ifDayLong)
        {
            Description = description;
            BeginningDate = beginningDate;
            IfDayLong = ifDayLong;
            Weight = importance;

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