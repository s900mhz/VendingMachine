using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Capstone.Classes
{
    public class VendingMachineCLI
    {
        
        private VendingMachine _vm = null;
        
        public VendingMachineCLI(VendingMachine vm)
        {
            _vm = vm;
        }
        #region Methods

        /// <summary>
        /// Console display for purchasing items. Needs updated to set current items called in loop so 
        /// program isn't searching each time for that particular instance multiple times 
        /// (e.g. line 34 item.Key.PadRight(3) set to a local variable that's then referenced *once* during
        /// current iteration.
        /// </summary>
        /// <param name="exit"></param>
        public void DisplayInventory(bool exit)
        {
            string padding = "";
            Console.Clear();
            Console.WriteLine($"Slot {padding.PadRight(1)} Item {padding.PadRight(12)}" +
                              $"Price {padding.PadRight(2)} Quantity");
            Console.WriteLine($"----------------------------------------");
            foreach (KeyValuePair<string, InventorySlot> item in _vm.Inventory)
            {
            Console.WriteLine($"{item.Key.PadRight(3)} {item.Value.Item.ItemName.PadRight(20)} " +
                $"{item.Value.Item.Price.ToString().PadRight(10)} {item.Value.Qty.PadRight(10)}");
            }
            Console.WriteLine($"Available balance: {_vm.CurrentBalance.ToString("c")}");
            Console.WriteLine("Press any key to continue: ");
        }
        #endregion
        #region Display Purchase Menu
        public void DisplayPurchaseMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("(1) Feed Money \n" +
                                  "(2) Select Product \n" +
                                  "(3) Finish Transaction");
                Console.WriteLine($"Available balance: {_vm.CurrentBalance.ToString("c")}");
                string navigation = Console.ReadLine();

                if (navigation == "1")
                {
                    FeedMoneyMenu();
                }
                else if (navigation == "2")
                {
                    PurchaseProduct();
                }
                else if (navigation == "3")
                {
                    Change.MakeChange(_vm.CurrentBalance);
                    Console.WriteLine("Your returned balance is" +
                        ": " + _vm.CurrentBalance.ToString("c"));
                    Console.WriteLine(Change.MakeChange(_vm.CurrentBalance));
                    TransactionLog.ChangeLog(_vm.CurrentBalance);
                    _vm.ResetBalance();
                    SalesLog.WriteToLog(_vm.Inventory);
                    Console.ReadKey();
                    exit = true;
                }
            }
        }
        #endregion
        private void PurchaseProduct()
        {
            bool exit = false;
            while (!exit)
            {
                DisplayInventory(false);
                Console.WriteLine();
                Console.WriteLine("Please select your product or press b to go back: ");
                string productSelection = Console.ReadLine();
                if (productSelection == "b" || productSelection == "B")
                {
                    exit = true;
                }
                else
                {
                    productSelection = productSelection.ToUpper();
                    _vm.PurchaseItem(productSelection);
                }
            }
        }
        public Dictionary<string, InventorySlot> GetCurrentInventory()
        {
            return _vm.Inventory;
        }
        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("(1) Display Vending Machine Items \n" +
                                  "(2) Purchase\n" +
                                  "(3) Quit");
                Console.WriteLine();
                Console.WriteLine($"Available balance: {_vm.CurrentBalance.ToString("c")}");

                char navigation = Console.ReadKey().KeyChar;

                if (navigation == '1')
                {
                    DisplayInventory(true);
                    Console.ReadKey();
                }
                else if (navigation == '2')
                {
                    DisplayPurchaseMenu();
                }
                else if (navigation == '3')
                {
                    exit = true;
                }
            }
        }

        #region Feed Money Menu
        public void FeedMoneyMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
            Console.WriteLine("How much money would you like to insert?");
            Console.WriteLine("(1) $1");
            Console.WriteLine("(2) $2");
            Console.WriteLine("(5) $5");
            Console.WriteLine("(10) $10");
            Console.WriteLine($"Available balance: {_vm.CurrentBalance.ToString("c")}");
            Console.WriteLine();
            Console.WriteLine($"To return to previous menu press \"b\"");
            
           
           string navigation = Console.ReadLine();
            
           
                if (navigation == "1")
                {
                    _vm.FeedMoney(1);
                    TransactionLog.DepositLog(1, _vm.CurrentBalance);
                }
                else if (navigation == "2")
                {
                    _vm.FeedMoney(2);
                    TransactionLog.DepositLog(2, _vm.CurrentBalance);
                }
                else if (navigation == "5")
                {
                    _vm.FeedMoney(5);
                    TransactionLog.DepositLog(5, _vm.CurrentBalance);
                }
                else if (navigation == "10")
                {
                    _vm.FeedMoney(10);
                    TransactionLog.DepositLog(10, _vm.CurrentBalance);
                }
                else if (navigation == "b" || navigation == "B")
                { 
                    exit = true;
                }
            }

        }
        #endregion
    }
}
