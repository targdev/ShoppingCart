using FluentAssertions;
using ShoppingCart.Application.UseCases;
using ShoppingCart.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using Xunit;

namespace ShoppingCart.UnitTests.Application.UseCases
{
    public class GetProductUseCaseTests
    {
        private readonly List<Product> products;

        public GetProductUseCaseTests()
        {
            products = new List<Product>
            {
                new Product {
                    Id = 110,
                    Name = "T-SHIRT",
                    Category = "T-SHIRT",
                    RegularPrice = 170,
                    Promotions = new List<Promotion> {
                         new Promotion {
                                Looks = new List<string> { "SINGLE LOOK", "DOUBLE LOOK"},
                                Price = 150,
                         },
                         new Promotion {

                                Looks = new List<string> { "TRIPLE LOOK" },
                                Price = 120,
                         }
                    }
                },

                new Product {
                    Id = 210,
                    Name = "PANTS",
                    Category = "PANTS",
                    RegularPrice = 180,
                    Promotions = new List<Promotion> {
                         new Promotion {
                                Looks = new List<string> { "DOUBLE LOOK" },
                                Price = 140,
                         },
                         new Promotion {

                                Looks = new List<string> { "TRIPLE LOOK", "FULL LOOK" },
                                Price = 130,
                         }
                    }
                },

                new Product {
                    Id = 310,
                    Name = "SHOES",
                    Category = "SHOES",
                    RegularPrice = 300,
                    Promotions = new List<Promotion> {
                         new Promotion {

                                Looks = new List<string> { "TRIPLE LOOK", "FULL LOOK" },
                                Price = 250,
                         }
                    }
                },

                new Product {
                    Id = 410,
                    Name = "BAGS",
                    Category = "BAGS",
                    RegularPrice = 150,
                    Promotions = new List<Promotion> {
                         new Promotion {
                                Looks = new List<string> { "SINGLE LOOK" },
                                Price = 125,
                         },
                         new Promotion {

                                Looks = new List<string> { "FULL LOOK" },
                                Price = 100,
                         }
                    }
                }
            };
        }

        [Fact(DisplayName = "Delimiter: Should return id's separated by comma")]
        public void Delimiter_Should_Return_Ids_Separated_By_Comma()
        {
            //-----------------------------------------------------------------------------------
            // Arrange 
            //-----------------------------------------------------------------------------------
            var delimiter = new GetProductUseCase();

            //-----------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------
            var result = delimiter.Delimiter("110, 120, 130");
            var expectedResult = new List<int>() { 110, 120, 130 };

            //-----------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact(DisplayName = "Delimiter: Should return id's separated by special characters")]
        public void Delimiter_Should_Return_Ids_Separated_By_Special_Characters()
        {
            //-----------------------------------------------------------------------------------
            // Arrange 
            //-----------------------------------------------------------------------------------
            var delimiter = new GetProductUseCase();
            var inputUser = "110.  120; 130\n 140: 210[220] 230// 310...430";
            var expectedResult = new List<int>() { 110, 120, 130, 140, 210, 220, 230, 310, 430 };

            //-----------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------
            var result = delimiter.Delimiter(inputUser);

            //-----------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact(DisplayName = "Delimiter: Should return error because don't accept letters")]
        public void Delimiter_Should_Return_Error_Because_Dont_Accept_Letters()
        {
            //-----------------------------------------------------------------------------------
            // Arrange 
            //-----------------------------------------------------------------------------------
            var delimiter = new GetProductUseCase();
            var inputUser = "bacanudo, supimpa";

            //-----------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------
            Action act = () => delimiter.Delimiter(inputUser);

            //-----------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------
            act.Should().Throw<ArgumentException>();
        }

        [Fact(DisplayName = "GetProductUser: Should return product user")]
        public void GetProductUser_Should_Return_Product_User()
        {
            //-----------------------------------------------------------------------------------
            // Arrange 
            //-----------------------------------------------------------------------------------
            var getProductUser = new GetProductUseCase();
            var inputUserIds = new List<int>() { 110, 210 };

            //-----------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------
            List<Product> result = getProductUser.GetProductUser(products, inputUserIds);

            //-----------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------
            result.Should().IntersectWith(products);

        }

        [Fact(DisplayName = "GetProductUser: Should return error product not found")]
        public void GetProductUser_Should_Return_Error_Product_Not_Found()
        {
            //-----------------------------------------------------------------------------------
            // Arrange 
            //-----------------------------------------------------------------------------------
            var getProductUser = new GetProductUseCase();
            var inputUserIds = new List<int>() { 120, 220 };

            //-----------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------
            List<Product> result = getProductUser.GetProductUser(products, inputUserIds);

            //-----------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------
            result.Should().BeEmpty("Products not found.");

        }
        
        [Fact(DisplayName = "GetNumberCategoriesProduct: Should return number of existing categories product")]
        public void GetNumberCategoriesProduct_Should_Return_Number_Of_Existing_Categories_Product()
        {
            //-----------------------------------------------------------------------------------
            // Arrange 
            //-----------------------------------------------------------------------------------
            var amountNumbers = new GetProductUseCase();

            //-----------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------
            var result = amountNumbers.GetNumberCategoriesProduct(products);

            //-----------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------
            result.Should().Be(4);
        }

        [Theory(DisplayName = "PromotionByAmountCategories: Should return a promotion according number of categories.")]
        [InlineData(4, "FULL LOOK")]
        [InlineData(2, "DOUBLE LOOK")]
        [InlineData(3, "TRIPLE LOOK")]
        [InlineData(1, "SINGLE LOOK")]
        [InlineData(5, "SINGLE LOOK")]
        public void PromotionByAmountCategories_Should_Return_Promotion_According_Number_Of_Categories(
            int count, 
            string promotion)
        {
            //-----------------------------------------------------------------------------------
            // Arrange 
            //-----------------------------------------------------------------------------------
            var promotionAdquired = new GetProductUseCase();

            //-----------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------
            var result = promotionAdquired.PromotionByAmountCategories(count);

            //-----------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------
            result.Should().BeEquivalentTo(promotion, result);
        }
    }
}
