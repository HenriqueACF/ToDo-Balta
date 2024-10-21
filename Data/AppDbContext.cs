using Microsoft.EntityFrameworkCore;
using ToDo_Balta.Models;

namespace ToDo_Balta.Data;

public class AppDbContext :  DbContext
{
    public DbSet<ToDo> Todos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        => optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
    
}