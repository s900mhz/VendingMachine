using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    static class SalesLog
    {
       
    
        public static void WriteToLog(Dictionary<string, InventorySlot> currentSalesInventory)
        {
            string outputPath = Environment.CurrentDirectory;
            string outputFile = "SalesReport.txt";
            string outputFullPath = Path.Combine(outputPath, outputFile);
            var SalesInventory = CreateCurrentSalesDic(currentSalesInventory);
            var tempSalesInventory = new Dictionary<string, int>();
            var itemsPriceDic = GetItemsPrice(currentSalesInventory);
            decimal totalSales = 0;

            if (File.Exists(outputFullPath))
            {
                var OldLog = ReadFromLog();
                using (StreamWriter sw = new StreamWriter(outputFullPath, false))
                {
                    foreach (var OldLogItem in OldLog)
                    {
                        foreach (var Currentitem in SalesInventory)
                        {
                            if(OldLogItem.Key == Currentitem.Key)
                            {
                                sw.WriteLine($"{Currentitem.Key}|{Currentitem.Value + OldLogItem.Value}");
                               tempSalesInventory[Currentitem.Key] = Currentitem.Value + OldLogItem.Value;
                            }
                            
                            
                        }
                    }
                    foreach (var item in tempSalesInventory)
                    {
                        decimal price = itemsPriceDic[item.Key];
                        totalSales += price * item.Value;
                    }
                    sw.WriteLine($"Total Sales {totalSales.ToString("c")}");
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(outputFullPath, false))
                {

                    foreach (var Currentitem in SalesInventory)
                    {
                        sw.WriteLine($"{Currentitem.Key}|{Currentitem.Value}");
                        tempSalesInventory[Currentitem.Key] = Currentitem.Value;
                    }
                    foreach (var item in tempSalesInventory)
                    {
                        decimal price = itemsPriceDic[item.Key];
                        totalSales += price * item.Value;
                        
                    }
                    sw.WriteLine($"Total Sales {totalSales.ToString("c")}");
                }
            }
            
            
       
            
        }
        public static Dictionary<string, int> ReadFromLog()
        {
            string inputPath = Environment.CurrentDirectory;
            string inputFile = "SalesReport.txt";
            string inputFullPath = Path.Combine(inputPath, inputFile);
            var SalesReportDic = new Dictionary<string, int>();

            using (StreamReader sw = new StreamReader(inputFullPath, false))
            {
                while (!sw.EndOfStream)
                {
                    string line = sw.ReadLine();
                    string[] lineArray = line.Split('|');
                    if (line.Contains("Total"))
                    {
                        break;
                    }
                    SalesReportDic[lineArray[0]] = int.Parse(lineArray[1]);
                }
            }
            return SalesReportDic;
        }
        //This creates a new dictionary from the current quantity of the vending machine items that display how man are sold.
        public static Dictionary<string, int> CreateCurrentSalesDic(Dictionary<string, InventorySlot> vendingItemAndQuantity)
        {
            var currrentSales = new Dictionary<string, int>();
            foreach (var item in vendingItemAndQuantity)
            {
                int amountSold = 5 - item.Value.Quantity;
                currrentSales[item.Value.Item.ItemName] = amountSold;
            }
            return currrentSales;
        }
        public static Dictionary<string, decimal> GetItemsPrice(Dictionary<string, InventorySlot> vendingItemPrice)
        {
            var itemPriceDic = new Dictionary<string, decimal>();
            foreach (var item in vendingItemPrice)
            {
                itemPriceDic[item.Value.Item.ItemName] = item.Value.Item.Price; 
            }
            return itemPriceDic;
        }
    }
}
