using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Models;

namespace SuperHeroApi.Services
{
    
    public class SuperHeroServices : ISuperHeroServices
    {
        private static List<SuperHero> superHeroes = new List<SuperHero>
        {
                new SuperHero
                {
                    Id = 1,
                    Name = "Spider Man",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Place = "New York"
                },
                new SuperHero
                {
                    Id = 2,
                    Name = "Iron Man",
                    FirstName = "Tony",
                    LastName = "Stark",
                    Place = "Malibu"
                }

        };


        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            return superHeroes;
        }
        public async Task<ActionResult<SuperHero>> GetOneHero(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero == null)
                return null;
            return  hero;
        }
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            superHeroes.Add(hero);
            return superHeroes;
        }


    }
}
