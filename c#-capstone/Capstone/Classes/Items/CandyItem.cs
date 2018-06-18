using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class CandyItem : VendingMachineItem
    {
        public CandyItem(string itemName, decimal price) : base(itemName, price)
        {

        }
        public override string Consume()
        {
            return "Munch Munch, Yum!";
        }
    }
}
