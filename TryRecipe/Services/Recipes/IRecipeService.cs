using ErrorOr;
using TryRecipe.Models;

namespace TryRecipe.Services.Recipes;
public interface IRecipeService
{
    ErrorOr<Created>CreateRecipe(Recipe recipe);
    ErrorOr<Deleted> DeleteRecipe(Guid id);
    ErrorOr<Recipe> GetRecipe(Guid id);
    ErrorOr<UpsertedRecipe> UpsertRecipe(Recipe recipe);
}
