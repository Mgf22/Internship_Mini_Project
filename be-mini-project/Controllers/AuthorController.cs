using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mini_projeto_Book_Samsys.Data;
using Mini_projeto_Book_Samsys.Helpers;
using Mini_projeto_Book_Samsys.Models.DTOs;
using Mini_projeto_Book_Samsys.Models;
using Mini_projeto_Author_Samsys.Services;
using Mini_projeto_Book_Samsys.Models;

namespace Mini_projeto_Author_Samsys.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly MiniProjectDBContext _context;
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        public AuthorController(MiniProjectDBContext context, IAuthorService service, IMapper mapper)
        {
            _authorService = service;
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all authors.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAllAuthors()
        {
            MessageHelper<IEnumerable<Author>> response = new();
            try
            {
                response = await _authorService.GetAllAuthors();
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
        /// Gets a specific author.
        /// </summary>
        /// <returns>
        /// Returns a author by its ISBN.
        /// </returns>
        [HttpGet("{id}")]
        [ActionName(nameof(GetAuthorById))]
        public async Task<ActionResult<Author>> GetAuthorById(int id)
        {
            MessageHelper<Author> response = new();
            try
            {
                response = await _authorService.GetAuthorById(id);

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
        /// Creates a author.
        /// </summary>
        /// <returns>A newly created author</returns>
        /// <response code="201">Returns the newly created author</response>
        /// <response code="404">If the author is null</response>

        [HttpPost]
        public async Task<IActionResult> AddAuthor(AuthorDTO authorDTO)
        {
            MessageHelper<Author> response = new();
            try
            {
                /*if (!ModelState.IsValid)
                {
                    throw new Exception();
                }*/

                response = await _authorService.AddAuthor(authorDTO);
                if (response.Success == false)
                {
                    return BadRequest(response);
                }
                return CreatedAtAction(nameof(GetAuthorById), new { id = response.Obj.Id }, response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Removes a author.
        /// </summary>
        /// <response code="200">Author deleted</response>
        /// <response code="404">If the author was not found</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            MessageHelper response = new();
            try
            {
                response = await _authorService.DeleteAuthor(id);

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
        /// Updates a author.
        /// </summary>
        /// <response code="200">Author updated</response>
        /// <response code="404">If the author is not found</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id,AuthorDTO author)
        {
            MessageHelper<Author> response = new();
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception();
                }

                response = await _authorService.UpdateAuthor(id,author);
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
