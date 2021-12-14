using System;
using System.Collections.Generic;

using PizzaHut.PizzaApp.Data.Models;

namespace PizzaHut.PizzaApp.Data.Repositories.Interfaces
{
    public interface IPizzaIngredientRepository
    {
        IEnumerable<PizzaIngredient> GetAll();
        public PizzaIngredient GetIngredient(Guid id);
        public PizzaIngredient CreateIngredient(PizzaIngredient pizzaIngredient);
        public PizzaIngredient UpdateIngredient(PizzaIngredient pizzaIngredient);
        public PizzaIngredient DeleteIngredient(PizzaIngredient pizzaIngredient);
    }
}
