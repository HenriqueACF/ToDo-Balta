using ToDo_Balta.Data;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// app.MapGet("/", () => "Hello World!");
//SERVICES
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>();

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
