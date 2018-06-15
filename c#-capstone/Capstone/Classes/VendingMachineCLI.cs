using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Capstone.Classes
{
    public class VendingMachineCLI
    {
        public string option_DisplayPurchaseMenu;
        public string option_DisplayVendingMachine;
        public string option_InsertMoney;
        public string option_MakeSelection;
        public string option_Quit;
        public string option_ReturnChange;
        public string option_ReturnToPreviousMenu;

        private VendingMachine _vm = null;

        //Property
        //vm: VendingMachine;

        public VendingMachineCLI(VendingMachine vm)
        {
            _vm = vm;
        }

        //Methods
        public void DisplayInvalidOption() { }

        public void DisplayInventory()
        {
            Console.Clear();
            Console.WriteLine($"Slot \t Item \t\t Price \t Quantity");
            foreach (KeyValuePair<string, InventorySlot> item in _vm.Inventory)
            {
                //Console.WriteLine("{15, 32}{15,32}", item.Key + item.Value.Item.ItemName + item.Value.Item.Price);
                Console.WriteLine($"{item.Key} \t {item.Value.Item.ItemName} \t {item.Value.Item.Price}" +
                    $" \t {item.Value.Quantity}");
            }
            Console.ReadKey();
        }

        public void DisplayPurchaseMenu()
        {
            Console.Clear();
            Console.WriteLine("(1) Feed Money \n" +
                              "(2) Select Product \n" +
                              "(3) Finish Transaction");
            string selection = Console.ReadLine();

            bool exit = false;
            string navigation = "";
            while (!exit)
            {
                if (selection == "1")
                {
                    FeedMoneyMenu();
                }
                else if (selection == "2")
                {
                    DisplayInventory();
                    //Console.WriteLine($"To add more money press \"m\"");
                    //if (navigation == "m")
                    //{
                    //    FeedMoneyMenu();
                    //}
                    Console.WriteLine("Please select your product");
                    string productSelection = Console.ReadLine();
                    _vm.PurchaseItem(productSelection);

                    if (navigation == "a")
                    {
                        FeedMoneyMenu();
                    }
                    if (navigation == "q")
                    {
                        DisplayInventory();
                    }
                }
                else if (selection == "3")
                {
                    //need to exit and give change
                }
                Console.WriteLine($"Available balance: {_vm.CurrentBalance.ToString("c")}");
                Console.WriteLine($"To add more money press \"a\" \n" +
                                  $"To return to previous menu press \"q\"");
                navigation = Console.ReadLine();
                if (navigation == "a")
                {
                    exit = false;
                }
                else if (navigation == "q")
                {
                    DisplayPurchaseMenu();
                }
            }
        }
        public void DisplayReturnedChange() { }
        public void PrintTitle() { }
        public void Run()
        {
            Console.WriteLine("(1) Display Vending Machine Items \n" +
                              "(2) Purchase");
            string mainMenuSelection = Console.ReadLine();
            
                if (mainMenuSelection == "1")
                {
                    DisplayInventory();
                }
                else if (mainMenuSelection == "2")
                {
                    DisplayPurchaseMenu();
                }
                else
                {
                    Console.WriteLine("Please enter a valid selection. \n" +
                                     "Press any key to continue.");
                }
        }

        public void FeedMoneyMenu()
        {
            Console.Clear();
            Console.WriteLine("How much money would you like to insert?");
            Console.WriteLine("(1) $1");
            Console.WriteLine("(2) $2");
            Console.WriteLine("(3) $5");
            Console.WriteLine("(4) $10");
            string moneyChoice = Console.ReadLine();
            if (moneyChoice == "1")
            {
                _vm.FeedMoney(1);
                TransactionLog.DepositLog(1, _vm.CurrentBalance);
            }
            if (moneyChoice == "2")
            {
                _vm.FeedMoney(2);
                TransactionLog.DepositLog(2, _vm.CurrentBalance);
            }
            if (moneyChoice == "3")
            {
                _vm.FeedMoney(5);
                TransactionLog.DepositLog(5, _vm.CurrentBalance);
            }
            if (moneyChoice == "4")
            {
                _vm.FeedMoney(10);
                TransactionLog.DepositLog(10, _vm.CurrentBalance);
            }
        }
    }
}
