using MediatR;
using ProjetoAnime.Core.Entidade;

namespace ProjetoAnime.Application.Queries
{
    public class CreateAnimeCommand : IRequest<Anime>
    {
        public string Nome { get; set; }
        public string Diretor { get; set; }
        public string Resumo { get; set; }
    }

}
