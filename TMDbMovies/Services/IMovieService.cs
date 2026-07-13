using System.Text.Json;
using System.Text.Json.Serialization;
using TMDbMovies.Models;

namespace TMDbMovies.Services
{
    public interface IMovieService
    {
        Task<MovieResult> GetMovieByTitleAsync(string title);
    }

    public class MovieService : IMovieService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public MovieService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _apiKey = config["TMDbApi:ApiKey"];
        }

        public async Task<MovieResult> GetMovieByTitleAsync(string title)
        {
            var url = $"search/movie?api_key={_apiKey}&query={Uri.EscapeDataString(title)}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            var searchResult = JsonSerializer.Deserialize<TMDbSearchResponse>(json);

            return searchResult?.Results?.FirstOrDefault();
        }
    }
}