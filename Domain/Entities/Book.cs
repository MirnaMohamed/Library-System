using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public Genre Genre { get; set; }
        [MaxLength(300)]
        public string? Description { get; set; }

        public bool IsAvailable { get; set; } = true;
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public virtual Author Author { get; }

        public virtual ICollection<BorrowingRecord> BorrowingRecords { get; } = new HashSet<BorrowingRecord>();

    }
}
