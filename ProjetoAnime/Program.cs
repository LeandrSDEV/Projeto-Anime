var builder = WebApplication.CreateBuilder(args);

// Adiciona a injeção de dependência do AnimeService
builder.Services.AddScoped<IAnimeService, AnimeService>();

// Adiciona a injeção de dependência do AnimeRepository
builder.Services.AddScoped<IAnimeRepository, AnimeRepository>();

// Configurações do DbContext
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
