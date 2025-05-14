using AutoMapper;
using Business.Contracts;
using Business.DTOs;
using Business.Services.Contracts;
using Common.Exceptions;
using Library_System.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Library_System.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService authorService;
        private readonly IMapper mapper;

        public AuthorController(IAuthorService _authorService, IMapper mapper)
        {
            authorService = _authorService;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var authorsList = await authorService.GetAllAuthorsAsync();
            var authorViewModels = mapper.Map<List<GetAuthorViewModel>>(authorsList);

            return View(authorViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create( AddAuthorViewModel author)
        {
            try
            {
                AuthorDTO authorDTO = mapper.Map<AuthorDTO>(author);
                await authorService.CreateAuthorAsync(authorDTO);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(author);
            }

        }
        public async Task<IActionResult> Update(int id)
        {
            var author = await authorService.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            AddAuthorViewModel authorViewModel = mapper.Map<AddAuthorViewModel>(author);
            return View("Create", authorViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Update(AddAuthorViewModel author)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Update", author);
                }
                AuthorDTO authorDTO = mapper.Map<AuthorDTO>(author);
                await authorService.UpdateAuthorAsync(author.AuthorId, authorDTO);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { Type = ex.GetType().Name, ErrorMessage = ex.Message });

            }
        }
        

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await authorService.DeleteAuthorAsync(id);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View("Error", new ErrorViewModel{ Type= ex.GetType().Name, ErrorMessage = ex.Message });
            }
        }
        

        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var author = await authorService.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            var authorViewModel = mapper.Map<GetAuthorViewModel>(author);
            return View(authorViewModel);
        }

    }
}
