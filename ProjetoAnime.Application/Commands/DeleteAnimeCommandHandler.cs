using MediatR;
using ProjetoAnime.Application.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoAnime.Application.Commands
{
    public class DeleteAnimeCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteAnimeCommandHandler : IRequestHandler<DeleteAnimeCommand>
    {
        private readonly IAnimeRepository _animeRepository;

        public DeleteAnimeCommandHandler(IAnimeRepository animeRepository)
        {
            _animeRepository = animeRepository;
        }

        // Método Handle com Task<Unit> como retorno
        public async Task<Unit> Handle(DeleteAnimeCommand request, CancellationToken cancellationToken)
        {
            var anime = await _animeRepository.GetByIdAsync(request.Id);
            if (anime == null)
            {
                throw new ArgumentException("Anime não encontrado.");
            }

            await _animeRepository.DeleteAsync(request.Id);
            return Unit.Value;  // Retorna Unit.Value para indicar que não há dados a retornar, mas o comando foi bem-sucedido
        }

        Task IRequestHandler<DeleteAnimeCommand>.Handle(DeleteAnimeCommand request, CancellationToken cancellationToken)
        {
            return Handle(request, cancellationToken);
        }
    }
}
