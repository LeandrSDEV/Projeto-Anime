using MediatR;
using ProjetoAnime.Application.Interfaces;
using ProjetoAnime.Core.Entidade;

namespace ProjetoAnime.Application.Queries
{
    public class CreateAnimeCommandHandler : IRequestHandler<CreateAnimeCommand, Anime>
    {
        private readonly IAnimeRepository _repository;

        public CreateAnimeCommandHandler(IAnimeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Anime> Handle(CreateAnimeCommand request, CancellationToken cancellationToken)
        {
            var anime = new Anime
            {
                Nome = request.Nome,
                Diretor = request.Diretor,
                Resumo = request.Resumo
            };

            return await _repository.AddAsync(anime);
        }
    }
}
