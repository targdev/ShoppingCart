using Newtonsoft.Json;
using ShoppingCart.Products;
using ShoppingCart.ProdSelected;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ShoppingCart
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var jsonStrg = File.ReadAllText(@"G:\Programming\Projetos\ShoppingCart\ShoppingCart\products.json");
            var listProducts = JsonConvert.DeserializeObject<List<Product>>(jsonStrg);

            DelimitersToSplit separators = new DelimitersToSplit();

            Console.WriteLine("Quais itens deseja adicionar no carrinho?");
            var quantityItems = Console.ReadLine();

            var resInputUser = separators.Delimiter(quantityItems);

            var selectProd = (from product in listProducts
                              join id in resInputUser on product.Id equals id
                             select product).ToList();

            Console.WriteLine(selectProd);
            Console.ReadKey();
        }
    }
}
