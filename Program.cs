using HeroCreator.Data;
using HeroCreator.Repositories;
using HeroCreator.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar o DbContext com a string de conexão
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicionar serviços
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adicionar repositórios e serviços
builder.Services.AddScoped<CharacterRepository>();
builder.Services.AddScoped<CharacterService>();

var app = builder.Build();

// Habilitar o Swagger somente em ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
        c.RoutePrefix = "swagger"; // Caminho para acessar a interface
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Iniciar o aplicativo
app.Run();
