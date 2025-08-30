using Microsoft.AspNetCore.Mvc;
using ProjetoAnime.Application.Interfaces;
using ProjetoAnime.Core.Entidade;

namespace ProjetoAnime.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimeController : ControllerBase
    {
        private readonly IAnimeService _animeService;

        public AnimeController(IAnimeService animeService)
        {
            _animeService = animeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var animes = await _animeService.GetAllAnimesAsync();
            return Ok(animes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var anime = await _animeService.GetAnimeByIdAsync(id);
            if (anime == null)
            {
                return NotFound();
            }
            return Ok(anime);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Anime anime)
        {
            var createdAnime = await _animeService.CreateAnimeAsync(anime);
            return CreatedAtAction(nameof(GetById), new { id = createdAnime.Id }, createdAnime);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Anime anime)
        {
            if (id != anime.Id)
            {
                return BadRequest();
            }
            var updatedAnime = await _animeService.UpdateAnimeAsync(anime);
            return Ok(updatedAnime);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _animeService.DeleteAnimeAsync(id);
            return NoContent();
        }
    }

}
