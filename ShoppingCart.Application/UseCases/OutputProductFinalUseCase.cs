using Newtonsoft.Json;
using ShoppingCart.Application.Models;
using ShoppingCart.Application.UseCases.Abstratcs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.UseCases
{
    public class OutputProductFinalUseCase : IOutputProductFinalUseCase
    {
        public string OutputProductsUser(FinalProduct finalProduct)
        {
            var output = JsonConvert.SerializeObject(finalProduct);

            return output;
        }
    }
}
