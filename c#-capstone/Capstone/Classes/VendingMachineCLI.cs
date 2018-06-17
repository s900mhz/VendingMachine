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

        
        public void DisplayInventory(bool exit)
        {
            
            Console.Clear();
            Console.WriteLine($"Slot \t Item \t\t Price \t Quantity");
            foreach (KeyValuePair<string, InventorySlot> item in _vm.Inventory)
            {
                var printQuantity = item.Value.Quantity.ToString();
                if(item.Value.Quantity < 1)
                {
                    printQuantity = "SOLD OUT";
                }

                //Console.WriteLine("{15, 32}{15,32}", item.Key + item.Value.Item.ItemName + item.Value.Item.Price);
                Console.WriteLine($"{item.Key} \t {item.Value.Item.ItemName} \t {item.Value.Item.Price}" +
                    $" \t {printQuantity}");
                //Console.WriteLine("{0,-10}", item.Key, item.Value.Item.ItemName, item.Value.Item.Price, item.Value.Quantity);
            }
            Console.WriteLine($"Available balance: {_vm.CurrentBalance.ToString("c")}");
            Console.WriteLine("Press any key to continue: ");
            
            if (exit)
            {
                Console.ReadKey();
                Run();

            }
            
        }
        #endregion
        #region Display Purchase Menu
        public void DisplayPurchaseMenu()
        {
            Console.Clear();
            Console.WriteLine("(1) Feed Money \n" +
                              "(2) Select Product \n" +
                              "(3) Finish Transaction");
            Console.WriteLine($"Available balance: {_vm.CurrentBalance.ToString("c")}");
           string navigation = Console.ReadLine();

            bool exit = false;
            while (!exit)
            {
                if (navigation == "1")
                {
                    FeedMoneyMenu();
                }
                else if (navigation == "2")
                {
                    DisplayInventory(false);
                    Console.WriteLine();
                    Console.WriteLine("Please select your product or press b to go back: ");
                    string productSelection = Console.ReadLine();
                    productSelection = productSelection.ToUpper();
                    _vm.PurchaseItem(productSelection);
                    if (productSelection == "b" || productSelection == "B")
                    {
                        DisplayPurchaseMenu();
                    }
                    
                }
                else if (navigation == "3")
                {
                    Change.MakeChange(_vm.CurrentBalance);
                    Console.WriteLine("Your current balance is: " + _vm.CurrentBalance.ToString("c"));
                    Console.WriteLine(Change.MakeChange(_vm.CurrentBalance));
                    _vm.ResetBalance();
                    SalesLog.WriteToLog(_vm.Inventory);
                    Console.ReadKey();
                    exit = true;
                    Run();
                }
            }
        }
        #endregion
        public void DisplayReturnedChange() { }
        public Dictionary<string, InventorySlot> GetCurrentInventory()
        {
            return _vm.Inventory;
        }
        public void Run()
        {
            Console.Clear();
            Console.WriteLine("(1) Display Vending Machine Items \n" +
                              "(2) Purchase");
            Console.WriteLine();
            Console.WriteLine($"Available balance: {_vm.CurrentBalance.ToString("c")}");
            
           string navigation = Console.ReadLine();
            
                if (navigation == "1")
                {
                    DisplayInventory(true);
                }
                else if (navigation == "2")
                {
                    DisplayPurchaseMenu();
                }
                else
                {
                    Console.WriteLine("Please enter a valid selection. \n" +
                                     "Press any key to continue.");
                }
            Console.ReadKey();
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
                    DisplayPurchaseMenu();
                }
            }

        }
        #endregion
    }
}
