using ShoppingCart.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.ResProducts
{
    public class ObjectFinal
    {
        public List<FinalProduct> Products { get; set; }
        public string Promotion { get; set; }
        public double TotalPrice { get; set; }
        public double DiscountValue { get; set; }
        public double DiscountPercentage { get; set; } 

        public ObjectFinal()
        {
            Products = new List<FinalProduct>();
        }
    }
}
