﻿using AutoMapper;
using Business.DTOs;
using Business.Services.Contracts;
using Common.Contracts;
using Common.Filtration;
using Domain.Entities;
using Services.DTOs;

namespace Business.Services.Implementation
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public BookService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateBookAsync(AddBookDTO bookDto)
        {
            Book book = _mapper.Map<Book>(bookDto);
            await _unitOfWork.BooksRepository.AddAsync(book);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            await _unitOfWork.BooksRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public Task<List<GetBookDTO>> FilterBooksAsync(BookSearchCriteria searchCriteria)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetBookDTO>> GetAllBooksAsync()
        {
            IQueryable<Book> books = await _unitOfWork.BooksRepository.GetAllAsync();
            List<GetBookDTO> bookDtos = new List<GetBookDTO>();
            foreach (var book in books)
            {
                GetBookDTO bookDto = _mapper.Map<GetBookDTO>(book);
                bookDtos.Add(bookDto);
            }
            return bookDtos;
        }

        public async Task<List<GetBookDTO>> GetAvailableBooksAsync()
        {
            IQueryable<Book> books = await _unitOfWork.BooksRepository.GetAllAsync();
            books = books.Where(book => book.IsAvailable == true);
            return _mapper.Map<List<GetBookDTO>>(books.ToList());
        }

        public async Task<List<GetBookDTO>> GetBorrowedBooksAsync()
        {
            IQueryable<Book> books = await _unitOfWork.BooksRepository.GetAllAsync();
            books = books.Where(book => book.IsAvailable == false);
            return _mapper.Map<List<GetBookDTO>>(books.ToList());
        }

        public async Task<GetBookDTO?> GetBookByIdAsync(int id)
        {
            Book? book = await _unitOfWork.BooksRepository.GetByIdAsync(id);
            GetBookDTO? bookDTO = _mapper.Map<GetBookDTO>(book);
            return bookDTO;
        }


        public async Task UpdateBookAsync(int id, AddBookDTO book)
        {
            Book exisitingBook = _mapper.Map<Book>(book);
            await _unitOfWork.BooksRepository.UpdateAsync(exisitingBook, id);

            await _unitOfWork.SaveChangesAsync();

        }
    }
}
