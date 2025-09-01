using MediatR;
using ProjetoAnime.Application.Interfaces;
using ProjetoAnime.Core.Entidade;

namespace ProjetoAnime.Application.Commands.UpdateAnime
{
    public class UpdateAnimeCommandHandler : IRequestHandler<UpdateAnimeCommand, Anime>
    {
        private readonly IAnimeRepository _repository;

        public UpdateAnimeCommandHandler(IAnimeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Anime> Handle(UpdateAnimeCommand request, CancellationToken cancellationToken)
        {
            var anime = await _repository.GetByIdAsync(request.Id);
            if (anime == null)
                throw new KeyNotFoundException($"Anime com ID {request.Id} não encontrado.");

            anime.Nome = request.Nome;
            anime.Diretor = request.Diretor;
            anime.Resumo = request.Resumo;

            return await _repository.UpdateAsync(anime);
        }
    }
}
