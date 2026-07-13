using System.Text.Json.Serialization;

namespace TMDbMovies.Models
{
    public class MovieResult
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; }

        [JsonPropertyName("overview")]
        public string Overview { get; set; }

        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; }

        [JsonPropertyName("vote_average")]
        public double VoteAverage { get; set; }

        // Not part of the JSON — a computed helper for the view
        [JsonIgnore]
        public string FullPosterUrl =>
            string.IsNullOrEmpty(PosterPath)
                ? null
                : $"https://image.tmdb.org/t/p/w500{PosterPath}";
    }
}