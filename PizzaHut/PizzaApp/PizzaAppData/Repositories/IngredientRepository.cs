using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using PizzaHut.PizzaApp.Data.Models;
using PizzaHut.PizzaApp.Data.Repositories.Interfaces;

namespace PizzaHut.PizzaApp.Data.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly PizzaAppDBContext _pizzaAppDBContext;
        public IngredientRepository(PizzaAppDBContext pizzaAppDBContext)
        {
            _pizzaAppDBContext = pizzaAppDBContext;
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return _pizzaAppDBContext.Ingredient;
        }

        public Ingredient GetIngredient(Guid id)
        {
            return _pizzaAppDBContext.Ingredient.Find(id);
        }

        public Ingredient CreateIngredient(Ingredient ingredient)
        {
            return _pizzaAppDBContext.Ingredient.Add(ingredient).Entity;
        }

        public Ingredient UpdateIngredient(Ingredient ingredient)
        {
            _pizzaAppDBContext.Entry(ingredient).State = EntityState.Modified;
            return ingredient;
        }

        public Ingredient DeleteIngredient(Ingredient ingredient)
        {
            _pizzaAppDBContext.Ingredient.Remove(ingredient);
            return ingredient;
        }
    }
}
