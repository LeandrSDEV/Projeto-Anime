using ProjetoAnime.Core.Entidade;

namespace ProjetoAnime.Application.Interfaces
{
    public interface IAnimeRepository
    {
        Task<IEnumerable<Anime>> GetFilteredAsync(string? nome, string? diretor);
        Task<Anime> GetByIdAsync(int id);
        Task<Anime> AddAsync(Anime anime);
        Task<Anime> UpdateAsync(Anime anime);
        Task DeleteAsync(int id);
    }
}
