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
            Movie = await MovieService.Get(Id);

            if (Movie is null)
            {
                NavigationManager.NavigateTo("notfound");
            }
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://learn.microsoft.com/aspnet/core/blazor/forms/#mitigate-overposting-attacks.
        private async Task UpdateMovie()
        {
           if (Movie is null)
                return;
            

            try
            {
               await MovieService.Put(Movie.Id, Movie);
              
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"Error updating Movie: {ex.Message}");
            }

            NavigationManager.NavigateTo("/movies");
        }

    }
}
