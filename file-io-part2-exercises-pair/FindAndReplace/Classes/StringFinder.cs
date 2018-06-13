using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindAndReplace.Classes;

namespace FindAndReplace.Classes
{
    public class StringFinder
    {
        //Asking user to input the string to search
        static public string GetFindString()
        {
            Console.WriteLine("What string would you like to search? ");
            string userSearchString = Console.ReadLine();

            return userSearchString;
        }

        public static string GetReplaceString()
        {
            Console.WriteLine("What would you like to replace your string with? ");
            string userReplaceString = Console.ReadLine();

            return userReplaceString;
        }
    }
}
