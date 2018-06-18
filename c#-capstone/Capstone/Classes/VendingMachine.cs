using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Capstone.Classes
{   
    public class VendingMachine
    {
        public decimal currentBalance = 0;
        public decimal CurrentBalance { get; private set; }
        
        public Dictionary<string, InventorySlot> Inventory { get; } = null;

        //Constructor
        public VendingMachine()
        {
            Inventory = InventoryFile.CreateStartingInventory();
        }
        public void FeedMoney(int dollars)
        {

            CurrentBalance += dollars;
        }

        //public Dictionary<string, InventorySlot> GetVendingInventory()
        //{
        //    //This is only passed to Transaction Log
        //    return Inventory;
        //}

        public void PurchaseItem(string slot)
        {
            try
            {

                if (Inventory.Keys.Contains(slot))
                {
                    if (CurrentBalance > Inventory[slot].Item.Price && Inventory[slot].Quantity > 0)
                    {
                        Inventory[slot].Quantity -= 1;
                        CurrentBalance -= Inventory[slot].Item.Price;
                        TransactionLog.PurchaseLog(Inventory[slot].Item.ItemName, slot,
                                                   CurrentBalance, Inventory[slot].Item.Price);

                    }
                    else
                    {
                        Console.WriteLine("Not enough current funds or item out of stock. \n" +
                                          "Press any key to continue.");
                        Console.ReadKey();
                    }
                }
            }
            catch
            {
                Console.WriteLine("That is not a valid entry. Please try again");
            }
        }
        public void ResetBalance()
        {
            CurrentBalance = 0;
        }
    }
}
