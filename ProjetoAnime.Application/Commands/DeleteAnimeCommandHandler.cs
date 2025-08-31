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
        private readonly IAnimeRepository _repository;

        public DeleteAnimeCommandHandler(IAnimeRepository repository)
        {
            _repository = repository;
        }

        // Método Handle com Task<Unit> como retorno
        public async Task<Unit> Handle(DeleteAnimeCommand request, CancellationToken cancellationToken)
        {
            var anime = await _repository.GetByIdAsync(request.Id);
            if (anime == null)
                throw new KeyNotFoundException($"Anime com ID {request.Id} não encontrado.");

            await _repository.DeleteAsync(request.Id);

            return Unit.Value;
        }

        Task IRequestHandler<DeleteAnimeCommand>.Handle(DeleteAnimeCommand request, CancellationToken cancellationToken)
        {
            return Handle(request, cancellationToken);
        }
    }
}
