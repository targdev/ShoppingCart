using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShoppingCart.Domain.ValueObjects
{
    public class Root
    {
        [JsonPropertyName("products")]
        public List<Product> Products { get; set; }
    }
}
