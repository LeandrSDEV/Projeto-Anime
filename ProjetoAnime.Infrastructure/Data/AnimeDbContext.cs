using Microsoft.EntityFrameworkCore;
using ProjetoAnime.Core.Entidade;

namespace ProjetoAnime.Infrastructure.Data
{
    public class AnimeDbContext : DbContext
    {
        public AnimeDbContext(DbContextOptions<AnimeDbContext> options) : base(options) { }

        public DbSet<Anime> Animes { get; set; }
    }
}
