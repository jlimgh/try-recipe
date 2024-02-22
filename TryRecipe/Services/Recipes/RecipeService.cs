using TryRecipe.Models;

namespace TryRecipe.Services.Recipes;
public class RecipeService : IRecipeService
{
    private static readonly Dictionary<Guid, Recipe> _recipes = new();
    public void CreateRecipe(Recipe recipe) {
        _recipes.Add(recipe.Id, recipe);
    }

    public void DeleteRecipe(Guid id)
    {
        _recipes.Remove(id);
    }

    public Recipe GetRecipe(Guid id) {
        return _recipes[id];
    }

    public void UpsertRecipe(Recipe recipe)
    {
        _recipes[recipe.Id] = recipe;
    }
}
