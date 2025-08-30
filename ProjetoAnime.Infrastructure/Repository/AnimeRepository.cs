using Microsoft.EntityFrameworkCore;
using ProjetoAnime.Application.Interfaces;
using ProjetoAnime.Core.Entidade;
using ProjetoAnime.Infrastructure.Data;

namespace ProjetoAnime.Infrastructure.Repositories
{
    public class AnimeRepository : IAnimeRepository
    {
        private readonly AnimeDbContext _context;

        public AnimeRepository(AnimeDbContext context)
        {
            _context = context;
        }
    
        public async Task<List<Anime>> GetAllAsync()
            => await _context.Animes.ToListAsync();

        public async Task<Anime> GetByIdAsync(int id)
            => await _context.Animes.FindAsync(id);

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
            var existingAnime = await _context.Animes.FindAsync(id);
            if (existingAnime == null)
            {
                throw new ArgumentException("Anime não encontrado.");
            }

            _context.Animes.Remove(existingAnime);
            await _context.SaveChangesAsync();
        }
    }
}
