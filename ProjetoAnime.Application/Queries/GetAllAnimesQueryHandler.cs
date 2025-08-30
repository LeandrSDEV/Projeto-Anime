using MediatR;
using ProjetoAnime.Application.Interfaces;
using ProjetoAnime.Core.Entidade;

namespace ProjetoAnime.Application.Queries
{
    public class GetAllAnimesQueryHandler : IRequestHandler<GetAllAnimesQuery, List<Anime>>
    {
        private readonly IAnimeRepository _animeRepository;

        public GetAllAnimesQueryHandler(IAnimeRepository animeRepository)
        {
            _animeRepository = animeRepository;
        }

        public async Task<List<Anime>> Handle(GetAllAnimesQuery request, CancellationToken cancellationToken)
        {
            var animes = await _animeRepository.GetAllAsync();
            return animes;
        }
    }
}
