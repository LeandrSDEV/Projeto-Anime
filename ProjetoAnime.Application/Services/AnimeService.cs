using ProjetoAnime.Application.Interfaces;
using ProjetoAnime.Core.Entidade;
using ProjetoAnime.Core.Repository;

namespace ProjetoAnime.Application.Services
{
    public class AnimeService : IAnimeService
    {
        private readonly IAnimeRepository _animeRepository;

        public AnimeService(IAnimeRepository animeRepository)
        {
            _animeRepository = animeRepository;
        }

        public async Task<IEnumerable<Anime>> GetAllAnimesAsync()
        {
            return await _animeRepository.GetAllAsync();
        }

        public async Task<Anime> GetAnimeByIdAsync(int id)
        {
            return await _animeRepository.GetByIdAsync(id);
        }

        public async Task<Anime> CreateAnimeAsync(Anime anime)
        {
            return await _animeRepository.AddAsync(anime);
        }

        public async Task<Anime> UpdateAnimeAsync(Anime anime)
        {
            return await _animeRepository.UpdateAsync(anime);
        }

        public async Task DeleteAnimeAsync(int id)
        {
            await _animeRepository.DeleteAsync(id);
        }
    }

}
