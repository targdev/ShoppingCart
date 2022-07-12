using ShoppingCart.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.UseCases.Abstratcs
{
    public interface IRegisteredProductValuesUseCase
    {
        double CalculatingPromotion(List<Product> selectProd, string discountClub);
        double ValueTotal(List<Product> selectProd);
        double DiscountPercentage(double sumRegularPrice, double sumDiscounts);
        double DiscountValue(double sumRegularPrice, double sumDiscounts);
    }
}
