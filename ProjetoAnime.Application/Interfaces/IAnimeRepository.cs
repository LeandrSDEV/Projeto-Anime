using ProjetoAnime.Core.Entidade;

namespace ProjetoAnime.Application.Interfaces
{
    public interface IAnimeRepository
    {
        Task<Anime> GetByIdAsync(int id);
        Task<List<Anime>> GetAllAsync();
        Task<Anime> AddAsync(Anime anime);
        Task<Anime> UpdateAsync(Anime anime);
        Task DeleteAsync(int id);
    }
}
