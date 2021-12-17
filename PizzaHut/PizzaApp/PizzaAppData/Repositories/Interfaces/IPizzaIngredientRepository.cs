using System;
using System.Collections.Generic;

using PizzaHut.PizzaApp.Data.Models;

namespace PizzaHut.PizzaApp.Data.Repositories.Interfaces
{
    public interface IPizzaIngredientRepository
    {
        IEnumerable<PizzaIngredient> GetAll();
        public PizzaIngredient GetPizzaIngredient(Guid id);
        public PizzaIngredient CreatePizzaIngredient(PizzaIngredient pizzaIngredient);
        public PizzaIngredient UpdatePizzaIngredient(PizzaIngredient pizzaIngredient);
        public PizzaIngredient DeletePizzaIngredient(PizzaIngredient pizzaIngredient);
    }
}
