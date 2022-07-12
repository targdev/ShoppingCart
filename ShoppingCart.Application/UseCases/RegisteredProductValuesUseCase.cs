using ShoppingCart.Application.UseCases.Abstratcs;
using ShoppingCart.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.UseCases
{
    public class RegisteredProductValuesUseCase : IRegisteredProductValuesUseCase
    {
        public double CalculatingPromotion(List<Product> selectProd, string discountClub)
        {
            return selectProd
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
        }
        public double ValueTotal(List<Product> selectProd)
        {
            return selectProd
                 .Aggregate(0d, (acc, product) =>
                 {
                     var verificationRegularPrice = product.RegularPrice;
                     return acc + verificationRegularPrice;
                 });
        }
        public double DiscountPercentage(double sumRegularPrice, double sumDiscounts)
        {
            return Math.Round((sumRegularPrice - sumDiscounts) / sumRegularPrice * 100);
        }
        public double DiscountValue(double sumRegularPrice, double sumDiscounts)
        {
            return sumRegularPrice - sumDiscounts;
        }
    }
}
