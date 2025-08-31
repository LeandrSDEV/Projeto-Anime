using Microsoft.EntityFrameworkCore;
using ProjetoAnime.Application.Commands;
using ProjetoAnime.Application.Interfaces;
using ProjetoAnime.Application.Queries;
using ProjetoAnime.Infrastructure.Data;
using ProjetoAnime.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetAllAnimesQuery>());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateAnimeCommand>());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<DeleteAnimeCommandHandler>());

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
