using System;
using System.Collections.Generic;

using PizzaHut.PizzaApp.Data;
using PizzaHut.PizzaApp.Data.Models;
using PizzaHut.PizzaApp.Core.Managers.Interfaces;

namespace PizzaHut.PizzaApp.Core.Managers
{
    public class PizzaManager : IPizzaManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public PizzaManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Pizza> GetAll()
        {
            return _unitOfWork.PizzaRepository.GetAll();
        }

        public Pizza GetPizza(string id)
        {
            Guid guid = Guid.Parse(id);
            return _unitOfWork.PizzaRepository.GetPizza(guid);
        }

        public Pizza CreatePizza(Pizza pizza)
        {
            Pizza newPizza = new()
            {
                PizzaId = Guid.NewGuid(),
                PizzaName = pizza.PizzaName,
                PizzaIngredients = new HashSet<PizzaIngredient>()
            };
            _unitOfWork.PizzaRepository.CreatePizza(newPizza);
            _unitOfWork.Save();
            return newPizza;
        }

        public Pizza UpdatePizza(Pizza newPizza, string id)
        {
            Pizza pizza = GetPizza(id);
            if (pizza != null)
            {
                pizza.PizzaName = newPizza.PizzaName;
            }
            _unitOfWork.PizzaRepository.UpdatePizza(pizza);
            _unitOfWork.Save();
            return pizza;
        }

        public Pizza DeletePizza(string id)
        {
            Pizza pizza = GetPizza(id);
            if (pizza != null)
            {
                _unitOfWork.PizzaRepository.DeletePizza(pizza);
                _unitOfWork.Save();
            }
            return pizza;
        }

        public Pizza UpdateIngredients(string pizzaId, string[] ingredientsIds)
        {
            Guid pizzaGuid = Guid.Parse(pizzaId);
            Pizza pizza = _unitOfWork.PizzaRepository.GetPizza(pizzaGuid);
            if (pizza != null)
            {
                foreach (string ingredientId in ingredientsIds)
                {
                    bool found = false;
                    Guid ingredientGuid = Guid.Parse(ingredientId);
                    foreach (PizzaIngredient pizzaIngredient in pizza.PizzaIngredients)
                    {
                        if (pizzaIngredient.IngredientId == ingredientGuid)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        AddIngredient(pizza, ingredientGuid);
                    }
                }

                foreach (PizzaIngredient pizzaIngredient in pizza.PizzaIngredients)
                {
                    bool found = false;
                    foreach (string ingredientId in ingredientsIds)
                    {
                        Guid ingredientGuid = Guid.Parse(ingredientId);
                        if (pizzaIngredient.IngredientId == ingredientGuid)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        RemoveIngredient(pizza, pizzaIngredient);
                    }
                }

            }
            _unitOfWork.PizzaRepository.UpdatePizza(pizza);
            _unitOfWork.Save();
            return pizza;
        }

        private void AddIngredient(Pizza pizza, Guid ingredientGuid)
        {
            Ingredient ingredient = _unitOfWork.IngredientRepository.GetIngredient(ingredientGuid);
            if (ingredient != null)
            {
                PizzaIngredient pizzaIngredient = new()
                {
                    IngredientId = ingredientGuid,
                    PizzaId = (Guid)pizza.PizzaId
                };
                pizza.PizzaIngredients.Add(pizzaIngredient);
            }
        }

        private void RemoveIngredient(Pizza pizza, PizzaIngredient pizzaIngredient)
        {
            pizza.PizzaIngredients.Remove(pizzaIngredient);
        }
    }
}
