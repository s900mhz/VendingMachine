using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes.Items;

namespace Capstone.Classes
{
    public abstract class VendingMachineItem
    {
        //Member variables
        public string _itemName;
        public decimal _priceInCents;

        //Properties
        public string ItemName { get; }
        public decimal Price { get; }

        //Methods
        public abstract void Consume();
        public VendingMachineItem(string itemName, decimal price)
        {
            _itemName = itemName;
            _priceInCents = price; 
        }
    }
}
