﻿using System;
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
        //Constructor
        public InventorySlot(VendingMachineItem item)
        {
            Item = item;
           
        }

    }
}
