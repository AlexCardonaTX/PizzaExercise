using System.Collections.Generic;

using PizzaHut.PizzaApp.Data.Models;

namespace PizzaHut.PizzaApp.Core.Managers.Interfaces
{
    public interface IPizzaIngredientManager
    {
        IEnumerable<PizzaIngredient> GetAll();
        PizzaIngredient GetPizzaIngredient(string id);
        PizzaIngredient CreatePizzaIngredient(PizzaIngredient pizzaIngredient);
        PizzaIngredient DeletePizzaIngredient(string guid);
    }
}
