using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Data;
using SuperHeroApi.Models;
using SuperHeroApi.Services;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroServices _superHeroServices;
        private readonly SuperHeroDb _context;
        public SuperHeroController(ISuperHeroServices superHeroServices , SuperHeroDb context)
        {
            _superHeroServices = superHeroServices;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
           
            return await _superHeroServices.GetAllHeroes();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetOneHero(int id)
        {
            var result = await _superHeroServices.GetOneHero(id);

            if(result == null)
            {
                return NotFound("Hero not found!!!");
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            var result = await _superHeroServices.AddHero(hero);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Places>>> UpdateHero(int id, SuperHero hero)
        {
            var result = await _superHeroServices.UpdateHero(id, hero);
            if (result == null)
                return NotFound("Hero not found!!!");

            return Ok(result);
        }
    }
}
