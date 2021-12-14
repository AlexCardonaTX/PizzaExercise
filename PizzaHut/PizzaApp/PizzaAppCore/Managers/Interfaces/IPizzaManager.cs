using System.Collections.Generic;

using PizzaHut.PizzaApp.Data.Models;

namespace PizzaHut.PizzaApp.Core.Managers.Interfaces
{
    public interface IPizzaManager
    {
        IEnumerable<Pizza> GetAll();
        Pizza GetPizza(string id);
        Pizza CreatePizza(Pizza pizza);
        Pizza UpdatePizza(Pizza newPizza, string id);
        Pizza DeletePizza(string id);
        Pizza AddIngredient(string pizzaId, string ingredientId);
    }
}
