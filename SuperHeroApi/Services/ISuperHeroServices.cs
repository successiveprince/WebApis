using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Models;

namespace SuperHeroApi.Services
{
    public interface ISuperHeroServices
    {
        Task<ActionResult<List<SuperHero>>> GetAllHeroes();
        Task<ActionResult<SuperHero>> GetOneHero(int id);
        Task<SuperHero> AddHero(SuperHero hero);
        Task<SuperHero> UpdateHero(int id , SuperHero hero);
        
    }
}
