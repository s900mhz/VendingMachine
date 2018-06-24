using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Capstone.Classes
{
    public class TransactionLog
    {
        #region Vending Log
        private static void WriteToLog(string logMessage)
        {
            //CODE_REVIEW
            //DO NOT USE PATH ROOTED for a relative file
            string outputFile = "vm-log.txt";
            if (!Path.IsPathRooted(outputFile))
            {
                outputFile = Path.Combine(Environment.CurrentDirectory, outputFile);
            }

            using (StreamWriter sw = new StreamWriter(outputFile, true))
            {
                sw.WriteLine(logMessage);
            }
        }

       public static void DepositLog(int amount, decimal currentBalance)
        {
            WriteToLog(System.DateTime.Now.ToString() +  " FEED MONEY: " + 
                       amount.ToString("c") +"  " + currentBalance.ToString("c")); 
        }

        public static void PurchaseLog(string item, string slot, decimal currentBalance, decimal price)
        {
            WriteToLog($"{System.DateTime.Now.ToString()} {item} " +
                       $"{slot} {currentBalance.ToString("c")} {(currentBalance - price).ToString("c")}");
        }
        //CODE_REVIEW
        //Write give change to the vm log
        #endregion

        
    }
   
}
