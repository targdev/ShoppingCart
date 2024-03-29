﻿using Newtonsoft.Json;
using ShoppingCart.Domain.Abstractions.Gateway;
using ShoppingCart.Domain.ValueObjects;
using System.IO;

namespace ShoppingCart.Infrastructure.DataProviders.Repositories
{
    public class APIRequestGateway : IAPIResquestGateway
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
