using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

using PizzaHut.PizzaApp.Core.Managers.Interfaces;
using PizzaHut.PizzaApp.Data.Models;
using PizzaHut.PizzaApp.Presentation.Middleware;

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
            var response = new MiddlewareResponse<IEnumerable<Ingredient>>(_ingredientManager.GetAll());
            return (response.Error.Message == null) ? Ok(response.Data) : Ok(response);
        }

        [HttpGet("{ingredientId}")]
        public IActionResult GetIngredient([FromRoute, Required] string ingredientId)
        {
            var response = new MiddlewareResponse<Ingredient>(_ingredientManager.GetIngredient(ingredientId));
            return (response.Error.Message == null) ? Ok(response.Data) : Ok(response);
        }

        [HttpPost]
        public IActionResult CreateIngredient([FromBody, Required] Ingredient ingredient)
        {
            var response = new MiddlewareResponse<Ingredient>(_ingredientManager.CreateIngredient(ingredient));
            return (response.Error.Message == null) ? Ok(response.Data) : Ok(response);
        }

        [HttpPut("{ingredientId}")]
        public IActionResult UpdateIngredient([FromBody, Required] Ingredient ingredient, [FromHeader] string ingredientId)
        {
            var response = new MiddlewareResponse<Ingredient>(_ingredientManager.UpdateIngredient(ingredient, ingredientId));
            return (response.Error.Message == null) ? Ok(response.Data) : Ok(response);
        }

        [HttpDelete("{ingredientId}")]
        public IActionResult DeleteIngredient([FromRoute, Required] string ingredientId)
        {
            var response = new MiddlewareResponse<Ingredient>(_ingredientManager.DeleteIngredient(ingredientId));
            return (response.Error.Message == null) ? Ok(response.Data) : Ok(response);
        }
    }
}
