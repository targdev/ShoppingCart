using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ShoppingCart.Products;
using ShoppingCart.ProdSelected;
using ShoppingCart.CalcPromotions;
using ShoppingCart.ResProducts;

namespace ShoppingCart
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var jsonStrg = File.ReadAllText(@"G:\Programming\Projetos\ShoppingCart\ShoppingCart\products.json");
            var listProducts = JsonConvert.DeserializeObject<Root>(jsonStrg);

            var separators = new IdSelected();
            var promotionAdquired = new PromotionAdquired();
            var calcValues = new RescuingValues();
            var objFinale = new ObjectFinal();

            Console.WriteLine("Quais itens deseja adicionar no carrinho?");
            var quantityItems = Console.ReadLine();
            var inputUser = separators.Delimiter(quantityItems);

            var selectProd = (from product in listProducts.Products
                              join id in inputUser on product.Id equals id
                              select product).ToList();

            var groupByCategoriesQuery = (from product in selectProd
                                          group product by product.Category into newGroup
                                          select newGroup).Count();

            var discountClub = promotionAdquired.PromotionByAmountCategories(groupByCategoriesQuery);
            var sumDiscounts = calcValues.CalculatingPromotion(selectProd, discountClub);
            var sumRegularPrice = calcValues.ValueTotal(selectProd);
            var percentageDiscount = (sumRegularPrice - sumDiscounts) / sumRegularPrice * 100;

            objFinale.Products.AddRange(selectProd.Select(p => new FinalProduct
            {
                Name = p.Name,
                Category = p.Category
            }));
            objFinale.Promotion = discountClub;
            objFinale.TotalPrice = sumDiscounts;
            objFinale.DiscountValue = sumRegularPrice - sumDiscounts;
            objFinale.DiscountPercentage = Math.Round(percentageDiscount, 2);

            string output = JsonConvert.SerializeObject(objFinale);
            Console.WriteLine(output);
            Console.ReadKey();
        }
    }
}
