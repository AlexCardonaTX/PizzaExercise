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

        public Pizza AddIngredient(string pizzaId, string ingredientId)
        {
            Guid pizzaGuid = Guid.Parse(pizzaId);
            Guid ingredientGuid = Guid.Parse(ingredientId);
            Pizza pizza = _unitOfWork.PizzaRepository.GetPizza(pizzaGuid);
            Ingredient ingredient = _unitOfWork.IngredientRepository.GetIngredient(ingredientGuid);
            if (pizza != null && ingredient != null)
            {
                PizzaIngredient pizzaIngredient = new()
                {
                    IngredientId = ingredientGuid,
                    PizzaId = pizzaGuid
                };
                pizza.PizzaIngredients.Add(pizzaIngredient);
                _unitOfWork.PizzaRepository.UpdatePizza(pizza);
                //_unitOfWork.PizzaIngredientRepository.CreatePizzaIngredient(pizzaIngredient);
                _unitOfWork.Save();
                return pizza;
            }

            return null;
        }
    }
}
