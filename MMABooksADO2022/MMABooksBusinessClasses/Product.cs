using System;
using System.Collections.Generic;
using System.Text;

namespace MMABooksBusinessClasses
{
    public class Product
    {
        public Product() { }
        public Product(string productCode, string description, int onHandQuantity, decimal unitPrice)
        {
            ProductCode = productCode;
            Description = description;
            OnHandQuantity = onHandQuantity;
            UnitPrice = unitPrice;
        }

        private string productCode;
        private string description;
        private int onHandQuantity;
        private decimal unitPrice;

        public string ProductCode
        {
            get
            {
                return productCode;
            }
            set
            {
                if (value.Trim().Length != 4)
                {
                    throw new ArgumentOutOfRangeException("Product code must be 4 characters.");
                }
                else
                {
                    productCode = value.Trim().ToUpper();
                }
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (value.Trim().Length > 50)
                {
                    throw new ArgumentOutOfRangeException("Character limit is 50.");
                }
                else if (value.Trim().Length <= 0)
                {
                    throw new ArgumentOutOfRangeException("String is empty.");
                }
                else
                {
                    description = value.Trim();
                }
            }
        }
        public int OnHandQuantity
        {
            get
            {
                return onHandQuantity;
            }
            set
            {
                onHandQuantity = value;
            }
        }
        public decimal UnitPrice
        {
            get
            {
                return unitPrice;
            }
            set
            {
                if (value > 0)
                {
                    unitPrice = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Price must be greater than 0.");
                }
            }
        }
    }
}
