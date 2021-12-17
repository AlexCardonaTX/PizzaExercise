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

        /// <summary>
        ///   Get All registered Ingredients
        /// </summary>
        /// <response code="500">Unknown Error</response>
        [HttpGet]
        public IActionResult GetIngredients()
        {
            var response = new MiddlewareResponse<IEnumerable<Ingredient>>(_ingredientManager.GetAll());
            return (response.Error.Message == null) ? Ok(response.Data) : Ok(response);
        }

        /// <summary>
        ///   Get a Ingredient and its details given a IngredientId
        /// </summary>
        /// <param name="ingredientId">Unique Identifier</param>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Unknown Error</response>
        [HttpGet("{ingredientId}")]
        public IActionResult GetIngredient([FromRoute, Required] string ingredientId)
        {
            var response = new MiddlewareResponse<Ingredient>(_ingredientManager.GetIngredient(ingredientId));
            return (response.Error.Message == null) ? Ok(response.Data) : Ok(response);
        }

        /// <summary>
        ///   Post a new Ingredient
        /// </summary>
        /// <param name="ingredient">Ingredient</param>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Unknown Error</response>
        [HttpPost]
        public IActionResult CreateIngredient([FromBody, Required] Ingredient ingredient)
        {
            var response = new MiddlewareResponse<Ingredient>(_ingredientManager.CreateIngredient(ingredient));
            return (response.Error.Message == null) ? Ok(response.Data) : Ok(response);
        }

        /// <summary>
        ///   Update a Ingredient details given a IngredientId, except for IngredientId
        /// </summary>
        /// <param name="ingredient">Ingredient</param>
        /// <param name="ingredientId">Unique Identifier</param>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Unknown Error</response>
        [HttpPut("{ingredientId}")]
        public IActionResult UpdateIngredient([FromBody, Required] Ingredient ingredient, [FromHeader] string ingredientId)
        {
            var response = new MiddlewareResponse<Ingredient>(_ingredientManager.UpdateIngredient(ingredient, ingredientId));
            return (response.Error.Message == null) ? Ok(response.Data) : Ok(response);
        }

        /// <summary>
        ///   Delete a Ingredient given a Guid, only if the Ingredient isn't used in any Pizza
        /// </summary>
        /// <param name="ingredientId">Unique Identifier</param>
        /// <response code="400">Bad Request</response>
        /// <response code="405">The entity has one or more relations in DB and can not be deleted</response>
        /// <response code="500">Unknown Error</response>
        [HttpDelete("{ingredientId}")]
        public IActionResult DeleteIngredient([FromRoute, Required] string ingredientId)
        {
            var response = new MiddlewareResponse<Ingredient>(_ingredientManager.DeleteIngredient(ingredientId));
            return (response.Error.Message == null) ? Ok(response.Data) : Ok(response);
        }
    }
}
