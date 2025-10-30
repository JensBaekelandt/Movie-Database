using BlazorWebAppMovies.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;

namespace BlazorWebAppMovies.Components.Pages.MoviePages
{
    public partial class Index : ComponentBase
    {
        private List<Movie> movies = new();
        private string titleFilter = string.Empty;
        private PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

        public IQueryable<Movie> FilteredMovies =>
             movies
                 .Where(m =>
                     string.IsNullOrWhiteSpace(titleFilter) ||
                     m.Title.Contains(titleFilter, StringComparison.OrdinalIgnoreCase))
                 .AsQueryable();

        protected override async Task OnInitializedAsync()
        {
            var result = await MovieService.Find();
            movies = result.OrderByDescending(m => m.ReleaseDate).ToList();
        }

       
    }
}
