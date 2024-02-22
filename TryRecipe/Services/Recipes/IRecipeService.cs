using TryRecipe.Models;

namespace TryRecipe.Services.Recipes;
public interface IRecipeService
{
    void CreateRecipe(Recipe recipe);
    void DeleteRecipe(Guid id);
    Recipe GetRecipe(Guid id);
    void UpsertRecipe(Recipe recipe);
}
