using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace TMDbMovies.Models
{
    public class TMDbSearchResponse
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("results")]
        public List<MovieResult> Results { get; set; }

        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }
    }
}