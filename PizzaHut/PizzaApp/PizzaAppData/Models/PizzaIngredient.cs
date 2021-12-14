using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHut.PizzaApp.Data.Models
{
    public class PizzaIngredient
    {
        public Guid PizzaIngredientId { get; set; }
        public Guid PizzaId { get; set; }
        public Guid IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public Pizza Pizza { get; set; }
    }
}
