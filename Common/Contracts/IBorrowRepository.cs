using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts
{
    public interface IBorrowRepository : IRepository<BorrowingRecord>
    {
        Task<BorrowingRecord?> Find(int id, DateTime borrowDate);
    }
}
