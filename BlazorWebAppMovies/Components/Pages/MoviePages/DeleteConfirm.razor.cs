using BlazorWebAppMovies.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAppMovies.Components.Pages.MoviePages
{
    public partial class DeleteConfirm
    {
        private Movie? movie;

        [SupplyParameterFromQuery]
        private int Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            using var context = DbFactory.CreateDbContext();
            movie = await context.Movie.FirstOrDefaultAsync(m => m.Id == Id);

            if (movie is null)
            {
                NavigationManager.NavigateTo("notfound");
            }
        }
        private async Task DeleteMovie()
        {
            using var context = DbFactory.CreateDbContext();
            context.Movie.Remove(movie!);
            await context.SaveChangesAsync();
            NavigationManager.NavigateTo("/movies");
        }
    }
}
