using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class AddBookDTO
    {
        public required string BookTitle { get; set; }
        public Genre Genre { get; set; }
        public string? Description { get; set; }
        public required int AuthorId { get; set; }
    }
}
