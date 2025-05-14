using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Library_System.ViewModels
{
    public class AddAuthorViewModel
    {
        public int AuthorId { get; set; }= -1;
        [Required, MinLength(2)]
        public required string FirstName { get; set; }
        [Required, MinLength(2)]
        public required string SecondName { get; set; }
        [Required, MinLength(2)]
        public required string ThirdName { get; set; }
        [Required, MinLength(2)]
        public required string LastName { get; set; }
        [EmailAddress, Required, MaxLength(150)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        public required string UserEmail { get; set; }
        [MaxLength(200)]
        public string? PersonalWebsite { get; set; }
        [MaxLength(300)]
        public string? Biography { get; set; }
    }
}
