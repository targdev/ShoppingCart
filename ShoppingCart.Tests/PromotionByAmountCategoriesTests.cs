using ShoppingCart.ProdSelected;
using System;
using System.Collections.Generic;
using Xunit;

namespace ShoppingCart.Tests
{
    public class PromotionByAmountCategoriesTests
    {
        [Theory]
        [InlineData(4, "FULL LOOK")]
        [InlineData(2, "DOUBLE LOOK")]
        [InlineData(3, "TRIPLE LOOK")]
        [InlineData(1, "SINGLE LOOK")]
        public void PromotionAdquired_PromotionByAmountCategories_ReturnPromotion(int count, string promotion)
        {
            // Arrange 
            var promotionAdquired = new PromotionAdquired();

            // Act
            var result = promotionAdquired.PromotionByAmountCategories(count);

            // Assert
            Assert.Equal(promotion, result);
        }
    }
}
