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
        #endregion

        #region Sales Log

        public static void WriteToSalesLog(Dictionary<string, InventorySlot> soldInventory )
        {
            string salesMessage = "";
            string outputFile = "sales-log.txt";
            bool fileExists = File.Exists(outputFile);
            if (!fileExists)
            { //take current inventory and set to 0;
                try
                {
                    if (!Path.IsPathRooted(outputFile))
                    {
                        outputFile = Path.Combine(Environment.CurrentDirectory, outputFile);
                        using (StreamWriter sw = new StreamWriter(outputFile, false))
                        {
                            sw.WriteLine(salesMessage);
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Error with printing file directory.");
                }
            }
            if (fileExists)
            {
                Dictionary<string, int> oldInventoryLog = new Dictionary<string, int>();
                Dictionary<string, int> updatedInventoryLog = new Dictionary<string, int>();
                try
                {
                    using (StreamReader line = new StreamReader(outputFile))
                    {

                        while (!line.EndOfStream)
                        {
                            string newLine = line.ReadLine();
                            string[] newLineArray = newLine.Split('|');
                            oldInventoryLog.Add(newLineArray[0], int.Parse(newLineArray[1]));
                        }
                        foreach (var soldItem in soldInventory)
                        {
                            foreach (var SalesReportItem in oldInventoryLog)
                            {
                                using (StreamWriter sw = new StreamWriter(outputFile,true))
                                {
                                    if (soldItem.Equals(SalesReportItem))
                                    {
                                        updatedInventoryLog.Add(SalesReportItem.Key, 
                                            soldItem.Value.Quantity + SalesReportItem.Value);
                                        sw.WriteLine(updatedInventoryLog.Keys.ToString() + 
                                            '|' + updatedInventoryLog.Values);
                                        //sw.WriteLine(SalesReportItem.Key);
                                        //sw.WriteLine(soldItem.Value.Quantity + SalesReportItem.Value);
                                    }
                                    else
                                    {
                                        sw.WriteLine(soldInventory.Keys.ToString() + 
                                            '|' + soldInventory.Values);
                                    }
                                }
                            }
                        }
                        
                    }
                }
                catch
                {
                    Console.WriteLine("File exists or other issue with file writing.");
                }
            }
        }
        #endregion
    }
   
}
