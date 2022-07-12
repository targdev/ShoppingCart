using System.Collections.Generic;

namespace ShoppingCart.Application.Models
{
    public class FinalProduct
    {
        public List<FinalNameAndCategory> Products { get; set; }
        public string Promotion { get; set; }
        public double TotalPrice { get; set; }
        public double DiscountValue { get; set; }
        public double DiscountPercentage { get; set; } 

        public FinalProduct()
        {
            Products = new List<FinalNameAndCategory>();
        }
    }
}
