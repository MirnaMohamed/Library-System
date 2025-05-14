namespace Business.DTOs
{
    public class GetAuthorDto
    {
        public int AuthorId { get; set; }

        public required string FirstName { get; set; }
        public required string SecondName { get; set; }
        public required string ThirdName { get; set; }
        public required string LastName { get; set; }

        public required string UserEmail { get; set; }
        public string? PersonalWebsite { get; set; }
        public string? Biography { get; set; }

        public int NumBooks { get; set; }
        public virtual ICollection<GetBookDTO> Books { get; internal set; } = new HashSet<GetBookDTO>();
    }
}
