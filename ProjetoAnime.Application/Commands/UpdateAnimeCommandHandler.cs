using MediatR;
using ProjetoAnime.Application.Interfaces;
using ProjetoAnime.Core.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAnime.Application.Commands
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
            {
                return null;
            }

            anime.Nome = request.Nome;
            anime.Diretor = request.Diretor;
            anime.Resumo = request.Resumo;

            await _repository.UpdateAsync(anime);
            return anime;
        }
    }

}
