using ProjetoAnime.Core.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
