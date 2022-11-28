using BibliotecaEmprestimos.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(option => option.SuppressModelStateInvalidFilter = true);
builder.Services.AddDbContext<MyDbContext>();

var app = builder.Build();
app.MapControllers();

app.Run();
