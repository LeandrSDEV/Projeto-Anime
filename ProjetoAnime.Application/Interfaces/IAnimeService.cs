using ProjetoAnime.Core.Entidade;

namespace ProjetoAnime.Application.Interfaces
{
    public interface IAnimeService
    {
        Task<IEnumerable<Anime>> GetAllAnimesAsync();
        Task<Anime> GetAnimeByIdAsync(int id);
        Task<Anime> CreateAnimeAsync(Anime anime);
        Task<Anime> UpdateAnimeAsync(Anime anime);
        Task DeleteAnimeAsync(int id);
    }
}
