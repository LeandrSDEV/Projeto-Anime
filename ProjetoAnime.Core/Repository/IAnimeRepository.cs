using ProjetoAnime.Core.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAnime.Core.Repository
{
    public interface IAnimeRepository
    {
        Task<IEnumerable<Anime>> GetAllAsync();
        Task<Anime> GetByIdAsync(int id);
        Task<Anime> AddAsync(Anime anime);
        Task<Anime> UpdateAsync(Anime anime);
        Task DeleteAsync(int id);
    }
}
