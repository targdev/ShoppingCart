using FluentAssertions;
using ShoppingCart.Application.Models;
using ShoppingCart.Application.UseCases;
using ShoppingCart.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ShoppingCart.UnitTests.Application.UseCases
{
    public class CreateProductFinalUseCaseTests
    {
        private FinalProduct productFinal;
        private List<Product> productNameAndCategory;

        public CreateProductFinalUseCaseTests()
        {
            productNameAndCategory = new List<Product>()
            {
                new Product()
                {
                    Name = "Lacoste T-shirt",
                    Category = "T-SHIRT"
                },

                new Product()
                {
                    Name = "Cyclone T-shirt",
                    Category = "T-SHIRT"
                }

            };
            productFinal = new FinalProduct()
            {
                Products = new List<FinalNameAndCategory>(),
                Promotion = "SINGLE LOOK",
                TotalPrice = 210,
                DiscountValue = 10.0,
                DiscountPercentage = 1.0
            };
        }
    

        [Fact(DisplayName = "CreateProductFinalUseCase")]
        public void CreateProductFinalUseCase_Should()
        {
            //-----------------------------------------------------------------------------------
            // Arrange 
            //-----------------------------------------------------------------------------------
            var createProductFinal = new CreateProductFinalUseCase();
            var expectedProductsUser = new List<Product>()
            {
                new Product()
                {
                    Name = "Lacoste T-shirt",
                    Category = "T-SHIRT"
                },

                new Product()
                {
                    Name = "Cyclone T-shirt",
                    Category = "T-SHIRT"
                }

            };

            var expectedResult = new FinalProduct();
                expectedResult.Promotion = "SINGLE LOOK";
                expectedResult.TotalPrice = 210;
                expectedResult.DiscountValue = 10.0;
                expectedResult.DiscountPercentage = 1.0;
                expectedResult.Products.AddRange(expectedProductsUser.Select(p => new FinalNameAndCategory
                {
                    Name = p.Name,
                    Category = p.Category
                }));

            //-----------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------
            var result = createProductFinal.GetFinalProduct
                (
                productNameAndCategory,
                productFinal.Promotion,
                productFinal.TotalPrice,
                productFinal.DiscountValue,
                productFinal.DiscountPercentage
                );

            //-----------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
