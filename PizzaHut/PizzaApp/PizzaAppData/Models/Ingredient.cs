using System;
using System.Collections.Generic;

namespace PizzaHut.PizzaApp.Data.Models
{
    public class Ingredient
    {
        public Guid IngredientId { get; set; }
        public string IngredientName { get; set; }
        public IEnumerable<PizzaIngredient> Pizzas { get; set; }
    }
}
