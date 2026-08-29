using Farmacia.api.Data;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddControllers();


//carrega o env
DotNetEnv.Env.Load();

//carrega a variável de ambiente
var connectionString =
    Environment.GetEnvironmentVariable("FARMACIA_CONNECTION");

//CONFIGURANDO A FARMACIA COMO NOSSO DBCONTEXT
builder.Services.AddDbContext<FarmaciaDbContext>(options =>
    options.UseNpgsql(connectionString));

Console.WriteLine("string de conexão: " + connectionString);

var app = builder.Build();
app.MapControllers();
try
{
    using var scope = app.Services.CreateScope();

    var db = scope.ServiceProvider.GetRequiredService<FarmaciaDbContext>();

    db.Database.OpenConnection();

    Console.WriteLine("CONEXÃO COM POSTGRES OK!");
}
catch (Exception ex)
{
    Console.WriteLine("ERRO AO CONECTAR:");
    Console.WriteLine(ex.Message);
}

app.MapGet("/", () => "Hello World!");

app.Run();