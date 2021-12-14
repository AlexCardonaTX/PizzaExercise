using System.Collections.Generic;

using PizzaHut.PizzaApp.Data.Models;

namespace PizzaHut.PizzaApp.Core.Managers.Interfaces
{
    public interface IPizzaManager
    {
        public IEnumerable<Pizza> GetAll();
        public Pizza GetPizza(string id);
        public Pizza CreatePizza(Pizza pizza);
        public Pizza UpdatePizza(Pizza newPizza, string id);
        public Pizza DeletePizza(string id);
    }
}
