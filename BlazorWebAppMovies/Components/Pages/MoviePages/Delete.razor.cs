using BlazorWebAppMovies.Models;
using BlazorWebAppMovies.Sdk;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAppMovies.Components.Pages.MoviePages
{
    public partial class Delete
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
    }
}
