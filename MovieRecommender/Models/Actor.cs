using Newtonsoft.Json;

namespace MovieRecommender.Models
{
    public class Actor
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}
