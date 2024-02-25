using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using TryRecipe.Contracts.Recipe;
using TryRecipe.Models;
using TryRecipe.ServiceErrors;
using TryRecipe.Services.Recipes;

namespace TryRecipe.Controllers;

public class RecipesController : ApiController
{
    private readonly IRecipeService _recipeService;

    public RecipesController(IRecipeService recipeService)
    {
        _recipeService = recipeService;
    }

    [HttpPost()]
    public IActionResult CreateRecipe(CreateRecipeRequest request)
    {
        ErrorOr<Recipe> requestToRecipeResult = Recipe.From(request);

        if (requestToRecipeResult.IsError) {
            return Problem(requestToRecipeResult.Errors);
        }

        var recipe = requestToRecipeResult.Value;

        ErrorOr<Created> createRecipeResult = _recipeService.CreateRecipe(recipe);

        return createRecipeResult.Match(
            created => CreatedAtGetRecipe(recipe),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetRecipe(Guid id)
    {
        ErrorOr<Recipe> getRecipeResult = _recipeService.GetRecipe(id);

        return getRecipeResult.Match(
            breakfast => Ok(MapRecipeResponse(breakfast)),
            errors => Problem(errors)
        );

    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertRecipe(Guid id, UpsertRecipeRequest request)
    {
        ErrorOr<Recipe> requestToRecipeResult = Recipe.From(id, request);

        if (requestToRecipeResult.IsError) {
            return Problem(requestToRecipeResult.Errors);
        }

        var recipe = requestToRecipeResult.Value;

        ErrorOr<UpsertedRecipe> upsertedResult = _recipeService.UpsertRecipe(recipe);
        return upsertedResult.Match(
            upserted => upserted.isNewlyCreated ? CreatedAtGetRecipe(recipe) : NoContent(),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteRecipe(Guid id)
    {
        ErrorOr<Deleted> deletedResult = _recipeService.DeleteRecipe(id);
        return deletedResult.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );
    }

    private static RecipeReponse MapRecipeResponse(Recipe recipe)
    {
        return new RecipeReponse(
                    recipe.Id,
                    recipe.Name,
                    recipe.Description,
                    recipe.StartDateTime,
                    recipe.EndDateTime,
                    recipe.LastModifiedDateTime,
                    recipe.Savory,
                    recipe.Sweet
                );
    }

    private CreatedAtActionResult CreatedAtGetRecipe(Recipe recipe)
    {
        return CreatedAtAction(
            actionName: nameof(GetRecipe),
            routeValues: new { id = recipe.Id },
            value: MapRecipeResponse(recipe));
    }

}
