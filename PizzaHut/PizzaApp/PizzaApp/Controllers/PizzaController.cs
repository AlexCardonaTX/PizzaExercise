using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

using PizzaHut.PizzaApp.Core.Managers.Interfaces;
using PizzaHut.PizzaApp.Data.Models;
using PizzaHut.PizzaApp.Presentation.Middleware;

namespace PizzaHut.PizzaApp.Presentation.Controllers
{
    [Route("api/pizza")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaManager _pizzaManager;

        public PizzaController(IPizzaManager pizzaManager)
        {
            _pizzaManager = pizzaManager;
        }

        /// <summary>
        ///   Get All registered Pizzas
        /// </summary>
        /// <response code="500">Unknown Error</response>
        [HttpGet]
        public IActionResult GetPizzas()
        {
            var response = new MiddlewareResponse<IEnumerable<Pizza>>(_pizzaManager.GetAll());
            return (response.Error.Message == null) ? Ok(response.Data) : Ok(response);
        }

        /// <summary>
        ///   Get a Pizza and its details given a PizzaId
        /// </summary>
        /// <param name="pizzaId">Unique Identifier</param>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Unknown Error</response>
        [HttpGet("{pizzaId}")]
        public IActionResult GetPizza([FromRoute, Required] string pizzaId)
        {
            var response = new MiddlewareResponse<Pizza>(_pizzaManager.GetPizza(pizzaId));
            return (response.Error.Message == null) ? Ok(response.Data) : Ok(response);
        }

        /// <summary>
        ///   Post a new Pizza
        /// </summary>
        /// <param name="pizza">Pizza</param>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Unknown Error</response>
        [HttpPost]
        public IActionResult CreatePizza([FromBody, Required] Pizza pizza)
        {
            var response = new MiddlewareResponse<Pizza>(_pizzaManager.CreatePizza(pizza));
            return (response.Error.Message == null) ? Ok(response.Data) : Ok(response);
        }

        /// <summary>
        ///   Update a Pizza details given a PizzaId, except for PizzaId and PizzaIngredients
        /// </summary>
        /// <param name="pizza">Pizza</param>
        /// <param name="pizzaId">Unique Identifier</param>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Unknown Error</response>
        [HttpPut("{pizzaId}")]
        public IActionResult UpdatePizza([FromBody, Required] Pizza pizza, [FromRoute, Required] string pizzaId)
        {
            var response = new MiddlewareResponse<Pizza>(_pizzaManager.UpdatePizza(pizza, pizzaId));
            return (response.Error.Message == null) ? Ok(response.Data) : Ok(response);
        }

        /// <summary>
        ///   Delete a Pizza given a Guid, only if the Pizza doesn't have ingredients
        /// </summary>
        /// <param name="pizzaId">Unique Identifier</param>
        /// <response code="400">Bad Request</response>
        /// <response code="405">The entity has one or more relations in DB and can not be deleted</response>
        /// <response code="500">Unknown Error</response>
        [HttpDelete("{pizzaId}")]
        public IActionResult DeletePiza([FromRoute, Required] string pizzaId)
        {
            var response = new MiddlewareResponse<Pizza>(_pizzaManager.DeletePizza(pizzaId));
            return (response.Error.Message == null) ? Ok(response.Data) : Ok(response);
        }

        /// <summary>
        ///   Update a Pizza's Ingredients given a PizzaId and a list of ingredientIds
        /// </summary>
        /// <param name="pizzaId">Unique Identifier</param>
        /// <param name="ingredientsIds">Array with the new ingredients Ids for the pizza</param>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Unknown Error</response>
        [HttpPut]
        [Route("{pizzaId}/ingredients")]
        public IActionResult UpdateIngredients(string pizzaId, [FromBody, Required] string[] ingredientsIds)
        {
            var response = new MiddlewareResponse<Pizza>(_pizzaManager.UpdateIngredients(pizzaId, ingredientsIds));
            return (response.Error.Message == null) ? Ok(response.Data) : Ok(response);
        }
    }
}
