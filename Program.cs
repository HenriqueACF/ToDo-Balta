using ToDo_Balta.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
