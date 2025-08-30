using Microsoft.EntityFrameworkCore;
using ProjetoAnime.Core.Entidade;
using ProjetoAnime.Core.Repository;
using ProjetoAnime.Infrastructure.Data;

namespace ProjetoAnime.Infrastructure.Repository
{
    public class AnimeRepository : IAnimeRepository
    {
        private readonly AnimeDbContext _context;

        public AnimeRepository(AnimeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Anime>> GetAllAsync() => await _context.Animes.ToListAsync();
        public async Task<Anime> GetByIdAsync(int id) => await _context.Animes.FindAsync(id);
        public async Task<Anime> AddAsync(Anime anime)
        {
            _context.Animes.Add(anime);
            await _context.SaveChangesAsync();
            return anime;
        }
        public async Task<Anime> UpdateAsync(Anime anime)
        {
            _context.Animes.Update(anime);
            await _context.SaveChangesAsync();
            return anime;
        }
        public async Task DeleteAsync(int id)
        {
            var anime = await _context.Animes.FindAsync(id);
            if (anime != null)
            {
                _context.Animes.Remove(anime);
                await _context.SaveChangesAsync();
            }
        }
    }

}
