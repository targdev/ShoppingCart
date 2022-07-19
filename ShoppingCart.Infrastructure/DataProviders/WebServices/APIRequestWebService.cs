using Newtonsoft.Json;
using ShoppingCart.Domain.Abstractions.Gateway;
using ShoppingCart.Domain.ValueObjects;
using System.IO;

namespace ShoppingCart.Infrastructure.DataProviders.WebServices
{
    public class APIRequestWebService : IAPIResquestGateway
    {
        public Root JsonProducts()
        {
            return JsonConvert.DeserializeObject<Root>(File
                .ReadAllText
                (@"G:\Programming\Projetos\ShoppingCart\ShoppingCart\products.json"
                ));
        }
    }
}
