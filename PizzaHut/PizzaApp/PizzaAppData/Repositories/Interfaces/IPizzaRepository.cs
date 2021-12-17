using System;
using System.Collections.Generic;

using PizzaHut.PizzaApp.Data.Models;

namespace PizzaHut.PizzaApp.Data.Repositories.Interfaces
{
    public interface IPizzaRepository
    {
        IEnumerable<Pizza> GetAll();
        public Pizza GetPizza(Guid id);
        public Pizza CreatePizza(Pizza pizza);
        public Pizza UpdatePizza(Pizza pizza);
        public Pizza DeletePizza(Pizza pizza);
    }
}
