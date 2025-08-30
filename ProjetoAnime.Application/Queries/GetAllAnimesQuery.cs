using MediatR;
using ProjetoAnime.Core.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAnime.Application.Queries
{
    public class GetAllAnimesQuery : IRequest<List<Anime>>
    {
    }
}
