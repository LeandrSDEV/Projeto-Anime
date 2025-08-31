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
            return await _repository.GetFilteredAsync(request.Nome, request.Diretor);
        }
    }

}
