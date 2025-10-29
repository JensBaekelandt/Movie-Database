using BlazorWebAppMovies.Models;
using FluentValidation;

namespace BlazorWebAppMovies.Api.Validation
{
    public class MovieValidator : AbstractValidator<Movie>
    {
        public MovieValidator() 
        {
            RuleFor(movie => movie.Title)
                .NotEmpty()
                .Length(3, 60);
            RuleFor(movie => movie.Genre)
                .MaximumLength(30);
            RuleFor(movie => movie.Price)
                .InclusiveBetween(0, 100);
            RuleFor(movie => movie.Rating)
                .NotEmpty()
                .Matches("^(G|PG|PG-13|R|NC-17)$");
        }
        
    }
}
