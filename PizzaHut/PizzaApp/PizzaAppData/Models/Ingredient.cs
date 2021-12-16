using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PizzaHut.PizzaApp.Data.Models
{
    public class Ingredient
    {
        public Guid? IngredientId { get; set; }
        public string IngredientName { get; set; }
        [JsonIgnore]
        public ICollection<PizzaIngredient> Pizzas { get; set; }

        public Ingredient()
        {
            Pizzas = new HashSet<PizzaIngredient>();
        }
    }
}
