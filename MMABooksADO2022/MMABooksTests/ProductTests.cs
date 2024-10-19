using MMABooksBusinessClasses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMABooksTests
{
    [TestFixture]
    public class ProductTests
    {
        private Product def;
        private Product p;

        [SetUp]
        public void Setup()
        {
            def = new Product();
            p = new Product("12ab", "Dr. Seuss: Green Eggs & Ham", 5, 0.01m);
        }
        [Test]
        public void TestProductConstructor()
        {
            Assert.IsNotNull(def);
            Assert.AreEqual(null, def.ProductCode);
            Assert.AreEqual(null, def.Description);
            Assert.AreEqual(0, def.OnHandQuantity);
            Assert.AreEqual(0m, def.UnitPrice);
            Assert.IsNotNull(p);
            Assert.AreNotEqual(null, p.ProductCode);
            Assert.AreNotEqual(null, p.Description);
            Assert.AreNotEqual(null , p.OnHandQuantity);
            Assert.AreNotEqual(null , p.UnitPrice);
        }
    }
}
