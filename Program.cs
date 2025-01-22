using HeroCreator.Data;
using HeroCreator.Repositories;
using HeroCreator.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

ConfigureDatabase(builder);

ConfigureServices(builder);

ConfigureSwagger(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    ConfigureDevelopment(app);
}


ConfigureMiddleware(app);

app.Run();

void ConfigureDatabase(WebApplicationBuilder builder)
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
}

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();
    builder.Services.AddScoped<ICharacterService, CharacterService>();
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
}

void ConfigureSwagger(WebApplicationBuilder builder)
{
    builder.Services.AddSwaggerGen(options =>
    {
        options.EnableAnnotations();
    });
}

void ConfigureDevelopment(WebApplication app)
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    });

    app.UseDeveloperExceptionPage();
}

void ConfigureMiddleware(WebApplication app)
{
    app.UseRouting();
    app.UseHttpsRedirection();

    app.MapGet("/", () => "Hello World!").ExcludeFromDescription();

    app.MapControllers();
}
