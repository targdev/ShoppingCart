using ShoppingCart.Application.Models;
using ShoppingCart.Application.UseCases.Abstratcs;
using ShoppingCart.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.UseCases
{
    public class CreateProductFinalUseCase : ICreateProductFinalUseCase
    {
        public FinalProduct GetFinalProduct(
            List<Product> productsUser,
            string promotion, 
            double totalPrice, 
            double discountValue, 
            double discountPercentage
            )
        {
            var finalProduct = new FinalProduct();

            finalProduct.Promotion = promotion;
            finalProduct.TotalPrice = totalPrice;
            finalProduct.DiscountValue = discountValue;
            finalProduct.DiscountPercentage = discountPercentage;
            finalProduct.Products.AddRange(productsUser.Select(p => new FinalNameAndCategory
            {
                Name = p.Name,
                Category = p.Category
            }));

            return finalProduct;
        }
    }
}
