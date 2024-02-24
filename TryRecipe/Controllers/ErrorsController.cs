using Microsoft.AspNetCore.Mvc;

namespace TryRecipe.Controllers;
public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}
