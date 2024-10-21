using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;
using MMABooksDBClasses;

namespace MMABooksTests
{
    [TestFixture]
    public class CustomerDBTests
    {
        //Tests work if they are run individually.  I can't seem to run them all at once in order.
        private Customer def;
        private Customer c;
        [SetUp]
        public void SetUp()
        {
            def = new Customer();
            c = new Customer();
            c.CustomerID = 734;  //Manually assigned ID variable to modify customers added from the test.
        }
        [Test]
        public void TestGetCustomer()
        {
            Customer def = CustomerDB.GetCustomer(4);
            Assert.AreEqual(4, def.CustomerID);
        }
        [Test]
        public void TestCreateCustomer()
        {
            c.Name = "Mickey Mouse";
            c.Address = "101 Main Street";
            c.City = "Orlando";
            c.State = "FL";
            c.ZipCode = "10101";
            Assert.AreEqual("Mickey Mouse", CustomerDB.GetCustomer(CustomerDB.AddCustomer(c)).Name); //Gets ID from newly added customer, then compares its name.
        }
        [Test]
        public void TestUpdateCustomer()
        {
            def = CustomerDB.GetCustomer(c.CustomerID);
            Assert.AreEqual(c.CustomerID, def.CustomerID);
            Assert.AreEqual("Mickey Mouse", def.Name);
            c.Name = "Minnie Mouse";
            c.Address = "102 Main Street";
            c.City = "Los Angeles";
            c.State = "CA";
            c.ZipCode = "91919";
            Assert.IsTrue(CustomerDB.UpdateCustomer(def, c));
        }
        [Test]
        public void TestDeleteCustomer()
        {
            //Assert.IsTrue(CustomerDB.DeleteCustomer(CustomerDB.GetCustomer(710)));  Keeping this here so I can delete the dozens of Mickey Mice in my database.
            Assert.IsTrue(CustomerDB.DeleteCustomer(CustomerDB.GetCustomer(c.CustomerID)));
        }
    }
}
