using System.Diagnostics;
using AutoMapper;
using Business.Services.Contracts;
using Library_System.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService bookService;
        private readonly IMapper mapper;

        public HomeController(IBookService _bookService, IMapper _mapper)
        {
            this.bookService = _bookService;
            mapper = _mapper;
        }

        public async Task<IActionResult> Index()
        {
            var books = await bookService.GetAllBooksAsync();
            var booksView = mapper.Map<List<GetBookViewModel>>(books);
            return View(booksView);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { ErrorMessage = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
