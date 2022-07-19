using Newtonsoft.Json;
using ShoppingCart.Application.Models;
using ShoppingCart.Application.UseCases.Abstratcs;

namespace ShoppingCart.Application.UseCases
{
    public class OutputProductFinalUseCase : IOutputProductFinalUseCase
    {
        public string OutputProductsUser(FinalProduct finalProduct)
        {
            return JsonConvert.SerializeObject(finalProduct);
        }
    }
}
