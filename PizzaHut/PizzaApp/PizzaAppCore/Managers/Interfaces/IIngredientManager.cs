using System.Collections.Generic;

using PizzaHut.PizzaApp.Data.Models;

namespace PizzaHut.PizzaApp.Core.Managers.Interfaces
{
    public interface IIngredientManager
    {
        IEnumerable<Ingredient> GetAll();
        Ingredient GetIngredient(string id);
        Ingredient CreateIngredient(Ingredient ingredient);
        Ingredient UpdateIngredient(Ingredient newIngredient, string id);
        Ingredient DeleteIngredient(string id);
    }
}
