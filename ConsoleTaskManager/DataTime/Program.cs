using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTime
{
    class Program
    {
        static void Main(string[] args)
        {
            //DateTime czas;
            //Console.Write("Podaj datę");
            //string MyString = Console.ReadLine();
            //czas = DateTime.ParseExact(MyString, "yyyy-MM-dd HH:mm tt",
            //    null);

            //DateTime dt = DateTime.ParseExact("2011-29-01 12:00 am", "yyyy-dd-MM hh:mm tt",
            //    System.Globalization.CultureInfo.InvariantCulture);

            //Console.WriteLine(dt);

            ////Convert.ToDateTime(Console.ReadLine());

            // String to DateTime


            String MyString;
            MyString = "1999-09-01 21:34";
            //MyString = "1999-09-01 21:34 p.m.";  //Depends on your regional settings

            DateTime MyDateTime;
            MyDateTime = new DateTime();
            MyDateTime = DateTime.ParseExact(MyString, "yyyy-MM-dd HH:mm", null);

            Console.WriteLine(MyDateTime);


            //DateTime temp;
            //string date = "2011-29-01 12:00 am";

            //DateTime.TryParseExact(date, "yyyy-dd-MM HH:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None,
            //    out temp);

            //Console.WriteLine(temp);



            //// String to DateTime
            //String MyString;
            //MyString = "1999-09-01 21:34 PM";
            ////MyString = "1999-09-01 21:34 p.m.";  //Depends on your regional settings

            //DateTime czas;
            //czas = new DateTime();
            //czas = DateTime.ParseExact(MyString, "yyyy-MM-dd HH:mm tt",
            //    null);



            //DateTime czas =new DateTime(2008, 5, 1, 8, 30, 52);
            //Console.Write("Podaj datę");

            //Console.WriteLine(czas);

            //DateTime date1 = new DateTime(2008, 5, 1, 8, 30, 52);
            //Console.WriteLine(date1);


            Console.ReadKey();
        }
    }
}
