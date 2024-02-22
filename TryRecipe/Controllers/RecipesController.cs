using Microsoft.AspNetCore.Mvc;
using TryRecipe.Contracts.Recipe;

namespace TryRecipe.Controllers;

[ApiController]
public class RecipesController : ControllerBase
{
    [HttpPost("/recipes")]
    public IActionResult CreateRecipe(CreateRecipeRequest request)
    {
        return Ok(request);
    }

    [HttpGet("/recipes/{id: guid}")]
    public IActionResult GetRecipe(Guid id)
    {
        return Ok(id);
    }

    [HttpPut("/recipes/{id: guid}")]
    public IActionResult UpsertRecipe(Guid id, UpsertRecipeRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("/recipes/{id: guid}")]
    public IActionResult DeleteRecipe(Guid id)
    {
        return Ok(id);
    }

}
