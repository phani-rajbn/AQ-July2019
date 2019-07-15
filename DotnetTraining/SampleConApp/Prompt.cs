using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    //static at the class declarations makes the class not instantiatable. This class contains only static methods and U dont need an object for invoking those methods. 
    static class Prompt
    {
        public static string GetString(string statement)
        {
            Console.WriteLine(statement);
            return Console.ReadLine();
        }

        public static int GetNumber(string statement)
        {
            return int.Parse(GetString(statement));
        }

        public static DateTime GetDate(String statement)
        {
            return DateTime.Parse(GetString(statement));
        }

        public static double GetDouble(string statement)
        {
            return Double.Parse(GetString(statement));
        }
    }
}
