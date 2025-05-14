using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Library_System.ViewModels
{
    public class GetAuthorViewModel
    {
        public int AuthorId { get; set; }
        public required string FullName { get; set; }
        public required string UserEmail { get; set; }
        public string? PersonalWebsite { get; set; }
        public string? Biography { get; set; }
        public int BooksCount { get; set; }
        public virtual List<string> Books { get; set; } = new List<string>();

    }
}
