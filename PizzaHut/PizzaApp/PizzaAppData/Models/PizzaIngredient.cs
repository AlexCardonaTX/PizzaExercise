using System;
using System.Text.Json.Serialization;

namespace PizzaHut.PizzaApp.Data.Models
{
    public class PizzaIngredient
    {
        public Guid PizzaIngredientId { get; set; }
        [JsonIgnore]
        public Guid PizzaId { get; set; }
        [JsonIgnore]
        public Guid IngredientId { get; set; }

        public Ingredient Ingredient { get; set; }
        [JsonIgnore]
        public Pizza Pizza { get; set; }
    }
}
