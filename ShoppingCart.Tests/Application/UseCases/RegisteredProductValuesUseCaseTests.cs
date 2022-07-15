using FluentAssertions;
using ShoppingCart.Application.UseCases;
using ShoppingCart.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShoppingCart.UnitTests.Application.UseCases
{
    public class RegisteredProductValuesUseCaseTests
    {
        private readonly List<Product> products;

        public RegisteredProductValuesUseCaseTests()
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

                                Looks = new List<string> { "TRIPLE LOOK" },
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


        [Fact(DisplayName = "CalculatingPromotion: Should return sum promotions acquired")]
        public void CalculatingPromotion_Should_Return_Sum_Promotions_Acquired()
        {
            //-----------------------------------------------------------------------------------
            // Arrange 
            //-----------------------------------------------------------------------------------
            var calculating = new RegisteredProductValuesUseCase();

            //-----------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------
            var result = calculating.CalculatingPromotion(products, "FULL LOOK");

            //-----------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------
            result.Should().Be(700);
        }

        [Fact(DisplayName = "ValueTotal: Should return sum regular prices products")]
        public void ValueTotal_Should_Return_Sum_Regular_Prices_Products()
        {
            //-----------------------------------------------------------------------------------
            // Arrange 
            //-----------------------------------------------------------------------------------
            var calculingValueTotal = new RegisteredProductValuesUseCase();

            //-----------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------
            var result = calculingValueTotal.ValueTotal(products);

            //-----------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------
            result.Should().Be(800);
        }

        [Theory(DisplayName = "DiscountPercentage: Should return percentage discount applied")]
        [InlineData( 269.90, 229.90, 14.82)]
        [InlineData( 449.90, 279.90, 37.79)]
        [InlineData( 239.90, 199.90, 16.67)]
        public void DiscountPercentage_Should_Return_Percentage_Discount_Applied(
            double sumPrice, 
            double sumDiscount, 
            double resultSum)
        {
            //-----------------------------------------------------------------------------------
            // Arrange 
            //-----------------------------------------------------------------------------------
            var calculingDiscount = new RegisteredProductValuesUseCase();

            //-----------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------
            var result = calculingDiscount.DiscountPercentage(sumPrice, sumDiscount);

            //-----------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------
            result.Should().Be(resultSum);
        }

        [Theory(DisplayName = "DiscountValue: Should return value discount applied")]
        [InlineData(269.90, 229.90, 40)]
        [InlineData(449.90, 279.90, 170)]
        [InlineData(239.90, 199.90, 40)]
        public void DiscountValue_Should_Return_Value_Discount_Applied(
            double sumPrice, 
            double sumDiscount, 
            double resultSum)
        {
            //-----------------------------------------------------------------------------------
            // Arrange 
            //-----------------------------------------------------------------------------------
            var calculingDiscount = new RegisteredProductValuesUseCase();

            //-----------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------
            var result = calculingDiscount.DiscountValue(sumPrice, sumDiscount);

            //-----------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------
            result.Should().Be(resultSum);
        }
    }
}
