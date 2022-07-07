using ShoppingCart.CalcPromotions;
using ShoppingCart.Products;
using System.Collections.Generic;
using Xunit;

namespace ShoppingCart.Tests
{
    public class CalculingPromotionTests
    {
        [Fact(DisplayName = "CalculingPromotion: Should return sum of the promotions acquired")]
        public void RescuingValues_CalculingPromotion_ReturnSumOfPromotions()
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
                    RegularPrice = 170,
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
                    RegularPrice = 80,
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
                }
            };

            //-----------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------
            var result = calculing.CalculatingPromotion(selectProd, "DOUBLE LOOK");

            //-----------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------
            Assert.Equal(220, result);
        }

        [Fact(DisplayName = "CalculingPromotion: Should return sum of the regular price when dont have promotion price")]
        public void RescuingValues_CalculingPromotion_ReturnSumOfRegularPriceWhenDontHavePromotion()
        {
            //-----------------------------------------------------------------------------------
            // Arrange 
            //-----------------------------------------------------------------------------------
            var calculing = new RescuingValues();
            var selectProd = new List<Product> {
                new Product {
                    Id = 110,
                    Name = "GUCCI T-SHIRT BLACK",
                    Category = "T-SHIRT",
                    RegularPrice = 70,
                    Promotions = new List<Promotion> {
                        new Promotion {
                            Looks = new List<string> { "DOUBLE LOOK"},
                            Price = 50,
                        },
                        new Promotion
                        {
                            Looks = new List<string> { "TRIPLE LOOK", "FULL LOOK" },
                            Price = 45,
                        }
                    }
                },
                new Product {
                    Id = 140,
                    Name = "GUCCI T-SHIRT PINK",
                    Category = "T-SHIRT",
                    RegularPrice = 80,
                    Promotions = new List<Promotion> {
                        new Promotion
                        {
                            Looks = new List<string> { "TRIPLE LOOK", "FULL LOOK" },
                            Price = 60,
                        }
                    }
                }
            };

            //-----------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------
            var result = calculing.CalculatingPromotion(selectProd, "SINGLE LOOK");

            //-----------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------
            Assert.Equal(150, result);
        }

        [Fact(DisplayName = "CalculingPromotion: Should return sum of the value when there be a just a promotion")]
        public void RescuingValues_CalculingPromotion_ReturnSumOfTheValueWhenThereBeAJustAPromotion()
        {
            //-----------------------------------------------------------------------------------
            // Arrange 
            //-----------------------------------------------------------------------------------
            var calculing = new RescuingValues();
            var selectProd = new List<Product> {
                new Product {
                    Id = 110,
                    Name = "LACOSTE LEATHER BAG",
                    Category = "BAGS",
                    RegularPrice = 50,
                    Promotions = new List<Promotion> {
                        new Promotion {
                            Looks = new List<string> { "DOUBLE LOOK"},
                            Price = 45,
                        }
                    }
                },
                new Product {
                    Id = 140,
                    Name = "NIKE AIR JORDAN V1",
                    Category = "SHOES",
                    RegularPrice = 80,
                    Promotions = new List<Promotion> {
                        new Promotion
                        {
                            Looks = new List<string> { "TRIPLE LOOK", "FULL LOOK" },
                            Price = 75,
                        }
                    }
                }
            };

            //-----------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------
            var result = calculing.CalculatingPromotion(selectProd, "DOUBLE LOOK");

            //-----------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------
            Assert.Equal(125, result);
        }
    }
}
