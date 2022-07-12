using ShoppingCart.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.UseCases.Abstratcs
{
    public interface IGetProductUseCase
    {
        List<int> Delimiter(string inputUser);
        List<Product> GetProductUser(List<Product> listProduct, List<int> inputUser);
        int GetNumberCategoriesProduct(List<Product> listProductUser);
        string PromotionByAmountCategories(int amountCategories);
    }
}
