using System;
using System.Net;
using System.Collections.Generic;

using PizzaHut.PizzaApp.Data;
using PizzaHut.PizzaApp.Data.Models;
using PizzaHut.PizzaApp.Core.Managers.Interfaces;
using PizzaHut.PizzaApp.Data.Exceptions;
using PizzaHut.PizzaApp.Core.Exceptions;

namespace PizzaHut.PizzaApp.Core.Managers
{
    public class IngredientManager : IIngredientManager
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
            try
            {
                Guid guid = Guid.Parse(id);
                return _unitOfWork.IngredientRepository.GetIngredient(guid);
            } 
            catch (FormatException)
            {
                throw new CoreException("Format error, Guid should contain 32 digits with 4 dashes", HttpStatusCode.BadRequest);
            }
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
            try
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
            catch (FormatException)
            {
                throw new CoreException("Format error, Guid should contain 32 digits with 4 dashes", HttpStatusCode.BadRequest);
            }

        }

        public Ingredient DeleteIngredient(string id)
        {
            try
            {
                Ingredient ingredient = GetIngredient(id);
                if (ingredient != null)
                {
                    _unitOfWork.IngredientRepository.DeleteIngredient(ingredient);
                    _unitOfWork.Save();
                }
                return ingredient;
            }
            catch (DataException)
            {
                throw new DataException("The entity has one or more relations in DB", HttpStatusCode.MethodNotAllowed);
            }
            catch (FormatException)
            {
                throw new CoreException("Format error, Guid should contain 32 digits with 4 dashes", HttpStatusCode.BadRequest);
            }

        }
    }
}
