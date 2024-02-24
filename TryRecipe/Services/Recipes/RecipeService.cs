using ErrorOr;
using TryRecipe.Models;
using TryRecipe.ServiceErrors;

namespace TryRecipe.Services.Recipes;
public class RecipeService : IRecipeService
{
    private static readonly Dictionary<Guid, Recipe> _recipes = new();
    public ErrorOr<Created> CreateRecipe(Recipe recipe) {
        _recipes.Add(recipe.Id, recipe);
        return Result.Created;
    }

    public ErrorOr<Deleted> DeleteRecipe(Guid id)
    {
        _recipes.Remove(id);
        return Result.Deleted;
    }

    public ErrorOr<Recipe> GetRecipe(Guid id) {
        if (_recipes.TryGetValue(id, out var recipe))
        {
            return recipe;
        }

        return Errors.Recipe.NotFound;
    }

    public ErrorOr<UpsertedRecipe> UpsertRecipe(Recipe recipe)
    {
        var isNewlyCreated = !_recipes.ContainsKey(recipe.Id);
        _recipes[recipe.Id] = recipe;

        return new UpsertedRecipe(isNewlyCreated);
    }
}
