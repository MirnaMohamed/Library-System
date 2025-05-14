using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class GetBookDTO
    {
        public int BookId { get; internal set; }
        public required string BookTitle { get; set; }
        public Genre Genre { get; set; }
        public string? Description { get; set; }

        public bool IsAvailable { get; set; }
        public required string AuthorName { get; set; }
    }
}
