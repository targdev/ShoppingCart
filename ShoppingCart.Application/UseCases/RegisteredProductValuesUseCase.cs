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
        public double ValueTotal(List<Product> selectProd)
        {
            var sumValues = selectProd
                 .Aggregate(0d, (acc, product) =>
                 {
                     var verificationRegularPrice = product.RegularPrice;
                     return acc + verificationRegularPrice;
                 });
            return sumValues;
        }
        public double DiscountPercentage(double sumRegularPrice, double sumDiscounts)
        {
            var percentageDiscount = Math.Round((sumRegularPrice - sumDiscounts) / sumRegularPrice * 100);

            return percentageDiscount;
        }
        public double DiscountValue(double sumRegularPrice, double sumDiscounts)
        {
            return sumRegularPrice - sumDiscounts;
        }
    }
}
