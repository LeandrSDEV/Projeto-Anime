using Microsoft.EntityFrameworkCore;
using ProjetoAnime.Application.Interfaces;
using ProjetoAnime.Application.Services;
using ProjetoAnime.Core.Repository;
using ProjetoAnime.Infrastructure.Data;
using ProjetoAnime.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAnimeService, AnimeService>();

builder.Services.AddScoped<IAnimeRepository, AnimeRepository>();

builder.Services.AddDbContext<AnimeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
