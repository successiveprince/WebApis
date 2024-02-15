using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SuperHeroApi.Models
{
    public class Places
    {
        [Key]
        public int PId { get; internal set; }
        public string? PName { get; set; }

        [JsonIgnore]
        public IList<SuperHero>? SuperHeroes { get; set; }

    }
}
