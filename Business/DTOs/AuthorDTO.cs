using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class AuthorDTO
    {
        public required string FirstName { get; set; }
        public required string SecondName { get; set; }
        public required string ThirdName { get; set; }
        public required string LastName { get; set; }
        public required string UserEmail { get; set; }
        public string? PersonalWebsite { get; set; }
        public string? Biography { get; set; }
    }
}
