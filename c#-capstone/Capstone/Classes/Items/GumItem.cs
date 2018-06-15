﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class GumItem : VendingMachineItem
    {
        public GumItem(string itemName, decimal price) : base(itemName, price)
        {

        }
        public override void Consume()
        {
           Console.WriteLine("CHEKW CHEKW, YAY");
        }
        
    }
}
