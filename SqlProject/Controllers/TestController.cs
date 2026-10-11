using Microsoft.AspNetCore.Mvc;
using SqlProject.Interfaces.Managers;
using SqlProject.Models;

namespace SqlProject.Controllers;

[Route("api/test")]
[ApiController]
public class TestController : ControllerBase
{
    private ITestManager TestManager { get; }

    public TestController(ITestManager testManager)
    {
        TestManager = testManager;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = await TestManager.GetTestModel();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
        }
    }

    [HttpGet("search")]
    public async Task<ActionResult<List<Actor>>> Search([FromQuery] string name)
    {
        var result = await TestManager.SearchActorsAsync(name ?? string.Empty);
        return Ok(result);
    }
}
