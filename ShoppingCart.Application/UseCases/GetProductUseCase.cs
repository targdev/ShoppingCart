using ShoppingCart.Application.UseCases.Abstratcs;
using ShoppingCart.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.UseCases
{
    public class GetProductUseCase : IGetProductUseCase
    {
        public List<int> Delimiter(string inputUser)
        {
            string[] delimiterChars = { " ", ",", ".", "...", ";", ":", "\\n", "[", "]", "//" };
            var userNumbers = inputUser.Split(delimiterChars, StringSplitOptions.None);
            List<int> listId = new List<int>();

            foreach (var num in userNumbers)
            {
                if (String.IsNullOrEmpty(num))
                {
                    continue;
                }

                listId.Add(Convert.ToInt32(num));
            }

            return listId;
        }
        public List<Product> GetProductUser(List<Product> listProduct, List<int> inputUser)
        {
            return (from product in listProduct
                    join id in inputUser on product.Id equals id
                    select product).ToList();
        }
        public int GetNumberCategoriesProduct(List<Product> listProductUser)
        {
            return (from product in listProductUser
                    group product by product.Category into newGroup
                    select newGroup).Count();
        }
        public string PromotionByAmountCategories(int amountCategories)
        {
            switch (amountCategories)
            {
                case 2:
                    return "DOUBLE LOOK";
                case 3:
                    return "TRIPLE LOOK";
                case 4:
                    return "FULL LOOK";
                default:
                    return "SINGLE LOOK";
            }
        }
    }
}
