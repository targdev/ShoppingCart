using ShoppingCart.ProdSelected;
using Xunit;

namespace ShoppingCart.Tests
{
    public class PromotionByAmountCategoriesTests
    {
        [Theory(DisplayName = "PromotionByAmountCategories: Should return a promotion according to the number of categories.")]
        [InlineData(4, "FULL LOOK")]
        [InlineData(2, "DOUBLE LOOK")]
        [InlineData(3, "TRIPLE LOOK")]
        [InlineData(1, "SINGLE LOOK")]
        public void PromotionAdquired_PromotionByAmountCategories_ReturnPromotion(int count, string promotion)
        {
            //-----------------------------------------------------------------------------------
            // Arrange 
            //-----------------------------------------------------------------------------------
            var promotionAdquired = new PromotionAdquired();

            //-----------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------
            var result = promotionAdquired.PromotionByAmountCategories(count);

            //-----------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------
            Assert.Equal(promotion, result);
        }
    }
}
