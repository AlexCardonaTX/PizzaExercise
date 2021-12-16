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

        [HttpGet]
        public IActionResult GetPizzas()
        {
            var response = new MiddlewareResponse<IEnumerable<Pizza>>(_pizzaManager.GetAll());
            return (response.Error.Message == null) ? Ok(response.Data) : Ok(response);
        }

        [HttpGet("{pizzaId}")]
        public IActionResult GetPizza([FromRoute, Required] string pizzaId)
        {
            var response = new MiddlewareResponse<Pizza>(_pizzaManager.GetPizza(pizzaId));
            return (response.Error.Message == null) ? Ok(response.Data) : Ok(response);
        }

        [HttpPost]
        public IActionResult CreatePizza([FromBody, Required] Pizza pizza)
        {
            var response = new MiddlewareResponse<Pizza>(_pizzaManager.CreatePizza(pizza));
            return (response.Error.Message == null) ? Ok(response.Data) : Ok(response);
        }

        [HttpPut("{pizzaId}")]
        public IActionResult UpdatePizza([FromBody, Required] Pizza pizza, [FromRoute, Required] string pizzaId)
        {
            var response = new MiddlewareResponse<Pizza>(_pizzaManager.UpdatePizza(pizza, pizzaId));
            return (response.Error.Message == null) ? Ok(response.Data) : Ok(response);
        }

        [HttpDelete("{pizzaId}")]
        public IActionResult DeletePiza([FromRoute, Required] string pizzaId)
        {
            var response = new MiddlewareResponse<Pizza>(_pizzaManager.DeletePizza(pizzaId));
            return (response.Error.Message == null) ? Ok(response.Data) : Ok(response);
        }

        [HttpPut]
        [Route("{pizzaId}/ingredients")]
        public IActionResult UpdateIngredients(string pizzaId, [FromBody, Required] string[] ingredientsIds)
        {
            var response = new MiddlewareResponse<Pizza>(_pizzaManager.UpdateIngredients(pizzaId, ingredientsIds));
            return (response.Error.Message == null) ? Ok(response.Data) : Ok(response);
        }
    }
}
