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
            p = new Product(" 12ab ", " Dr. Seuss: Green Eggs & Ham ", 5, 0.01m);
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
        [Test]
        public void TestProductCodeSetter()
        {
            Assert.AreEqual("12AB", p.ProductCode);
            p.ProductCode = " 34cd ";  //Product code will be made uppercase.
            Assert.AreNotEqual ("12AB", p.ProductCode);
            Assert.AreEqual ("34CD", p.ProductCode);
        }
        [Test]
        public void TestDescriptionSetter()
        {
            Assert.AreEqual("Dr. Seuss: Green Eggs & Ham", p.Description);
            p.Description = " Dr. Seuss: The Cat in the Hat ";  //Whitespace will be trimmed.
            Assert.AreNotEqual("Dr. Seuss: Green Eggs & Ham", p.Description);
            Assert.AreEqual("Dr. Seuss: The Cat in the Hat", p.Description);
        }
        [Test]
        public void TestOnHandQuantitySetter()
        {
            Assert.AreEqual(5, p.OnHandQuantity);
            p.OnHandQuantity = 100;
            Assert.AreNotEqual(5, p.OnHandQuantity);
            Assert.AreEqual(100, p.OnHandQuantity);
        }
        [Test]
        public void TestUnitPriceSetter()
        {
            Assert.AreEqual(0.01m, p.UnitPrice);
            p.UnitPrice = 1.02m;
            Assert.AreNotEqual(0.01m, p.UnitPrice);
            Assert.AreEqual(1.02m, p.UnitPrice);
        }
        [Test]
        public void TestProductCodeEmpty()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.ProductCode = "");
        }
        [Test]
        public void TestDescriptionEmpty()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.Description = "");
        }
        [Test]
        public void TestUnitPriceTooLow()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.UnitPrice = 0m);
            Assert.Throws<ArgumentOutOfRangeException>(() => p.UnitPrice = -1.02m);
        }
        [Test]
        public void TestProductCodeOutOfRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.ProductCode = "ab5");
            Assert.Throws<ArgumentOutOfRangeException>(() => p.ProductCode = "ar532");
        }
        [Test]
        public void TestDescriptionTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.Description = "haskdlfhklsajdfhklsadjhflkasjdfhklsadjfhksjdfhlksajdfhlksajdfhlksajdfhlksajdhflksajdhfklsjdhfksajdfhklsalsadjfa;lsdfkj;lsadfkja;sldfkjals;kdfjjdhf");
        }
    }
}
