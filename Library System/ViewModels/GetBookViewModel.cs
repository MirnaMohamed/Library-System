using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Library_System.ViewModels
{
    public class GetBookViewModel
    {
        public int BookId { get; internal set; }
        [Required, StringLength(100, MinimumLength =3)]
        public required string BookTitle { get; set; }
        [EnumDataType(typeof(Genre))]
        public Genre Genre { get; set; }
        [MaxLength(300)]
        public string? Description { get; set; }

        public bool IsAvailable { get; set; }
        public required string AuthorName { get; set; }
    }
}
