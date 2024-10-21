using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo_Balta.Data;
using ToDo_Balta.Models;

namespace ToDo_Balta.Controllers;

[ApiController]
[Route("v1")]
public class ToDoController : ControllerBase
{
    [HttpGet]
    [Route("todos")]
    public async Task<IActionResult> Get([FromServices] AppDbContext context)
    {
        var todos = await context
            .Todos
            .AsNoTracking()    
            .ToListAsync();
        
        return Ok(todos);
    }
}