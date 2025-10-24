using BlazorWebAppMovies.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAppMovies.Components.Pages.MoviePages
{
    public partial class Edit
    {
        [SupplyParameterFromQuery]
        private int Id { get; set; }

        [SupplyParameterFromForm]
        private Movie? Movie { get; set; }

        protected override async Task OnInitializedAsync()
        {
            using var context = DbFactory.CreateDbContext();
            Movie ??= await context.Movie.FirstOrDefaultAsync(m => m.Id == Id);

            if (Movie is null)
            {
                NavigationManager.NavigateTo("notfound");
            }
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://learn.microsoft.com/aspnet/core/blazor/forms/#mitigate-overposting-attacks.
        private async Task UpdateMovie()
        {
            using var context = DbFactory.CreateDbContext();
            context.Attach(Movie!).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(Movie!.Id))
                {
                    NavigationManager.NavigateTo("notfound");
                }
                else
                {
                    throw;
                }
            }

            NavigationManager.NavigateTo("/movies");
        }

        private bool MovieExists(int id)
        {
            using var context = DbFactory.CreateDbContext();
            return context.Movie.Any(e => e.Id == id);
        }
    }
}
