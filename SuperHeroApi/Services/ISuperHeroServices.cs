using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Models;

namespace SuperHeroApi.Services
{
    public interface ISuperHeroServices
    {
        Task<ActionResult<List<SuperHero>>> GetAllHeroes();
        Task<ActionResult<SuperHero>> GetOneHero(int id);
        Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero);
    }
}
