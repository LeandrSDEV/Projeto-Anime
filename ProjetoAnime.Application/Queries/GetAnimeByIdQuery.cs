using MediatR;
using ProjetoAnime.Core.Entidade;

namespace ProjetoAnime.Application.Queries
{
    public class GetAnimeByIdQuery : IRequest<Anime>
    {
        public int Id { get; set; }
    }
}
