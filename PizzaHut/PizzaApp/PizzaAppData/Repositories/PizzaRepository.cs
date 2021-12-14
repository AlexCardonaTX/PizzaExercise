using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using PizzaHut.PizzaApp.Data.Models;
using PizzaHut.PizzaApp.Data.Repositories.Interfaces;

namespace PizzaHut.PizzaApp.Data.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly PizzaAppDBContext _pizzaAppDBContext;
        public PizzaRepository(PizzaAppDBContext pizzaAppDBContext)
        {
            _pizzaAppDBContext = pizzaAppDBContext;
        }

        public IEnumerable<Pizza> GetAll()
        {
            return _pizzaAppDBContext.Pizza;
        }

        public Pizza GetIngredient(Guid id)
        {
            return _pizzaAppDBContext.Pizza.Find(id);
        }

        public Pizza CreateIngredient(Pizza pizza)
        {
            return _pizzaAppDBContext.Pizza.Add(pizza).Entity;
        }

        public Pizza UpdateIngredient(Pizza pizza)
        {
            _pizzaAppDBContext.Entry(pizza).State = EntityState.Modified;
            return pizza;
        }

        public Pizza DeleteIngredient(Pizza pizza)
        {
            _pizzaAppDBContext.Pizza.Remove(pizza);
            return pizza;
        }
    }
}
