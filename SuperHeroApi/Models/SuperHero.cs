using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SuperHeroApi.Models
{
    public class SuperHero
    {
        [Key]
        public int Id { get; internal set; }
        public string Name { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        //public string Place { get; set; } = string.Empty;
        public int PlaceRefId { get; set; }

        [JsonIgnore]
        
        public Places? HeroPlaces { get; set; }
    }
}
