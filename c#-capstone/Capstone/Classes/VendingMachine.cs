using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Capstone.Classes
{   
    /// <summary>
    /// 
    /// </summary>
    public class VendingMachine
    {        
        /// <summary>
        /// 
        /// </summary>
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
  
        /// <summary>
        ///    
        /// </summary>
        /// <param name="slot"></param>
        public void PurchaseItem(string slot)
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
                    //CODE_REVIEW
                    //No console write in vendingmachine class! Keep it in the CLI
                    throw new Exception("Not enough current funds or item out of stock. \n" +
                                        "Press any key to continue.");
                }
            }
        }
        public void ResetBalance()
        {
            CurrentBalance = 0;
        }
    }
}
