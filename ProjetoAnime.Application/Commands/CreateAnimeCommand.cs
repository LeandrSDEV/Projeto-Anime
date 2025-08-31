using MediatR;
using ProjetoAnime.Core.Entidade;
using System.ComponentModel.DataAnnotations;

namespace ProjetoAnime.Application.Queries
{
    public class CreateAnimeCommand : IRequest<Anime>
    {
        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public string Diretor { get; set; } = string.Empty;

        [Required]
        public string Resumo { get; set; } = string.Empty;
    }

}
