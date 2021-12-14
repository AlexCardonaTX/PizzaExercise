using System;
using System.Collections.Generic;

using PizzaHut.PizzaApp.Data;
using PizzaHut.PizzaApp.Data.Models;

namespace PizzaHut.PizzaApp.Core.Managers
{
    public class IngredientManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public IngredientManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return _unitOfWork.IngredientRepository.GetAll();
        }

        public Ingredient GetIngredient(string id)
        {
            Guid guid = Guid.Parse(id);
            return _unitOfWork.IngredientRepository.GetIngredient(guid);
        }

        public Ingredient CreateIngredient(Ingredient ingredient)
        {
            Ingredient newIngredient = new()
            {
                IngredientId = Guid.NewGuid(),
                IngredientName = ingredient.IngredientName,
                Pizzas = new HashSet<PizzaIngredient>()
            };
            _unitOfWork.IngredientRepository.CreateIngredient(newIngredient);
            _unitOfWork.Save();
            return newIngredient;
        }

        public Ingredient UpdateIngredient(Ingredient newIngredient, string id)
        {
            Ingredient ingredient = GetIngredient(id);
            if (ingredient != null)
            {
                ingredient.IngredientName = newIngredient.IngredientName;
            }
            _unitOfWork.IngredientRepository.UpdateIngredient(ingredient);
            _unitOfWork.Save();
            return ingredient;
        }

        public Ingredient DeleteIngredient(string id)
        {
            Ingredient ingredient = GetIngredient(id);
            if (ingredient != null)
            {
                _unitOfWork.IngredientRepository.DeleteIngredient(ingredient);
                _unitOfWork.Save();
            }
            return ingredient;
        }
    }
}
