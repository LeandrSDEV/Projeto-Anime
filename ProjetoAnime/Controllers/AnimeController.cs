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
        public async Task<IActionResult> Create([FromBody] CreateAnimeCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var anime = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = anime.Id }, anime);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAnimeCommand command)
        {
            if (id != command.Id)
                return BadRequest("ID na URL não corresponde ao corpo da requisição.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _mediator.Send(command);
            return Ok(updated);
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
