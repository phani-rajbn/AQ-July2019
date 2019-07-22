using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWebApp
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double ProductCost { get; set; }
        public int Quantity { get; set; } = 1;
        public override bool Equals(object obj)
        {
            if (obj is Product)
            {
                var temp = obj as Product;
                return temp.ProductName == ProductName;
            }
            else return false;
        }
        public override int GetHashCode()
        {
            return ProductName.GetHashCode();
        }
    }
}