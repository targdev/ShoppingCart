using ShoppingCart.Application.Models;
using ShoppingCart.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.UseCases.Abstratcs
{
    public interface ICreateProductFinalUseCase
    {
        FinalProduct GetFinalProduct
            (
            List<Product> productsUser,
            string promotion,
            double totalPrice,
            double discountValue,
            double discountPercentage
            );
    }
}
