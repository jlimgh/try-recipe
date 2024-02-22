using Microsoft.AspNetCore.Mvc;
using TryRecipe.Contracts.Recipe;
using TryRecipe.Models;
using TryRecipe.Services.Recipes;

namespace TryRecipe.Controllers;

[ApiController]
[Route("[controller]")]
public class RecipesController : ControllerBase
{
    private readonly IRecipeService _recipeService;

    public RecipesController(IRecipeService recipeService)
    {
        _recipeService = recipeService;
    }

    [HttpPost()]
    public IActionResult CreateRecipe(CreateRecipeRequest request)
    {
        var recipe = new Recipe(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet
        );

        _recipeService.CreateRecipe(recipe);

        var response = new RecipeReponse(
            recipe.Id,
            recipe.Name,
            recipe.Description,
            recipe.StartDateTime,
            recipe.EndDateTime,
            recipe.LastModifiedDateTime,
            recipe.Savory,
            recipe.Sweet
        );
        return CreatedAtAction(
            actionName: nameof(GetRecipe),
            routeValues: new { id = recipe.Id },
            value: response
        );
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetRecipe(Guid id)
    {
        Recipe recipe = _recipeService.GetRecipe(id);

        var response = new RecipeReponse(
            recipe.Id,
            recipe.Name,
            recipe.Description,
            recipe.StartDateTime,
            recipe.EndDateTime,
            recipe.LastModifiedDateTime,
            recipe.Savory,
            recipe.Sweet
        );
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertRecipe(Guid id, UpsertRecipeRequest request)
    {
        var recipe = new Recipe(
            id,
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet
        );

        _recipeService.UpsertRecipe(recipe);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteRecipe(Guid id)
    {
        _recipeService.DeleteRecipe(id);
        return NoContent();
    }

}
