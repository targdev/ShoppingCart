//using ShoppingCart.ProdSelected;
//using System;
//using System.Collections.Generic;
//using Xunit;

//namespace ShoppingCart.Tests
//{
//    public class DelimiterTests
//    {
//        [Fact(DisplayName = "Delimiter: Should return ID's from user's line input")]
//        public void DelimitersToSplit_Delimiter_ReturnIdsSeparatedByComma()
//        {
//            //-----------------------------------------------------------------------------------
//            // Arrange 
//            //-----------------------------------------------------------------------------------
//            var delimiter = new IdSelected();

//            //-----------------------------------------------------------------------------------
//            // Act
//            //-----------------------------------------------------------------------------------
//            var result = delimiter.Delimiter("110, 120, 130, 140, 210, 220, 230, 310, 430");

//            //-----------------------------------------------------------------------------------
//            // Assert
//            //-----------------------------------------------------------------------------------
//            Assert.Equal(new List<int>() { 110, 120, 130, 140, 210, 220, 230, 310, 430 }, result);
//        }
//        [Fact(DisplayName = "Delimiter: Should return user input line ID's separated by special characters")]
//        public void DelimitersToSplit_Delimiter_ReturnIdsSeparatedBySpecialCharacters()
//        {
//            //-----------------------------------------------------------------------------------
//            // Arrange 
//            //-----------------------------------------------------------------------------------
//            var delimiter = new IdSelected();

//            //-----------------------------------------------------------------------------------
//            // Act
//            //-----------------------------------------------------------------------------------
//            var result = delimiter.Delimiter("110.  120; 130\n 140: 210[220] 230// 310...430");

//            //-----------------------------------------------------------------------------------
//            // Assert
//            //-----------------------------------------------------------------------------------
//            Assert.Equal(new List<int>() { 110, 120, 130, 140, 210, 220, 230, 310, 430 }, result);
//        }
//    }
//}
