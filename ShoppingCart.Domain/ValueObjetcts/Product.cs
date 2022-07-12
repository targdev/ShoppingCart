﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShoppingCart.Domain.ValueObjects
{
    public class Product
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("regularPrice")]
        public double RegularPrice { get; set; }

        [JsonPropertyName("promotions")]
        public List<Promotion> Promotions { get; set; }
    }
}
