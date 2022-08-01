using System;
using ShoppingCart.Application.UseCases;
using ShoppingCart.Domain.Abstractions.Gateway;
using ShoppingCart.Application.UseCases.Abstratcs;
using ShoppingCart.Infrastructure.DataProviders.Repositories;

namespace ShoppingCart
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Quais itens deseja adicionar no carrinho?");
            var quantityItems = Console.ReadLine();

            IAPIResquestGateway resquestGateway = new APIRequestGateway();
            IRegisteredProductValuesUseCase RegisteredProductValuesUseCase = new RegisteredProductValuesUseCase();
            IGetProductUseCase getProductUseCase = new GetProductUseCase();
            ICreateProductFinalUseCase createProductFinalUseCase = new CreateProductFinalUseCase();
            IOutputProductFinalUseCase outputProductFinalUseCase = new OutputProductFinalUseCase();

            var listProduct = resquestGateway.JsonProducts().Products;

            var inputUser = getProductUseCase.Delimiter(quantityItems);
            var selectProd = getProductUseCase.GetProductUser(listProduct, inputUser);
            var getCountCategories = getProductUseCase.GetNumberCategoriesProduct(selectProd);
            var amountCategories = getProductUseCase.PromotionByAmountCategories(getCountCategories);

            var sumDiscounts = RegisteredProductValuesUseCase.CalculatingPromotion(selectProd, amountCategories);
            var sumRegularPrice = RegisteredProductValuesUseCase.ValueTotal(selectProd);
            var discountValue = RegisteredProductValuesUseCase.DiscountValue(sumRegularPrice, sumDiscounts);
            var discountPercentage = RegisteredProductValuesUseCase.DiscountPercentage(sumRegularPrice, sumDiscounts);

            var outputProductsUser = createProductFinalUseCase.GetFinalProduct
                (
                selectProd, 
                amountCategories, 
                sumDiscounts, 
                discountValue, 
                discountPercentage
                );

            var constructJson = outputProductFinalUseCase.OutputProductsUser(outputProductsUser);

            Console.WriteLine(constructJson);
            Console.ReadKey();
        }
    }
}
