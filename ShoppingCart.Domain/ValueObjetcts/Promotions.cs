using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShoppingCart.Domain.ValueObjects
{
    public class Promotion
    {
        [JsonPropertyName("looks")]
        public List<string> Looks { get; set; }

        [JsonPropertyName("price")]
        public double Price { get; set; }
    }
}
