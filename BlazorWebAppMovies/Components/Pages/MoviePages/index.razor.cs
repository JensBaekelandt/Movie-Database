using BlazorWebAppMovies.Data;
using BlazorWebAppMovies.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;

using Microsoft.EntityFrameworkCore;

namespace Components.Pages.MoviePages.index
{
    //public partial class Index : ComponentBase, IAsyncDisposable
    //{
    //    [Inject]
    //    private IDbContextFactory<BlazorWebAppMoviesContext> DbFactory { get; set; } = default!;

    //    private BlazorWebAppMoviesContext context = default!;

    //    protected override void OnInitialized()
    //    {
    //        context = DbFactory.CreateDbContext();
    //    }

    //    public async ValueTask DisposeAsync() => await context.DisposeAsync();

    //    private string titleFilter = string.Empty;

    //    private IQueryable<Movie> FilteredMovies =>
    //        context.Movie.Where(m => m.Title!.Contains(titleFilter));

    //    private PaginationState pagination = new PaginationState { ItemsPerPage = 10 };
    //}
}