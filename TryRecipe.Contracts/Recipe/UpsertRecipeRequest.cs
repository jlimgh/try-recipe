namespace TryRecipe.Contracts.Recipe;
public record UpsertRecipeRequest
(
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Savory,
    List<string> Sweet
);
