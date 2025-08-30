using MediatR;
using ProjetoAnime.Core.Entidade;
using ProjetoAnime.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            await _repository.AddAsync(anime);
            return anime;
        }
    }

}
