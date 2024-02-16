using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Data;
using SuperHeroApi.Models;
using SuperHeroApi.Services;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HeroPlacesController : ControllerBase
    {
        private readonly IHeroPlacesServices _heroplaces;
        private readonly SuperHeroDb _context;
        public HeroPlacesController(IHeroPlacesServices heroplaces , SuperHeroDb context)
        {
            _heroplaces = heroplaces;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Places>>> GetAllPlaces()
        {

            return await _heroplaces.GetAllPlaces();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Places>>> GetOnePlace(int id)
        {
            var result = await _heroplaces.GetOnePlace(id);
            if(result == null)
                  return NotFound("Place not found!!!");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Places>>> AddPlaces(Places places)
        {
            var result = await _heroplaces.AddPlaces(places);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Places>>> UpdatePlaces(int id , Places places)
        {
            var result = await _heroplaces.UpdatePlaces(id, places);
            if (result == null)
                return NotFound("Place not found!!!");

            return Ok(result);
        } 
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Places>>> DeletePlaces(int id)
        {
            var result = await _heroplaces.DeletePlaces(id);
            if (result == null)
                return NotFound("Place not found!!!");

            return Ok(result);
        }
    }
}
