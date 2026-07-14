using Margorak.Api.Data;
using Margorak.Api.Interfaces;
using Margorak.Api.Repositories;
using Margorak.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<CharacterService>();
builder.Services.AddScoped<CombatantHabitatService>();
builder.Services.AddScoped<IMapInteractionDtoFactory, ShopInteractionDtoFactory>();
builder.Services.AddScoped<IMapInteractionDtoFactory, TeleporterInteractionDtoFactory>();
builder.Services.AddScoped<MapService>();
builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();
builder.Services.AddScoped<ICombatantRepository, CombatantRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IMapInteractionRepository, MapInteractionRepository>();
builder.Services.AddScoped<IMapRepository, MapRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Angular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("Angular");

app.UseAuthorization();

app.MapControllers();

app.Run();
