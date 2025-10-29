using BlazorWebAppMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebAppMovies.Sdk
{
    public class MovieSdkService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MovieSdkService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //Find
        public async Task<IList<Movie>> Find()
        {
            var httpClient = _httpClientFactory.CreateClient("MovieApi");
            var route = "/api/movie";

            var response = await httpClient.GetAsync(route);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<IList<Movie>>();
            return result ?? new List<Movie>();
        }

        //Get
        public async Task<Movie?> Get(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("MovieApi");
            var route = $"/api/movie/{id}";
            var response = await httpClient.GetAsync(route);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<Movie >();
            return result;
        }

        //Post
        public async Task<Movie> Post(Movie movie)
        {
            var httpClient = _httpClientFactory.CreateClient("MovieApi");
            var route = "/api/movie";
            var response = await httpClient.PostAsJsonAsync(route, movie);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<Movie>();
            return result!;
        }

        //Put
        public async Task Put(int id, Movie movie)
        {
            var httpClient = _httpClientFactory.CreateClient("MovieApi");
            var route = $"/api/movie/{id}";
            var response = await httpClient.PutAsJsonAsync(route, movie);
            response.EnsureSuccessStatusCode();
        }

        //Delete
        public async Task Delete(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("MovieApi");
            var route = $"/api/movie/{id}";
            var response = await httpClient.DeleteAsync(route);
            response.EnsureSuccessStatusCode();
        }
    }
}
