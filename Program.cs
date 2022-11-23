using BibliotecaEmprestimos.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<MyDbContext>();

var app = builder.Build();
app.MapControllers();

app.Run();
