using System;
using System.Collections.Generic;

using PizzaHut.PizzaApp.Data.Models;

namespace PizzaHut.PizzaApp.Data.Repositories.Interfaces
{
    public interface IPizzaRepository
    {
        IEnumerable<Pizza> GetAll();
        public Pizza GetIngredient(Guid id);
        public Pizza CreateIngredient(Pizza pizza);
        public Pizza UpdateIngredient(Pizza pizza);
        public Pizza DeleteIngredient(Pizza pizza);
    }
}
