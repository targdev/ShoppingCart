using ShoppingCart.Products;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.CalcPromotions
{
    public class RescuingValues
    {
        public double CalculatingPromotion(List<Product> selectProd, string discountClub)
        {
            var sumDiscounts = selectProd
                 .Aggregate(0d, (acc, product) =>
                 {
                     var verificationPromotions = product.Promotions.Where(promotion =>
                     {
                         var looks = promotion.Looks.Where(look => discountClub == look).FirstOrDefault();

                         return looks != null;
                     }).FirstOrDefault();

                     var price = verificationPromotions?.Price ?? product.RegularPrice;
                     return acc + price;
                 });
            return sumDiscounts;
        }

        public double ValueTotal(List<Product> selectProd, List<double> valueTotal)
        {
            var sumValues = selectProd
                 .Aggregate(0d, (acc, product) =>
                 {
                     var verificationRegularPrice = product.RegularPrice;
                     return acc + verificationRegularPrice;
                 });
            return sumValues;
        }
    }
}
