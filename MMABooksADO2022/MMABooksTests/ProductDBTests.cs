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
        //All tests work if they are run in order.  Running them all will make some of them work the first time, and fail the next time.
        private Product def;
        private Product p;
        [SetUp]
        public void SetUp()
        {
            def = new Product();
            p = new Product("N1C3", "Haha.", 69, 4.20m);
        }
        [Test]
        public void TestProductList()
        {
            List<Product> products = ProductDB.GetList();
            Product product = new Product();
            foreach (Product compare in products) {
                if (compare.ProductCode == "A4CS") {
                    product = compare;
                }
            }
            Assert.AreNotEqual(null, products);
            Assert.AreEqual(ProductDB.GetProduct("A4CS").ProductCode, product.ProductCode);  //Compares the product code in an object from the GetProduct method with the product code in an object in the products list
        }
        [Test]
        public void TestGetProduct()
        {
            Product def = ProductDB.GetProduct("A4CS");
            Assert.AreEqual("A4CS", def.ProductCode);
        }

        [Test]
        public void TestAddProduct()  //Test should fail if product with same product code already exists.
        {
            Assert.IsTrue(ProductDB.AddProduct(p));
            Assert.IsFalse(ProductDB.AddProduct(p));
            p = ProductDB.GetProduct("N1C3");
            Assert.AreEqual("Haha.", p.Description);
        }
        [Test]
        public void TestUpdateProduct()
        {
            def = new Product("waha", "Wahaha: Wahaha", 116, 30.00m);
            Assert.IsTrue(ProductDB.UpdateProduct(p, def));
            Assert.IsFalse(ProductDB.UpdateProduct(p, def));  //Should return false if it's updated twice.

        }
        [Test]
        public void TestDeleteProduct()
        {
            def = new Product("n1c3", "Wahaha: Wahaha", 116, 30.00m);
            Assert.IsTrue(ProductDB.DeleteProduct(def));
            Assert.IsFalse(ProductDB.DeleteProduct(def));  //If deleted twice, product should not exist, and test should return false.
        }
    }
}
