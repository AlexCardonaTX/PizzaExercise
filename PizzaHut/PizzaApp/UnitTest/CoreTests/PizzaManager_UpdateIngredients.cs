using System;
using Moq;
using NUnit.Framework;

using PizzaHut.PizzaApp.Core.Managers;
using PizzaHut.PizzaApp.Core.Managers.Interfaces;
using PizzaHut.PizzaApp.Data;
using PizzaHut.PizzaApp.Data.Models;
using PizzaHut.PizzaApp.Data.Repositories.Interfaces;

namespace PizzaHut.PizzaApp.UnitTest.CoreTests
{
    public class PizzaManager_UpdateIngredients
    {
        private IPizzaManager _pizzaManager;
        private IUnitOfWork _uow;

        [SetUp]
        public void Setup()
        {
            Pizza pizza = new Pizza
            {
                PizzaId = Guid.Parse("ce46c209-e7ee-4f8a-b5ab-0cd8a2ef9564"),
                PizzaName = "Extra Cheese Pizza"
            };
            Ingredient cheese = new Ingredient
            {
                IngredientId = Guid.Parse("82f5462d-b629-478d-898a-1d7ab85e8bdd"),
                IngredientName = "Extra Cheese"
            };
            Ingredient olive = new Ingredient
            {
                IngredientId = Guid.Parse("ed0fd52d-7f8f-44dd-b444-ae510211adad"),
                IngredientName = "Olive"
            };
            PizzaIngredient pizzaIngredient = new PizzaIngredient
            {
                Ingredient = cheese,
                IngredientId = (Guid)cheese.IngredientId,
                Pizza = pizza,
                PizzaId = (Guid)pizza.PizzaId,
                PizzaIngredientId = Guid.Parse("3ed552a8-5761-4aa5-f3c8-08d9c0a19635")
            };
            pizza.PizzaIngredients.Add(pizzaIngredient);

            var pizzaRepositoryMock = new Mock<IPizzaRepository>();
            pizzaRepositoryMock.Setup(p => p.GetPizza((Guid)pizza.PizzaId)).Returns(pizza);
            var ingredientRepositoryMock = new Mock<IIngredientRepository>();
            ingredientRepositoryMock.Setup(i => i.GetIngredient((Guid)olive.IngredientId)).Returns(olive);
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(u => u.IngredientRepository).Returns(ingredientRepositoryMock.Object);
            unitOfWorkMock.Setup(u => u.PizzaRepository).Returns(pizzaRepositoryMock.Object);

            _pizzaManager = new PizzaManager(unitOfWorkMock.Object);
            _uow = unitOfWorkMock.Object;
        }

        [Test]
        public void PizzaManager_UpdateIngredients_When_Ingredients_Are_Already_Assigned()
        {
            string pizzaId = "ce46c209-e7ee-4f8a-b5ab-0cd8a2ef9564";
            string[] ingredientsIds = new string[] {
                "82f5462d-b629-478d-898a-1d7ab85e8bdd"
            };
            Pizza oldPizza = _uow.PizzaRepository.GetPizza(Guid.Parse(pizzaId));
            Pizza newPizza = _pizzaManager.UpdateIngredients(pizzaId, ingredientsIds);
            Assert.AreEqual(oldPizza, newPizza);
        }
    }
}