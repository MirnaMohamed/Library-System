using AutoMapper;
using Business.Contracts;
using Business.DTOs;
using Business.Services.Contracts;
using Common.Exceptions;
using Common.Filtration;
using Data;
using Domain.Enums;
using Library_System.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Services.DTOs;
using System.ComponentModel;

namespace Library_System.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        private readonly IAuthorService authorService;
        private readonly IMapper mapper;
        public BookController(IBookService _bookService, IAuthorService _authorService, IMapper _mapper)
        {
            bookService = _bookService;
            authorService = _authorService;
            mapper = _mapper;
        }
        public async Task<IActionResult> Index()
        {
            List<GetBookDTO> books = await bookService.GetAllBooksAsync();
            List<GetBookViewModel> bookViewModels = mapper.Map<List<GetBookViewModel>>(books);
            return View(bookViewModels);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Genres = Enum.GetValues<Genre>()
                .Cast<Genre>()
                .Select(d => new SelectListItem
                {
                    Text = d.ToString(), 
                    Value = ((int)d).ToString()
                }).ToList();
            List<GetAuthorDto> authors = await authorService.GetAllAuthorsAsync();
            ViewBag.Authors = mapper.Map<List<GetAuthorViewModel>>(authors);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddBookViewModel book)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Genres = Enum.GetValues<Genre>()
                .Cast<Genre>()
                .Select(d => new SelectListItem
                {
                    Text = d.ToString(),
                    Value = ((int)d).ToString()
                }).ToList();
                List<GetAuthorDto> authors = await authorService.GetAllAuthorsAsync();
                ViewBag.Authors = mapper.Map<List<GetAuthorViewModel>>(authors);
                return View(book);
            }
            AddBookDTO bookDTO = mapper.Map<AddBookDTO>(book);
            await bookService.CreateBookAsync(bookDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Genres = Enum.GetValues<Genre>()
                .Cast<Genre>()
                .Select(d => new SelectListItem
                {
                    Text = d.ToString(),
                    Value = ((int)d).ToString()
                }).ToList();
            List<GetAuthorDto> authors = await authorService.GetAllAuthorsAsync();
            ViewBag.Authors = mapper.Map<List<GetAuthorViewModel>>(authors);
            GetBookDTO? book = await bookService.GetBookByIdAsync(id);
            var bookViewModel = mapper.Map<AddBookViewModel>(book);
            return View("Create", bookViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AddBookViewModel bookViewModel)
        {
            var bookDto = mapper.Map<AddBookDTO>(bookViewModel);
            try
            {
                await bookService.UpdateBookAsync(bookViewModel.BookId, bookDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                ViewBag.Genres = Enum.GetValues<Genre>()
                .Cast<Genre>()
                .Select(d => new SelectListItem
                {
                    Text = d.ToString(),
                    Value = ((int)d).ToString()
                }).ToList();
                List<GetAuthorDto> authors = await authorService.GetAllAuthorsAsync();
                ViewBag.Authors = mapper.Map<List<GetAuthorViewModel>>(authors);
                return View("Create", bookViewModel);
            }

        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await bookService.DeleteBookAsync(id);
                TempData["success"] = "Book Deleted Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { Type= ex.GetType().Name, ErrorMessage = ex.Message });
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            GetBookDTO? book = await bookService.GetBookByIdAsync(id);
            if(book == null)
            {
                return NotFound();
            }
            var bookViewModel = mapper.Map<GetBookViewModel>(book);
            return PartialView("_BookDetailPartial", bookViewModel);
        }

        public async Task<IActionResult> FilterBooks(BookSearchCriteria searchCriteria)
        {
            return View();
        }
    }
}
