using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroApi.Data;
using SuperHeroApi.Models;

namespace SuperHeroApi.Services
{
    
    public class SuperHeroServices : ISuperHeroServices
    {
        //private static List<SuperHero> superHeroes = new List<SuperHero>
        //{
        //        new SuperHero
        //        {
        //            Id = 1,
        //            Name = "Spider Man",
        //            FirstName = "Peter",
        //            LastName = "Parker",
                   
        //        },
        //        new SuperHero
        //        {
        //            Id = 2,
        //            Name = "Iron Man",
        //            FirstName = "Tony",
        //            LastName = "Stark",
                   
        //        }

        //};
        private readonly SuperHeroDb _context;

        public SuperHeroServices(SuperHeroDb context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            return heroes;
        }
        public async Task<ActionResult<SuperHero>> GetOneHero(int id)
        {
            var hero = _context.SuperHeroes.Find(id);
            if (hero == null)
                return null;
            return  hero;
        }
        public async Task<SuperHero> AddHero(SuperHero hero)
        {
            await _context.SuperHeroes.AddAsync(hero);
            _context.SaveChanges();
            return hero;
        }

        public async Task<SuperHero> UpdateHero(int id  , SuperHero request)
        {
            var hero = _context.SuperHeroes.Find(id);
            if (hero == null)
                return null;

            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.PlaceRefId = request.PlaceRefId;

            await _context.SaveChangesAsync();
            return hero;
        }

        public async Task<SuperHero> DeleteHero(int id)
        {
            var hero = _context.SuperHeroes.Find(id);
            if (hero == null)
                return null;
            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();
            return hero;
        }

    }
}
