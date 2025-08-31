using MediatR;

namespace ProjetoAnime.Application.Commands.DeleteAnime
{
    public class DeleteAnimeCommand : IRequest
    {
        public int Id { get; set; }
    }
}