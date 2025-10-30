using BlazorWebAppMovies.Models;
using BlazorWebAppMovies.Sdk;
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
            movie = await MovieService.Get(Id);

            if (movie is null)
            {
                NavigationManager.NavigateTo("notfound");
            }
        }
        private async Task DeleteMovie()
        {
            if (movie != null)
            {
                await MovieService.Delete(movie.Id);
                NavigationManager.NavigateTo("/movies");
            }
           
        }
    }
}
