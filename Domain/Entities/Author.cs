
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    //[Index("Fullname", IsUnique = true)]
    //[Index("Email", IsUnique = true)]
    public class Author
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string FullName { get; set; }

        [Required, MaxLength(150)]
        public required string Email { get; set; }
        [MaxLength(200)]
        public string? Website { get; set; }
        [MaxLength(300)]
        public string? Biography { get; set; }

        public virtual ICollection<Book> Books { get; } = new HashSet<Book>();

   
    }
}
