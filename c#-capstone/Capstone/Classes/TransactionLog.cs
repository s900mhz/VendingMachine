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
       private static void WriteToLog(string logMessage)
        {
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
            WriteToLog(System.DateTime.Now.ToString() +  " FEED MONEY: " + amount.ToString("c") +"  " + currentBalance.ToString("c")); 
        }
    }
   
}
