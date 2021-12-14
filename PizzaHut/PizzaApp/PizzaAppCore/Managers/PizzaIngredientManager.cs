using System;
using System.Collections.Generic;

using PizzaHut.PizzaApp.Data;
using PizzaHut.PizzaApp.Data.Models;
using PizzaHut.PizzaApp.Core.Managers.Interfaces;

namespace PizzaHut.PizzaApp.Core.Managers
{
    public class PizzaIngredientManager : IPizzaIngredientManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public PizzaIngredientManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<PizzaIngredient> GetAll()
        {
            return _unitOfWork.PizzaIngredientRepository.GetAll();
        }

        public PizzaIngredient GetPizzaIngredient(string id)
        {
            Guid guid = Guid.Parse(id);
            return _unitOfWork.PizzaIngredientRepository.GetPizzaIngredient(guid);
        }

        public PizzaIngredient CreatePizzaIngredient(PizzaIngredient pizzaIngredient)
        {
            PizzaIngredient newPizzaIngredient = _unitOfWork.PizzaIngredientRepository.CreatePizzaIngredient(pizzaIngredient);
            _unitOfWork.Save();
            return newPizzaIngredient;
        }

        public PizzaIngredient DeletePizzaIngredient(string guid)
        {
            PizzaIngredient pizzaIngredient = GetPizzaIngredient(guid);
            _unitOfWork.PizzaIngredientRepository.DeletePizzaIngredient(pizzaIngredient);
            _unitOfWork.Save();
            return pizzaIngredient;
        }
    }
}
