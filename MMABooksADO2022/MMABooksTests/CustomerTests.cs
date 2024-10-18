using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;

namespace MMABooksTests
{
    [TestFixture]
    public class CustomerTests
    {
        private Customer def;
        private Customer c;

        [SetUp]

        public void Setup()
        { 
            def = new Customer(); 
            c = new Customer(1, "Olson, Thomas", "136 Oakway Center", "Eugene", "OR", "97401");
        }

        [Test]
        public void TestConstructor() 
        {
            Assert.IsNotNull(def);
            Assert.AreEqual(0, def.CustomerID);
            Assert.AreEqual(null, def.Name);
            Assert.AreEqual(null, def.Address);
            Assert.AreEqual(null, def.City);
            Assert.AreEqual(null, def.State);
            Assert.AreEqual(null, def.ZipCode);

            Assert.IsNotNull(c);
            Assert.AreNotEqual(0, c.CustomerID);
            Assert.AreNotEqual(null, c.Name);
            Assert.AreNotEqual(null, c.Address);
            Assert.AreNotEqual(null, c.City);
            Assert.AreNotEqual(null, c.State);
            Assert.AreNotEqual(null, c.ZipCode);
        }

        [Test]
        public void TestNameSetter()
        {
            c.Name = "Olson, Samoht";
            Assert.AreNotEqual("Olson, Thomas", c.Name);
            Assert.AreEqual("Olson, Samoht", c.Name);
        }

        [Test]
        public void TestNameTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.Name = "skjkdfjgkdfljghdkfjghkldjghkerjhkrjgkfjgkdfjgkjdfgkjdfhgkjoirjgriljeinjnkjfgkdfjnglskfnlfsndlkfndsklfjlksdjflknslanvnprwoturiohlskjd;;kanajksnfjengijrgoroejgiroi");
        }

        [Test]
        public void TestNameEmpty()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.Name = "");
        }

        [Test]
        public void TestAddressSetter()
        {
            c.Address = "101 Oakway Center";
            Assert.AreNotEqual("136 Oakway Center", c.Address);
            Assert.AreEqual("101 Oakway Center", c.Address);
        }

        [Test]
        public void TestAddressTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.Address = "skjkdfjgkdfljghdkfjghkldjghkerjhkrjgkfjgkdfjgkjdfgkjdfhgkjoirjgriljeinjnkjfgkdfjnglskfnlfsndlkfndsklfjlksdjflknslanvnprwoturiohlskjd;;kanajksnfjengijrgoroejgiroi");
        }

        [Test]
        public void TestAddressEmpty()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.Address = "");
        }

        [Test]
        public void TestCitySetter()
        {
            c.City = "Springfield";
            Assert.AreNotEqual("Eugene", c.City);
            Assert.AreEqual("Springfield", c.City);
        }

        [Test]
        public void TestCityTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.City = "skjkdfjgkdfljghdkfjghkldjghkerjhkrjgkfjgkdfjgkjdfgkjdfhgkjoirjgriljeinjnkjfgkdfjnglskfnlfsndlkfndsklfjlksdjflknslanvnprwoturiohlskjd;;kanajksnfjengijrgoroejgiroi");
        }

        [Test]
        public void TestCityEmpty()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.City = "");
        }

        [Test]
        public void TestStateSetter()
        {
            c.State = "CA";
            Assert.AreNotEqual("OR", c.State);
            Assert.AreEqual("CA", c.State);
        }

        [Test]
        public void TestStateIncorrectCharacters()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.State = "ore");
            Assert.Throws<ArgumentOutOfRangeException>(() => c.State = "o");
        }

        [Test]
        public void TestZipCodeSetter()
        {
            c.ZipCode = "97402";
            Assert.AreNotEqual("97401", c.ZipCode);
            Assert.AreEqual("97402", c.ZipCode);
        }

        [Test]
        public void TestZipCodeTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.ZipCode = "9283993300282309763");
        }

        [Test]
        public void TestZipCodeTooShort()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.ZipCode = "1234");
        }
    }
}