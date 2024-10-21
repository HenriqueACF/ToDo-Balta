﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo_Balta.Data;
using ToDo_Balta.Models;
using ToDo_Balta.ViewModels;

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
    
    //PEGANDO POR ID
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

    //CRIANDO TODO
    [HttpPost]
    [Route("todos")]
    public async Task<IActionResult> PostAsync(
        [FromServices] AppDbContext context,
        [FromBody] CreateTodoViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var todo = new ToDo()
        {
            Date = DateTime.Now,
            Done = false,
            Title = model.Title
        };

        try
        {
            await context.Todos.AddAsync(todo);
            await context.SaveChangesAsync();
            return Created($"v1/todos/{todo.Id}", todo);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
}