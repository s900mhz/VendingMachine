using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public abstract class VendingMachineItem
    {
        //Properties
        public string ItemName { get; }
        public decimal Price { get; }

        //Methods
        public abstract string Consume();
        public VendingMachineItem(string itemName, decimal price)
        {
            ItemName = itemName;
            Price = price; 
        }
    }
}
