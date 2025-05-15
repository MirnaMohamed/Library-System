using AutoMapper;
using Business.Contracts;
using Business.Services.Contracts;
using Common.Contracts;
using Domain.Entities;
using Library_System.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library_System.Controllers
{
    public class BorrowController : Controller
    {
        private readonly IBookService bookService;
        private readonly IBorrowService borrowService;
        private readonly IMapper mapper;

        public BorrowController(IBookService _bookService, IBorrowService _borrowService, IMapper _mapper)
        {
            this.bookService = _bookService;
            this.borrowService = _borrowService;
            mapper = _mapper;
        }
        public async Task<IActionResult> Index()
        {
            var books = await bookService.GetAllBooksAsync(); 
            var bookViewModels = mapper.Map<List<GetBookViewModel>>(books);
            return View(bookViewModels);
        }


        public async Task<IActionResult> RequestBorrow()
        {
            var books = await bookService.GetAvailableBooksAsync();
            ViewBag.Books = mapper.Map<List<GetBookViewModel>>(books);
            return View("Create");
        }
        [HttpPost]
        public async Task<IActionResult> RequestBorrow(BorrowingRecord borrowRecord)
        {
            await borrowService.BorrowBookAsync(borrowRecord.BookId, borrowRecord.BorrowDate);
            return RedirectToAction("BorrowList");
        }

        public async Task<IActionResult> BorrowList()
        {
            var records = await borrowService.GetAll();
            return View(records);
        }

        public async Task<IActionResult> SwitchAvailability(int id)
        {
            var book = await bookService.GetBookByIdAsync(id);
            book.IsAvailable = false;
            await bookService.UpdateBookAsync(id, book);

            return Json(true);
        }

        public async Task<IActionResult> ReturnBook()
        {
            var books = await bookService.GetBorrowedBooksAsync();
            ViewBag.Books = mapper.Map<List<GetBookViewModel>>(books);
            return View("Create");
        }
    }
}
