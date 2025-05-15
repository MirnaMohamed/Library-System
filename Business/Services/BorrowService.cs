using AutoMapper;
using Business.Contracts;
using Business.Services.Contracts;
using Common.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementation
{
    public class BorrowService : IBorrowService
    {
        private readonly IBookService _bookService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BorrowService(IUnitOfWork unitOfWork, IBookService bookService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _bookService = bookService;
            _mapper = mapper;
        }
        public async Task BorrowBookAsync(int bookId, DateTime? borrowDate)
        {
            var book = await _unitOfWork.BooksRepository.GetByIdAsync(bookId);
            if(book != null)
            {
                book.IsAvailable = false;
                var borrowingRecord = new BorrowingRecord(bookId, borrowDate ?? DateTime.Now, null);
                await _unitOfWork.BorrowRepository.AddAsync(borrowingRecord);
                await _unitOfWork.SaveChangesAsync();
            }

        }

        public async Task<List<BorrowingRecord>> GetBorrowingRecordsByBookId(int bookId)
        {
            var borrowingRecords = await _unitOfWork.BorrowRepository.GetAllAsync();
            var filteredRecords = borrowingRecords.Where(record => record.BookId == bookId).ToList();
            return filteredRecords;
        }

        public async Task ReturnBookAsync(int bookId, DateTime? returnDate)
        {
            var book = await _unitOfWork.BooksRepository.GetByIdAsync(bookId);
            if (book != null)
            {
                book.IsAvailable = true;
                var lastBorrow = book.BorrowingRecords.Last().BorrowDate;
                var borrowingRecord = await _unitOfWork.BorrowRepository.Find(bookId,  lastBorrow);
                if(borrowingRecord != null)
                {
                    await _unitOfWork.BorrowRepository.UpdateAsync(borrowingRecord, bookId, lastBorrow);
                    await _unitOfWork.SaveChangesAsync();
                }
            }
        }
        public async Task<List<BorrowingRecord>> GetAll()
        {
            var borrowingRecords = await _unitOfWork.BorrowRepository.GetAllAsync();
            return borrowingRecords.ToList();
        }
    }
}
