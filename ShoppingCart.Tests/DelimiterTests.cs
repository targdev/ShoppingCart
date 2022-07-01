using ShoppingCart.ProdSelected;
using System;
using System.Collections.Generic;
using Xunit;

namespace ShoppingCart.Tests
{
    public class DelimiterTests
    {
        [Fact]
        public void DelimitersToSplit_Delimiter_ReturnIdsSeparated()
        {
            // Arrange 
            var delimiter = new DelimitersToSplit();

            // Act
            var result = delimiter.Delimiter("110, 210");

            // Assert
            Assert.Equal(new List<int>() { 110, 210 }, result);
        }

        //[Theory]
        //[InlineData("110... 210;260", {110, 210, 260})]
        //public void DelimitersToSplit_Delimiter_ReturnsIdsSeparatedByDifferentSymbols(string inputUser, List<int>)
        //{
        //    // Arrange 
        //    var delimiter = new DelimitersToSplit();

        //    // Act
        //    var result = delimiter.Delimiter(inputUser);

        //    // Assert
        //    Assert.Equal(outputResult, result);
        //}

    }
}
