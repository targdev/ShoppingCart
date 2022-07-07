using ShoppingCart.CalcPromotions;
using ShoppingCart.Products;
using System.Collections.Generic;
using Xunit;

namespace ShoppingCart.Tests
{
    public class ValueTotalTests
    {
        [Fact(DisplayName = "ValueTotal: Should return sum of the regular prices of products")]
        public void RescuingValues_ValueTotal_ReturnSumOfTheRegularPrices()
        {
            //-----------------------------------------------------------------------------------
            // Arrange 
            //-----------------------------------------------------------------------------------
            var calculing = new RescuingValues();
            var selectProd = new List<Product> {
                new Product {
                    Id = 210,
                    Name = "GUCCI LEGS BLACK",
                    Category = "PANTS",
                    RegularPrice = 180,
                    Promotions = new List<Promotion> {
                        new Promotion {
                            Looks = new List<string> { "SINGLE LOOK", "DOUBLE LOOK"},
                            Price = 150,
                        },
                        new Promotion
                        {
                            Looks = new List<string> { "TRIPLE LOOK", "FULL LOOK" },
                            Price = 140,
                        }
                    }
                },
                new Product {
                    Id = 120,
                    Name = "GUCCI T-SHIRT PINK",
                    Category = "T-SHIRT",
                    RegularPrice = 170,
                    Promotions = new List<Promotion> {
                        new Promotion {
                            Looks = new List<string> { "SINGLE LOOK", "DOUBLE LOOK"},
                            Price = 70,
                        },
                        new Promotion
                        {
                            Looks = new List<string> { "TRIPLE LOOK", "FULL LOOK" },
                            Price = 65,
                        }
                    }
                },
                new Product {
                    Id = 210,
                    Name = "NIKE AIR MAX 97",
                    Category = "SHOES",
                    RegularPrice = 350,
                    Promotions = new List<Promotion> {
                        new Promotion {
                            Looks = new List<string> { "SINGLE LOOK", "DOUBLE LOOK"},
                            Price = 150,
                        },
                        new Promotion
                        {
                            Looks = new List<string> { "TRIPLE LOOK", "FULL LOOK" },
                            Price = 140,
                        }
                    }
                },
            };

            //-----------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------
            var result = calculing.ValueTotal(selectProd);

            //-----------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------
            Assert.Equal(700, result);
        }
    }
}
