using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

using PizzaHut.PizzaApp.Core.Managers.Interfaces;
using PizzaHut.PizzaApp.Data.Models;

namespace PizzaHut.PizzaApp.Presentation.Controllers
{
    [Route("api/ingredient")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientManager _ingredientManager;

        public IngredientController(IIngredientManager ingredientManager)
        {
            _ingredientManager = ingredientManager;
        }

        [HttpGet]
        public IActionResult GetIngredients()
        {
            return Ok(_ingredientManager.GetAll());
        }

        [HttpGet("{ingredientId}")]
        public IActionResult GetIngredient([FromRoute, Required] string ingredientId)
        {
            return Ok(_ingredientManager.GetIngredient(ingredientId));
        }

        [HttpPost]
        public IActionResult CreateIngredient([FromBody, Required] Ingredient ingredient)
        {
            return Ok(_ingredientManager.CreateIngredient(ingredient));
        }

        [HttpPut("{ingredientId}")]
        public IActionResult UpdateIngredient([FromBody, Required] Ingredient ingredient, [FromHeader] string ingredientId)
        {
            return Ok(_ingredientManager.UpdateIngredient(ingredient, ingredientId));
        }

        [HttpDelete("{ingredientId}")]
        public IActionResult DeleteIngredient([FromRoute, Required] string ingredientId)
        {
            return Ok(_ingredientManager.DeleteIngredient(ingredientId));
        }
    }
}
