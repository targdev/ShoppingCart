using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.ProdSelected
{
    public class PromotionAdquired
    {
        public string PromotionByAmountCategories(int amountCategories)
        {
            switch (amountCategories)
            {
                case 2:
                    return "DOUBLE LOOK";
                case 3:
                    return "TRIPLE LOOK";
                case 4:
                    return "FULL LOOK";
                default:
                    return "SINGLE LOOK";
            }
        }
    }
}
