using BlazorWebAppMovies.Data;
using BlazorWebAppMovies.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAppMovies.Components.Pages.MoviePages
{
    public partial class Index : ComponentBase, IAsyncDisposable
    {
        [Inject]
        private IDbContextFactory<BlazorWebAppMoviesContext> DbFactory { get; set; } = default!;

        private BlazorWebAppMoviesContext context = default!;
        private string titleFilter = string.Empty;
        private PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

        private IQueryable<Movie> FilteredMovies =>
            context.Movie.Where(m => m.Title!.Contains(titleFilter));

        protected override void OnInitialized()
        {
            context = DbFactory.CreateDbContext();
        }

        public async ValueTask DisposeAsync()
        {
            await context.DisposeAsync();
        }
    }
}
