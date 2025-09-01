using MediatR;
using ProjetoAnime.Application.Interfaces;
using ProjetoAnime.Core.Entidade;

namespace ProjetoAnime.Application.Queries
{
    public class GetAnimeByIdQueryHandler : IRequestHandler<GetAnimeByIdQuery, Anime>
    {
        private readonly IAnimeRepository _animeRepository;

        public GetAnimeByIdQueryHandler(IAnimeRepository animeRepository)
        {
            _animeRepository = animeRepository;
        }

        public async Task<Anime> Handle(GetAnimeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _animeRepository.GetByIdAsync(request.Id);
        }
    }
}
