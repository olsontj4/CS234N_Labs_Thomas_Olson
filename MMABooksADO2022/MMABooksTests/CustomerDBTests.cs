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
        private Customer def;
        private Customer c;
        [SetUp]
        public void SetUp()
        {
            def = new Customer();
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
            c = new Customer();
            c.Name = "Mickey Mouse";
            c.Address = "101 Main Street";
            c.City = "Orlando";
            c.State = "FL";
            c.ZipCode = "10101";
            int customerID = CustomerDB.AddCustomer(c);
            c = CustomerDB.GetCustomer(customerID);
            Assert.AreEqual("Mickey Mouse", c.Name);
        }
        [Test]
        public void TestDeleteCustomer()
        {
            //Assert.IsTrue(CustomerDB.DeleteCustomer(CustomerDB.GetCustomer(710)));  Keeping this here so I can delete the dozens of Mickey Mice in my database.
            Assert.IsTrue(CustomerDB.DeleteCustomer(c));
        }
    }
}
