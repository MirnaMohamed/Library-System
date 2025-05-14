using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Library_System.ViewModels
{
    public class AddBookViewModel
    {
        public int BookId { get; set; } = -1;
        [Required, MinLength(3), MaxLength(50)]
        public required string BookTitle { get; set; }
        [EnumDataType(typeof(Genre)), Required]
        public Genre Genre { get; set; }
        [MaxLength(300)]
        public string? Description { get; set; }
        [Required]
        public required int AuthorId { get; set; }
    }
}
