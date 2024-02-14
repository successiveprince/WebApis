using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Models;
using SuperHeroApi.Services;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroServices _superHeroServices;
        public SuperHeroController(ISuperHeroServices superHeroServices)
        {
            _superHeroServices = superHeroServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
           
            return await _superHeroServices.GetAllHeroes();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetOneHero(int id)
        {
            var result = _superHeroServices.GetOneHero(id);

            if(result == null)
            {
                return NotFound("Hero not found!!!");
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            var result = _superHeroServices.AddHero(hero);

            return Ok(result);
        }
    }
}
