using MediatR;
using ProjetoAnime.Application.Interfaces;
using ProjetoAnime.Core.Entidade;

namespace ProjetoAnime.Application.Queries
{
    public class GetAllAnimesQueryHandler : IRequestHandler<GetAllAnimesQuery, IEnumerable<Anime>>
    {
        private readonly IAnimeRepository _repository;

        public GetAllAnimesQueryHandler(IAnimeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Anime>> Handle(GetAllAnimesQuery request, CancellationToken cancellationToken)
        {
            var animes = (await _repository.GetAllAsync()).ToList();

            if (!string.IsNullOrEmpty(request.Nome))
                animes = animes
                    .Where(a => a.Nome.Contains(request.Nome, StringComparison.OrdinalIgnoreCase))
                    .ToList();

            if (!string.IsNullOrEmpty(request.Diretor))
                animes = animes
                    .Where(a => a.Diretor.Contains(request.Diretor, StringComparison.OrdinalIgnoreCase))
                    .ToList();

            return animes;
        }

    }

}
