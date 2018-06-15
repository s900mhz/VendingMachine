using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Capstone.Classes.Items;

namespace Capstone.Classes
{
    public class InventoryFile
    {
        

        public static List<string> GetInventory()
        {
            List<string> inventoryLineList = new List<string>();

            string inventoryPath = @"C:\Workspace\team\team7-c-week4-pair-exercises\c#-capstone\etc";
            string inventoryFile = @"vendingmachine.csv";
            string fullPath = Path.Combine(inventoryPath, inventoryFile);
            using (StreamReader sr = new StreamReader(fullPath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    inventoryLineList.Add(line);
                    
                }
                return inventoryLineList;
            }
        }
        public static Dictionary<string, VendingMachineItem> CreateStartingInventory()
        {
            Dictionary<string, VendingMachineItem> inventoryItems = new Dictionary<string, VendingMachineItem>();
            foreach (var item in GetInventory())
            {
               string[] itemArray = item.Split('|');

                if(itemArray[3].ToString() == "Chip")
                {
                    ChipItem chip = new ChipItem(itemArray[1], decimal.Parse(itemArray[2]));
                    inventoryItems.Add(itemArray[0],chip);

                }
                else if (itemArray[3].ToString() == "Drink")
                {
                    BeverageItem drink = new BeverageItem(itemArray[1], decimal.Parse(itemArray[2]));
                    inventoryItems.Add(itemArray[0], drink);
                }
                else if (itemArray[3].ToString() == "Candy")
                {
                    CandyItem candy = new CandyItem(itemArray[1], decimal.Parse(itemArray[2]));
                    inventoryItems.Add(itemArray[0], candy);
                }
                else if (itemArray[3].ToString() == "Gum")
                {
                    GumItem gum = new GumItem(itemArray[1], decimal.Parse(itemArray[2]));
                    inventoryItems.Add(itemArray[0], gum);
                }
            }
            return inventoryItems;
        }
    }
}
