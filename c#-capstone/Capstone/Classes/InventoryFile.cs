using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class InventoryFile
    {
        public static Dictionary<string, InventorySlot> CreateStartingInventory()
        {
            Dictionary<string, InventorySlot> inventoryItems = new Dictionary<string, InventorySlot>();
            
            string inventoryPath = @"C:\Workspace\team\team7-c-week4-pair-exercises\c#-capstone\etc";
            string inventoryFile = @"vendingmachine.csv";
            string fullPath = Path.Combine(inventoryPath, inventoryFile);

            var lines = File.ReadAllLines(fullPath);
            foreach (var line in lines)
            {
               string[] itemArray = line.Split('|');

                if(itemArray[3].ToString() == "Chip")
                {
                    ChipItem chip = new ChipItem(itemArray[1], decimal.Parse(itemArray[2]));
                    InventorySlot item = new InventorySlot(chip);
                    inventoryItems.Add(itemArray[0],item);

                }
                else if (itemArray[3].ToString() == "Drink")
                {
                    BeverageItem drink = new BeverageItem(itemArray[1], decimal.Parse(itemArray[2]));
                    InventorySlot item = new InventorySlot(drink);
                    inventoryItems.Add(itemArray[0], item);
                }
                else if (itemArray[3].ToString() == "Candy")
                {
                    CandyItem candy = new CandyItem(itemArray[1], decimal.Parse(itemArray[2]));
                    InventorySlot item = new InventorySlot(candy);
                    inventoryItems.Add(itemArray[0], item);
                }
                else if (itemArray[3].ToString() == "Gum")
                {
                    GumItem gum = new GumItem(itemArray[1], decimal.Parse(itemArray[2]));
                    InventorySlot item = new InventorySlot(gum);
                    inventoryItems.Add(itemArray[0], item);
                }
            }
            return inventoryItems;
        }
    }
}
