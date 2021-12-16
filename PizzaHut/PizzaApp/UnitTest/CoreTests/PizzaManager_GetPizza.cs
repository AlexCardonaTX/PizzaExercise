using System;
using Moq;
using NUnit.Framework;
using PizzaHut.PizzaApp.Core.Exceptions;
using PizzaHut.PizzaApp.Core.Managers;
using PizzaHut.PizzaApp.Core.Managers.Interfaces;
using PizzaHut.PizzaApp.Data;
using PizzaHut.PizzaApp.Data.Models;
using PizzaHut.PizzaApp.Data.Repositories.Interfaces;

namespace PizzaHut.PizzaApp.UnitTest.CoreTests
{
    public class PizzaManager_GetPizza
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
            var pizzaRepositoryMock = new Mock<IPizzaRepository>();
            pizzaRepositoryMock.Setup(p => p.GetPizza((Guid)pizza.PizzaId)).Returns(pizza);
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(u => u.PizzaRepository).Returns(pizzaRepositoryMock.Object);

            _pizzaManager = new PizzaManager(unitOfWorkMock.Object);
            _uow = unitOfWorkMock.Object;
        }

        [Test]
        public void PizzaManager_GetPizza_Throws_CoreException_With_Bad_Format_For_Guid()
        {
            string pizzaId = "e7ee-ce46c209-b5ab-0cd8a2ef9564-4f8a";
            
            var ex = Assert.Throws<CoreException>(() => _pizzaManager.GetPizza(pizzaId));
            Assert.That(ex.Message, Is.EqualTo("Format error, Guid should contain 32 digits with 4 dashes"));
        }
    }
}