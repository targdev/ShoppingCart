using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ShoppingCart.Products;
using ShoppingCart.ProdSelected;

namespace ShoppingCart
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var jsonStrg = File.ReadAllText(@"G:\Programming\Projetos\ShoppingCart\ShoppingCart\products.json");
            var listProducts = JsonConvert.DeserializeObject<Root>(jsonStrg);

            DelimitersToSplit separators = new DelimitersToSplit();
            PromotionAdquired promotionAdquired = new PromotionAdquired();

            Console.WriteLine("Quais itens deseja adicionar no carrinho?");
            var quantityItems = Console.ReadLine();
            var resInputUser = separators.Delimiter(quantityItems);

            var selectProd = (from product in listProducts.Products
                              join id in resInputUser on product.Id equals id
                              select product).ToList();

            var groupByCategoriesQuery = (from product in selectProd
                                          group product by product.Category into newGroup
                                          select newGroup).Count();

           var discountClub = promotionAdquired.PromotionByAmountCategories(groupByCategoriesQuery);
            var sumDiscounts = selectProd
                .Aggregate(0d, (acc, product) => {
                    var listadelista = product.Promotions.Where(promotion =>
                    {
                        var looks = promotion.Looks.Where(look => discountClub == look).FirstOrDefault();

                        return looks != null;
                    }).FirstOrDefault();
                    //FAZER UMA COISA DAHORA COM O PRICE!!!!!!!!!!!!!
                    var price = listadelista == null ? product.RegularPrice : listadelista.Price;

                    return acc + price;
                });

            Console.ReadKey();
        }
    }
}
