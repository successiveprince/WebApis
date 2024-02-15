using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Models;

namespace SuperHeroApi.Services
{
    public interface IHeroPlacesServices
    {
        Task<List<Places>> GetAllPlaces();
        Task<Places> GetOnePlace(int id);
        Task<Places> AddPlaces(Places places);
        Task<Places> UpdatePlaces(int id ,Places places);
        Task<Places> DeletePlaces(int id);
    }
}
