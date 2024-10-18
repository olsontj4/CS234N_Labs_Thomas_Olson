using System;

namespace MMABooksBusinessClasses
{
    public class Customer
    {
        // there are several warnings in this file related to nullable properties and return values.
        // you can ignore them
        public Customer() { }

        public Customer(int id, string name, string address, string city, string state, string zipcode)
        {
            CustomerID = id;
            Name = name;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipcode;
        }

        private int customerID;
        private string name;
        private string address;
        private string city;
        private string state;
        private string zipcode;

        public int CustomerID
        {
            get
            {
                return customerID;
            }
            set
            {
                if (value > 0)
                {
                    customerID = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Customer ID must be a positive integer.");
                }
            } 
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Trim().Length > 0)
                {
                    if (value.Trim().Length <= 100)
                    {
                        name = value.Trim();
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Character limit is 100.");
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException("String is empty.");
                }
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                if (value.Trim().Length > 0)
                {
                    if (value.Trim().Length <= 50)
                    {
                        address = value.Trim();
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Character limit is 50.");
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException("String is empty.");
                }
            }
        }

        public string City
        {
            get
            {
                return city;
            }
            set
            {
                if (value.Trim().Length > 0)
                {
                    if (value.Trim().Length <= 20)
                    {
                        city = value.Trim();
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Character limit is 20.");
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException("String is empty.");
                }
            }
        }

        public string State
        {
            get
            {
                return state;
            }
            set
            {
                if (value.Trim().ToUpper().Length == 2)
                {
                    state = value.Trim().ToUpper();
                }
                else
                {
                    throw new ArgumentOutOfRangeException("State must be 2 characters.");
                }
            }
        }
        public string ZipCode
        {
            get
            {
                return zipcode;
            }
            set
            {
                if (value.Trim().Length >= 5)
                {
                    if (value.Trim().Length <= 15)
                    {
                        zipcode = value.Trim();
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Character limit is 15.");
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Zip code must be at least 5 characters.");
                }
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
