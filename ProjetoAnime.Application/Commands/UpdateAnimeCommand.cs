using MediatR;
using ProjetoAnime.Core.Entidade;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAnime.Application.Commands
{
    public class UpdateAnimeCommand : IRequest<Anime>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public string Diretor { get; set; } = string.Empty;

        [Required]
        public string Resumo { get; set; } = string.Empty;
    }
}
