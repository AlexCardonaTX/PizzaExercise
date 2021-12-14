using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

using PizzaHut.PizzaApp.Core.Managers.Interfaces;
using PizzaHut.PizzaApp.Data.Models;

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
            return Ok(_pizzaManager.GetAll());
        }

        [HttpGet("{pizzaId}")]
        public IActionResult GetPizza([FromRoute, Required] string pizzaId)
        {
            return Ok(_pizzaManager.GetPizza(pizzaId));
        }

        [HttpPost]
        public IActionResult CreatePizza([FromBody, Required] Pizza pizza)
        {
            return Ok(_pizzaManager.CreatePizza(pizza));
        }

        [HttpPut("{pizzaId}")]
        public IActionResult UpdatePizza([FromBody, Required] Pizza pizza, [FromRoute, Required] string pizzaId)
        {
            return Ok(_pizzaManager.UpdatePizza(pizza, pizzaId));
        }

        [HttpDelete("{pizzaId}")]
        public IActionResult DeletePiza([FromRoute, Required] string pizzaId)
        {
            return Ok(_pizzaManager.DeletePizza(pizzaId));
        }

        [HttpPost]
        [Route("{pizzaId}/add-ingredient/{ingredientId}")]
        public IActionResult AddIngredient(string pizzaId, string ingredientId)
        {
            return Ok(_pizzaManager.AddIngredient(pizzaId, ingredientId));
        }
    }
}
