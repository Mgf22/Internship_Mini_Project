using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mini_projeto_Book_Samsys.Data;
using Mini_projeto_Book_Samsys.Mappers;
using Mini_projeto_Book_Samsys.Models;
using Mini_projeto_Book_Samsys.Services;
using AutoMapper;
using Mini_projeto_Book_Samsys.Models.DTOs;
using Mini_projeto_Book_Samsys.Helpers;
using Azure;
using System.Runtime.InteropServices;
using Mini_projeto_Book_Samsys.Models.Validators;

namespace Mini_projeto_Book_Samsys.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly MiniProjectDBContext _context;
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public BookController(MiniProjectDBContext context, IBookService service, IMapper mapper) {
            _bookService = service;
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all books.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
        {
            MessageHelper<IEnumerable<Book>> response = new();
            try
            {
                response = await _bookService.GetAllBooks();
                if (response.Success == false) {
                    return NotFound(response);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        /// <summary>
        /// Gets a specific book.
        /// </summary>
        /// <returns>
        /// Returns a book by its ISBN.
        /// </returns>
        [HttpGet("{isbn}")]
        public async Task<ActionResult<Book>> GetBookByISBN(string isbn)
        {
            MessageHelper<Book> response = new();
            try
            {
                response = await _bookService.GetBookByISBN(isbn);

                if (response.Success == false)
                {
                    return NotFound(response);
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        /// <summary>
        /// Creates a book.
        /// </summary>
        /// <returns>A newly created book</returns>
        /// <response code="201">Returns the newly created book</response>
        /// <response code="404">If the book is null</response>

        [HttpPost]
        public async Task<IActionResult> AddBook(BookDTO bookDTO)
        {
            MessageHelper<Book> response = new();
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception();
                }

                response = await _bookService.AddBook(bookDTO);
                if (response.Success == false)
                {
                    return BadRequest(response);
                }
                return CreatedAtAction(nameof(GetBookByISBN), new { isbn = response.Obj.ISBN }, response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        /// <summary>
        /// Removes a book.
        /// </summary>
        /// <response code="200">Book deleted</response>
        /// <response code="404">If the book was not found</response>
        [HttpDelete("{isbn}")]
        public async Task<IActionResult> DeleteBook(string isbn)
        {
            MessageHelper response = new();
            try
            {
                response = await _bookService.DeleteBook(isbn);

                if (response.Success == false)
                {
                    return NotFound(response);
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }


        /// <summary>
        /// Updates a book.
        /// </summary>
        /// <response code="200">Book updated</response>
        /// <response code="404">If the book is not found</response>
        [HttpPut]
        public async Task<IActionResult> UpdateBook(BookDTO book)
        {
            MessageHelper<Book> response = new();
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception();
                }

                response = await _bookService.UpdateBook(book);
                if (response.Success == false)
                {
                    return NotFound(response);
                }

                return Ok(response);
            }
            catch (Exception ex) {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        /// <summary>
        /// Activates a book.
        /// </summary>
        /// <response code="200">Book updated</response>
        /// <response code="404">If the book is not found</response>
        [HttpPatch("{isbn}")]
        public async Task<IActionResult> ActivateBook(string isbn)
        {
            MessageHelper response = new();
            try
            {
                response = await _bookService.ActivateBook(isbn);
                if (response.Success == false)
                {
                    return NotFound(response);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }


    }
}
