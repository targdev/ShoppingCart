using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShoppingCart.Products
{
    public class Root
    {
        [JsonPropertyName("products")]
        public List<Product> Products { get; set; }
    }
}
