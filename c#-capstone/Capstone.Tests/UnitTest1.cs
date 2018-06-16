using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using System.IO;

namespace Capstone.Tests
{
    [TestClass]
    public class UnitTest1
    {
        VendingMachine vm1 = new VendingMachine();
        VendingMachine vm2 = new VendingMachine();
        VendingMachine vm3 = new VendingMachine();
        VendingMachine vm4 = new VendingMachine();

        [TestMethod]
        public void FeedMoney()
        {
            vm1.FeedMoney(5);
            Assert.AreEqual(5, vm1.CurrentBalance, "Balance is incorrect");

            vm2.FeedMoney(225);
            Assert.AreEqual(225, vm2.CurrentBalance, "Balance is incorrect");
            
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
            Assert.AreEqual(4, vm5.Inventory["A1"].Quantity);

            InventoryFile.CreateStartingInventory();
            VendingMachine vm1 = new VendingMachine();
            vm1.FeedMoney(5);
            vm1.PurchaseItem("B1");
            Assert.AreEqual(4, vm1.Inventory["B1"].Quantity);
            
            InventoryFile.CreateStartingInventory();
            VendingMachine vm2 = new VendingMachine();
            vm2.FeedMoney(5);
            vm2.PurchaseItem("C1");
            Assert.AreEqual(4, vm2.Inventory["C1"].Quantity);


        }
        //[TestMethod]
        //public void TestMethod1()
        //{

        //}
    }
}
