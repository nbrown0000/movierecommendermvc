using Newtonsoft.Json;

namespace MovieRecommender.Models
{
    public class Actor
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("profile_path")]
        public string Image { get; set; }

        [JsonProperty("character")]
        public string Character { get; set; }
    }
}
