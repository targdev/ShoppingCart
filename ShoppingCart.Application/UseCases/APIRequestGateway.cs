using Newtonsoft.Json;
using ShoppingCart.Domain.Abstractions.Gateway;
using ShoppingCart.Domain.ValueObjects;
using System.IO;

namespace ShoppingCart.Application.UseCases
{
    public class APIRequestGateway : IAPIResquestGateway
    {
        public Root JsonProducts()
        {
            var jsonStrg = File.ReadAllText(@"G:\Programming\Projetos\ShoppingCart\ShoppingCart\products.json");

            return JsonConvert.DeserializeObject<Root>(jsonStrg);
        }
    }
}
