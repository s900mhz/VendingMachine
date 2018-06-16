using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class InventorySlot
    {
        //private int _quantity;
        public VendingMachineItem Item { get; set; }
        public int Quantity { get; set; } = 5;
        //{
        //    get
        //    {
        //        if(_quantity > 0)
        //        {
        //            return _quantity;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Sold Out");
        //            return 0;
        //        }
        //    }
        //    set
        //    {
        //        _quantity = Quantity;
        //    }
        //}
        //Constructor
        public InventorySlot(VendingMachineItem item)
        {
            Item = item;
           
        }

    }
}
