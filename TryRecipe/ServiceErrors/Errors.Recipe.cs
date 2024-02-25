using ErrorOr;

namespace TryRecipe.ServiceErrors;
public static class Errors
{
    public static class Recipe
    {
        public static Error InvalidName => Error.Validation(
            code: "Recipe.InvalidName",
            description: $"Recipe name must be at least {Models.Recipe.MinNameLength}" +
                $" characters long and at most {Models.Recipe.MaxNameLength} characters long.");

        public static Error InvalidDescription => Error.Validation(
            code: "Recipe.InvalidDescription",
            description: $"Recipe description must be at least {Models.Recipe.MinDescriptionLength}" +
                $" characters long and at most {Models.Recipe.MaxDescriptionLength} characters long.");

        public static Error NotFound => Error.NotFound(
            code: "Recipe.NotFound",
            description: "Recipe not found");
    }
}
