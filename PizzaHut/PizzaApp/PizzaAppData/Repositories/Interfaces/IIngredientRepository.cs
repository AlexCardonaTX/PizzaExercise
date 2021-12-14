using System;
using System.Collections.Generic;

using PizzaHut.PizzaApp.Data.Models;

namespace PizzaHut.PizzaApp.Data.Repositories.Interfaces
{
    public interface IIngredientRepository
    {
        IEnumerable<Ingredient> GetAll();
        public Ingredient GetIngredient(Guid id);
        public Ingredient CreateIngredient(Ingredient ingredient);
        public Ingredient UpdateIngredient(Ingredient ingredient);
        public Ingredient DeleteIngredient(Ingredient ingredient);

    }
}
