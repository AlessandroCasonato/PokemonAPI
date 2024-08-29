using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.BL.Interfaces;

namespace PokemonAPI.WebApp.Controllers
{
    [Route("pokemon")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly ILogger<PokemonController> _logger;
        private readonly IPokemonService _pokemonService;

        public PokemonController(ILogger<PokemonController> logger,
            IPokemonService pokemonService)
        {
            _logger = logger;
            _pokemonService = pokemonService;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                var result = await _pokemonService.GetPokemonByNameAsync(name);
                return Ok(result);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(statusCode: (int)ex.StatusCode, new { message = ex.Message });
            }
        }

        [HttpGet("translated/{name}")]
        public async Task<IActionResult> GetByNameTranslated(string name)
        {
            try
            {
                var result = await _pokemonService.GetPokemonByNameAsync(name, true);
                return Ok(result);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(statusCode: (int)ex.StatusCode, new { message = ex.Message });
            }
        }
    }
}
