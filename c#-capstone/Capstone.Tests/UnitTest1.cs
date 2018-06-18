using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using System.IO;

namespace Capstone.Tests
{
    [TestClass]
    public class UnitTest1
    {
        VendingMachine testvm1 = new VendingMachine();
        VendingMachine testvm2 = new VendingMachine();
        VendingMachine testvm3 = new VendingMachine();
        VendingMachine testvm4 = new VendingMachine();

        [TestMethod]
        public void FeedMoney()
        {
            testvm1.FeedMoney(5);
            Assert.AreEqual(5, testvm1.CurrentBalance, "Balance is incorrect");

            testvm2.FeedMoney(225);
            Assert.AreEqual(225, testvm2.CurrentBalance, "Balance is incorrect");
            
            //Don't need negative test - user does NOT have this choice!

        }
        [TestMethod]
        public void Purchase()
        {
            //Checking that single ping of inventory is working
            InventoryFile.CreateStartingInventory();
            VendingMachine vm5 = new VendingMachine();
            vm5.FeedMoney(5);
            vm5.PurchaseItem("A1");
            Assert.AreEqual(4, vm5.Inventory["A1"].Quantity, "Quantity returned after purchase incorrect.");

            InventoryFile.CreateStartingInventory();
            VendingMachine vm1 = new VendingMachine();
            vm1.FeedMoney(5);
            vm1.PurchaseItem("B1");
            Assert.AreEqual(4, vm1.Inventory["B1"].Quantity, "Quantity returned after purchase incorrect.");
            
            InventoryFile.CreateStartingInventory();
            VendingMachine vm2 = new VendingMachine();
            vm2.FeedMoney(5);
            vm2.PurchaseItem("C1");
            Assert.AreEqual(4, vm2.Inventory["C1"].Quantity, "Quantity returned after purchase incorrect.");

            //Subsequent pings checking reduction of quantity
            InventoryFile.CreateStartingInventory();
            vm5.FeedMoney(5);
            vm5.PurchaseItem("A1");
            Assert.AreEqual(3, vm5.Inventory["A1"].Quantity, "Quantity returned after purchase incorrect.");

            vm5.FeedMoney(5);
            vm5.PurchaseItem("A1");
            Assert.AreEqual(2, vm5.Inventory["A1"].Quantity, "Quantity returned after purchase incorrect.");

            vm5.FeedMoney(5);
            vm5.PurchaseItem("A1");
            Assert.AreEqual(1, vm5.Inventory["A1"].Quantity, "Quantity returned after purchase incorrect.");

            vm5.FeedMoney(5);
            vm5.PurchaseItem("A1");
            Assert.AreEqual(0, vm5.Inventory["A1"].Quantity, "Quantity returned after purchase incorrect.");


        }
        [TestMethod]
        public void CorrectChangeDeduction()
        {
            InventoryFile.CreateStartingInventory();
            VendingMachine testvm5 = new VendingMachine();
            testvm5.FeedMoney(5);
            testvm5.PurchaseItem("A1");
            Assert.AreEqual(1.95M, testvm5.CurrentBalance, "Current balance returned after purchase incorrect.");

            InventoryFile.CreateStartingInventory();
            testvm1.FeedMoney(5);
            testvm1.PurchaseItem("D1");
            Assert.AreEqual(4.15M, testvm1.CurrentBalance, "Current balance returned after purchase incorrect.");

        }

        [TestMethod]
        public void ChangeBackCorrect()
        {
            InventoryFile.CreateStartingInventory();
            VendingMachine vm5 = new VendingMachine();
            vm5.FeedMoney(2);
            vm5.PurchaseItem("D3");
            Assert.AreEqual("Your change is 5 Quarters 0 Dimes 0 Nickels.", Change.MakeChange(vm5.CurrentBalance), "Change given back is incorrect.");

            InventoryFile.CreateStartingInventory();
            VendingMachine testvm1 = new VendingMachine();
            testvm1.FeedMoney(1);
            testvm1.PurchaseItem("D1");
            Assert.AreEqual("Your change is 0 Quarters 1 Dimes 1 Nickels.", Change.MakeChange(testvm1.CurrentBalance), "Change given back is incorrect.");

        }

        [TestMethod]
        public void NotEnoughFunds()
        {
            InventoryFile.CreateStartingInventory();
            VendingMachine testvm1 = new VendingMachine();
            testvm1.FeedMoney(5);
            testvm1.PurchaseItem("A4");
            Assert.AreEqual(1.35M, testvm1.CurrentBalance, 
                "Current balance returned after purchase incorrect.");
            
            testvm1.PurchaseItem("A4");
            Assert.AreEqual(1.35M, testvm1.CurrentBalance, "Should not be allowed to purchase product" +
                        "costing more than available current balance.");
        }

        [TestMethod]
        public void NotEnoughQuantity()
        {
            //Spinning endlessly due to Console.ReadKey

            InventoryFile.CreateStartingInventory();
            VendingMachine testvm1 = new VendingMachine();
            testvm1.FeedMoney(10);
            testvm1.PurchaseItem("D4");
            testvm1.PurchaseItem("D4");
            testvm1.PurchaseItem("D4");
            testvm1.PurchaseItem("D4");
            testvm1.PurchaseItem("D4");
            testvm1.PurchaseItem("D4");
            Assert.AreEqual(0, testvm1.Inventory["D4"].Quantity,
                "Cannot purchase more than available quantity of item.");

        }


}
}
