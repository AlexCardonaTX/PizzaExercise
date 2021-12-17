using System;
using System.Collections.Generic;
using System.Linq;
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
            return _pizzaAppDBContext.Pizza
                    .Include(p => p.PizzaIngredients)
                    .ThenInclude(pi => pi.Ingredient);
        }

        public Pizza GetPizza(Guid id)
        {
            return _pizzaAppDBContext.Pizza
                    .Include(p => p.PizzaIngredients)
                    .ThenInclude(pi => pi.Ingredient)
                    .Where(p => p.PizzaId == id)
                    .FirstOrDefault();
        }

        public Pizza CreatePizza(Pizza pizza)
        {
            return _pizzaAppDBContext.Pizza.Add(pizza).Entity;
        }

        public Pizza UpdatePizza(Pizza pizza)
        {
            _pizzaAppDBContext.Entry(pizza).State = EntityState.Modified;
            return pizza;
        }

        public Pizza DeletePizza(Pizza pizza)
        {
            _pizzaAppDBContext.Pizza.Remove(pizza);
            return pizza;
        }
    }
}
