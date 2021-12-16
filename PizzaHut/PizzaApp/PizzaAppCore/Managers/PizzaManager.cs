using System;
using System.Collections.Generic;

using PizzaHut.PizzaApp.Data;
using PizzaHut.PizzaApp.Data.Models;
using PizzaHut.PizzaApp.Core.Managers.Interfaces;
using PizzaHut.PizzaApp.Data.Exceptions;
using PizzaHut.PizzaApp.Core.Exceptions;

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
            try
            {
                Guid guid = Guid.Parse(id);
                return _unitOfWork.PizzaRepository.GetPizza(guid);
            }
            catch (FormatException)
            {
                throw new CoreException("Format error, Guid should contain 32 digits with 4 dashes", 400);
            }
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
            try
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
            catch (FormatException)
            {
                throw new CoreException("Format error, Guid should contain 32 digits with 4 dashes", 400);
            }
        }

        public Pizza DeletePizza(string id)
        {
            try
            {
                Pizza pizza = GetPizza(id);
                if (pizza != null)
                {
                    _unitOfWork.PizzaRepository.DeletePizza(pizza);
                    _unitOfWork.Save();
                }
                return pizza;
            }
            catch (DataException)
            {
                throw new DataException("The entity has one or more relations in DB", 405);
            }
            catch (FormatException)
            {
                throw new CoreException("Format error, Guid should contain 32 digits with 4 dashes", 400);
            }
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
