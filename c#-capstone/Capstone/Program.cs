using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes.Items;
using Capstone.Classes.Exceptions;
using Capstone.Classes;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachineCLI newMachine = new VendingMachineCLI();
            newMachine.Run();
        }
    }
}
