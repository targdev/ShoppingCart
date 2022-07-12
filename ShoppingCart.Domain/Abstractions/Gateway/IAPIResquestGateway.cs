using ShoppingCart.Domain.ValueObjects;

namespace ShoppingCart.Domain.Abstractions.Gateway
{
    public interface IAPIResquestGateway
    {
        Root JsonProducts();
    }
}
