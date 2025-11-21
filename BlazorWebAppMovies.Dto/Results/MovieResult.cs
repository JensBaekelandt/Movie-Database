using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebAppMovies.Dto.Results
{
    public class MovieResult
    {
        public int Id { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string? Title { get; set; }

        public DateOnly ReleaseDate { get; set; }

        //[RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [StringLength(30)]
        public string? Genre { get; set; }

        [Range(0, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]

        public decimal Price { get; set; }

        [Required]
        //[RegularExpression(@"^(G|PG|PG-13|R|NC-17)$")]
        public string? Rating { get; set; }
    }
}
