using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagementSystem
{
    public class OrderMS
    {
        public int OrderID { get; set; }
        public BuyerInfo BuyerInfo { get; set; }
        public List<Product> product { get; set; }
        public Address Address { get; set; }
        public string OrderStatus { get; set; }

    }

    public class BuyerInfo
    {
        public string BuyerName { get; set; }
        public string Mobile { get; set; }
    }
    public class Product
    {
        public string ProductName { get; set; }
        public string Weight { get; set; }

    }

    public class Address
    {
        public string Street { get; set; }
        public string State { get; set; }
    }


}
