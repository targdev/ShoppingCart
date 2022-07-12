using ShoppingCart.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.UseCases.Abstratcs
{
    public interface IOutputProductFinalUseCase
    {
        string OutputProductsUser(FinalProduct finalProduct);
    }
}
