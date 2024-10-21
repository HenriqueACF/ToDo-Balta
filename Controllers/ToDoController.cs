using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo_Balta.Data;
using ToDo_Balta.Models;

namespace ToDo_Balta.Controllers;

[ApiController]
[Route("v1")]
public class ToDoController : ControllerBase
{
    // pegando todos os dados
    [HttpGet]
    [Route("todos")]
    public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
    {
        var todos = await context
            .Todos
            .AsNoTracking()    
            .ToListAsync();
        
        return Ok(todos);
    }
    
    [HttpGet]
    [Route("todos/{id}")]
    public async Task<IActionResult> GetByIdAsync(
        [FromServices] AppDbContext context,
        [FromRoute] int id)
    {
        var todo = await context
            .Todos
            .AsNoTracking()    
            .FirstOrDefaultAsync(x => x.Id == id);

        return todo == null ? NotFound() : Ok(todo);
    }
}