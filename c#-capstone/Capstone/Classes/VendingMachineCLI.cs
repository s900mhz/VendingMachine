using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes.Items;

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

        //Property
        //vm: VendingMachine;

        //Methods
        public void DisplayInvalidOption() { }
        public void DisplayInventory()
        {
            foreach (var item in InventoryFile.CreateStartingInventory()) //needs to be CURRENT inventory
            {
                Console.WriteLine(item.Key + " " + item.Value.ItemName + " " + item.Value.Price);
                Console.ReadKey();
            }
        }
        public void DisplayPurchaseMenu()
        {

        }
        public void DisplayReturnedChange() { }
        public void PrintTitle() { }
        public void Run()
        {
            //InventoryFile.GetInventory();
            InventoryFile.CreateStartingInventory();

            Console.WriteLine("(1) Display Vending Machine Items \n" +
                              "(2) Purchase");
            string mainMenuSelection = Console.ReadLine();

            bool exit = false;
            do
            {
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
                    exit = true;

                }
            } while (!exit);

            Console.ReadKey();
        }
        //VendingMachineCLI(VendingMachine vm)


    }
}
