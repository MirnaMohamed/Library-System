using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public record BorrowingRecord(int BookId, DateTime BorrowDate, DateTime? ReturnDate)
    {

    }
}
