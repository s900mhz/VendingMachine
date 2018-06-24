using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    //CODE_REVIEW
    //HOT MESS
    //Properties with get private set.
    //single constructor to pass in the value to make into change

    public class Change
    {
        public static string MakeChange(decimal currentBalance)
        {
            int _Dimes = 0;
            int _Nickels = 0;
            int _Quarters = 0;
            int remainder = 0;

            decimal PCB = currentBalance * 100;
            _Quarters = (int) PCB / 25;
            remainder = (int)PCB % 25;
            _Dimes = remainder / 10;
            remainder = remainder % 10;
            if(remainder == 5)
            {
                _Nickels = 1;
            }
            else
            {
                _Nickels = 0;
            }
            
            return $"Your change is {_Quarters} Quarters {_Dimes} Dimes {_Nickels} Nickels.";
        }
    }
}
