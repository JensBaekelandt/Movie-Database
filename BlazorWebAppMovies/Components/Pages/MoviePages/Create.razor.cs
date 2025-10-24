using BlazorWebAppMovies.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorWebAppMovies.Components.Pages.MoviePages
{
    public partial class Create
    {
        [SupplyParameterFromForm]
        private Movie Movie { get; set; } = new();

        // To protect from overposting attacks, see https://learn.microsoft.com/aspnet/core/blazor/forms/#mitigate-overposting-attacks.
        private async Task AddMovie()
        {
            using var context = DbFactory.CreateDbContext();
            context.Movie.Add(Movie);
            await context.SaveChangesAsync();
            NavigationManager.NavigateTo("/movies");
        }
    }
}
