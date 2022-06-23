using ShoppingCart.Products;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.CalcPromotions
{
    public class ApplyingDiscount
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

                     //FAZER UMA COISA DAHORA COM O PRICE!!!!!!!!!!!!!
                     //var price = verificationPromotions == null ? product.RegularPrice : verificationPromotions.Price;
                     var price = verificationPromotions?.Price ?? product.RegularPrice;
                     return acc + price;
                 });
            return sumDiscounts;
        }
    }
}
