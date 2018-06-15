using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class ChipItem : VendingMachineItem
    {
        public ChipItem(string itemName, decimal price) : base(itemName, price)
        {

        }
        public override void Consume()
        {
            Console.WriteLine("Crunch Crunch, Yum");
        }
    }
}
