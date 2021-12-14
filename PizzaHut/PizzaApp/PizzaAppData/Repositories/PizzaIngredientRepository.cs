using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using PizzaHut.PizzaApp.Data.Models;
using PizzaHut.PizzaApp.Data.Repositories.Interfaces;

namespace PizzaHut.PizzaApp.Data.Repositories
{
    public class PizzaIngredientRepository : IPizzaIngredientRepository
    {
        private readonly PizzaAppDBContext _pizzaAppDBContext;
        public PizzaIngredientRepository(PizzaAppDBContext pizzaAppDBContext)
        {
            _pizzaAppDBContext = pizzaAppDBContext;
        }

        public IEnumerable<PizzaIngredient> GetAll()
        {
            return _pizzaAppDBContext.PizzaIngredient;
        }

        public PizzaIngredient GetIngredient(Guid id)
        {
            return _pizzaAppDBContext.PizzaIngredient.Find(id);
        }

        public PizzaIngredient CreateIngredient(PizzaIngredient pizzaIngredient)
        {
            return _pizzaAppDBContext.PizzaIngredient.Add(pizzaIngredient).Entity;
        }

        public PizzaIngredient UpdateIngredient(PizzaIngredient pizzaIngredient)
        {
            _pizzaAppDBContext.Entry(pizzaIngredient).State = EntityState.Modified;
            return pizzaIngredient;
        }

        public PizzaIngredient DeleteIngredient(PizzaIngredient pizzaIngredient)
        {
            _pizzaAppDBContext.PizzaIngredient.Remove(pizzaIngredient);
            return pizzaIngredient;
        }
    }
}
