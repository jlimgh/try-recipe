namespace TryRecipe.Contracts.Recipe;
public record CreateRecipeRequest
(
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Savory,
    List<string> Sweet
);
