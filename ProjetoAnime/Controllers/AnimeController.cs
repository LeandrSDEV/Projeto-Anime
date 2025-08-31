using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoAnime.Application.Commands;
using ProjetoAnime.Application.Queries;
using ProjetoAnime.Core.Entidade;

namespace ProjetoAnime.Controllers
{
    [ApiController]
    [Route("api/v1/animes")]
    public class AnimeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnimeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? nome, [FromQuery] string? diretor)
        {
            var query = new GetAllAnimesQuery
            {
                Nome = nome,
                Diretor = diretor
            };

            var animes = await _mediator.Send(query);
            return Ok(animes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetAnimeByIdQuery { Id = id };
            var anime = await _mediator.Send(query);
            if (anime == null)
            {
                return NotFound();
            }
            return Ok(anime);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnime([FromBody] CreateAnimeCommand command)
        {
            var anime = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = anime.Id }, anime);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnime(int id, [FromBody] Anime anime)
        {
            if (id != anime.Id)
            {
                return BadRequest();
            }
            var command = new UpdateAnimeCommand
            {
                Id = anime.Id,
                Nome = anime.Nome,
                Diretor = anime.Diretor,
                Resumo = anime.Resumo
            };
            var updatedAnime = await _mediator.Send(command);
            return Ok(updatedAnime);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteAnimeCommand { Id = id };  
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
