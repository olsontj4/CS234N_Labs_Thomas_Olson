using MMABooksBusinessClasses;
using MMABooksDBClasses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMABooksTests
{
    public class ProductDBTests
    {
        private Product def;
        private Product p;
        [SetUp]
        public void SetUp()
        {
            def = new Product();
            p = new Product("N1C3", "Haha.", 69, 4.20m);
        }
        [Test]
        public void TestGetProduct()
        {
            Product def = ProductDB.GetProduct("A4CS");
            Assert.AreEqual("A4CS", def.ProductCode);
        }

        [Test]
        public void TestCreateProduct()
        {
            string productCode = ProductDB.AddProduct(p);
            p = ProductDB.GetProduct(productCode);
            Assert.AreEqual("Haha.", p.Description);
        }
    }
}
