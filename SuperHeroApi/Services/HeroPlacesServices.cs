using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroApi.Data;
using SuperHeroApi.Models;

namespace SuperHeroApi.Services
{
    public class HeroPlacesServices : IHeroPlacesServices
    {
        private readonly SuperHeroDb _context;
        public HeroPlacesServices(SuperHeroDb context)
        {
            _context = context;
        }
    
        public async Task<List<Places>> GetAllPlaces()
        {
            var places = await _context.Places.ToListAsync();
            return places;
        }
  
        public async Task<Places> GetOnePlace(int id)
        {
            var place = await _context.Places.FindAsync(id);
            if(place == null)
            {
                return null;
            }
            return place;
        }


        public async Task<Places> AddPlaces(Places places)
        {
            _context.Places.Add(places);
            await _context.SaveChangesAsync();
            return places;
        }
        public async Task<Places> UpdatePlaces(int id , Places request)
        {
            var place = _context.Places.Find(id);
            if(place == null)
            {
                return null;
            }
            place.PName = request.PName;
            
            await _context.SaveChangesAsync();
            return place;
        }
        public async Task<Places> DeletePlaces(int id)
        {
            var place = _context.Places.Find(id);
            if (place == null)
                return null;
            _context.Places.Remove(place);
            await _context.SaveChangesAsync();
            return place;
        }
    }
}
