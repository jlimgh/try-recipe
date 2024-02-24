using ErrorOr;

namespace TryRecipe.ServiceErrors;
public static class Errors
{
    public static class Recipe
    {
        public static Error NotFound => Error.NotFound(
            code: "Recipe.NotFound",
            description: "Recipe not found"
        );
    }
}
