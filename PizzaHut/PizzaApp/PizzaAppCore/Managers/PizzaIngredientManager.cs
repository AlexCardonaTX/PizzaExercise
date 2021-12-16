using System;
using System.Collections.Generic;

using PizzaHut.PizzaApp.Data;
using PizzaHut.PizzaApp.Data.Models;
using PizzaHut.PizzaApp.Core.Managers.Interfaces;
using PizzaHut.PizzaApp.Data.Exceptions;
using PizzaHut.PizzaApp.Core.Exceptions;

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
            try
            {
                Guid guid = Guid.Parse(id);
                return _unitOfWork.PizzaIngredientRepository.GetPizzaIngredient(guid);
            } 
            catch (FormatException)
            {
                throw new CoreException("Format error, Guid should contain 32 digits with 4 dashes", 400);
            }

        }

        public PizzaIngredient CreatePizzaIngredient(PizzaIngredient pizzaIngredient)
        {
            PizzaIngredient newPizzaIngredient = _unitOfWork.PizzaIngredientRepository.CreatePizzaIngredient(pizzaIngredient);
            _unitOfWork.Save();
            return newPizzaIngredient;
        }

        public PizzaIngredient DeletePizzaIngredient(string guid)
        {
            try
            {
                PizzaIngredient pizzaIngredient = GetPizzaIngredient(guid);
                _unitOfWork.PizzaIngredientRepository.DeletePizzaIngredient(pizzaIngredient);
                _unitOfWork.Save();
                return pizzaIngredient;
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
    }
}
