using PokemonAPI.BL.ExternalServices;
using PokemonAPI.BL.Interfaces;
using PokemonAPI.BL.Services;
using PokemonAPI.Entities.Mappings.Profiles;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(PokemonProfile).Assembly);

builder.Services.AddScoped<IPokemonService, PokemonService>();
builder.Services.AddScoped<IPokeApiService, PokeApiService>();
builder.Services.AddScoped<IFunTranslationService, FunTranslationService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
