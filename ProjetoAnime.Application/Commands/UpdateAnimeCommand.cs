using MediatR;
using ProjetoAnime.Core.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAnime.Application.Commands
{
    public class UpdateAnimeCommand : IRequest<Anime>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Diretor { get; set; }
        public string Resumo { get; set; }
    }
}
