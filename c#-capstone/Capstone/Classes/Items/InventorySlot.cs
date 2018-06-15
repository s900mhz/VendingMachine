using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class InventorySlot
    {
        public VendingMachineItem Item { get; set; }
        public int Quantity { get; set; }

        //Constructor
        public InventorySlot(VendingMachineItem item)
        {
            Item = item;
            Quantity =  5;
        }

    }
}
