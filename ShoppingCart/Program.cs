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

            Console.WriteLine("Quais itens deseja adicionar no carrinho?");
            var quantityItems = Console.ReadLine();
            var resInputUser = separators.Delimiter(quantityItems);

            var selectProd = (from product in listProducts.Products
                              join id in resInputUser on product.Id equals id
                             select product).ToList();

            Console.ReadKey();
        }
    }
}
