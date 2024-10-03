using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Mini_projeto_Book_Samsys.Data;
using Mini_projeto_Book_Samsys.Helpers;
using Mini_projeto_Book_Samsys.Models;
using Mini_projeto_Book_Samsys.Models.DTOs;
using Mini_projeto_Book_Samsys.Repositories;
using Mini_projeto_Book_Samsys.Repositories.Unit_of_work;

namespace Mini_projeto_Book_Samsys.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BookService (IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<MessageHelper<IEnumerable<Book>>> GetAllBooks()
        {
            MessageHelper<IEnumerable<Book>> response = new();
            IEnumerable<Book>  books = await _unitOfWork.Books.GetAll();
            if (books.IsNullOrEmpty()) {
                response.Success = true;
                response.Message = "List is empty";
                response.Obj = books;
                return response;
            }
            response.Success = true;
            response.Message = "List retrieved with success";
            response.Obj = books;
            return response;
        }

        public async Task<MessageHelper<Book>> GetBookByISBN(string isbn)
        {
            MessageHelper<Book> response = new();
            Book book = await _unitOfWork.Books.GetBookByISBN(isbn);
            if (book is null){
                response.Success = false;
                response.Message = "Book doesn't exist";
                response.Obj = book;
                return response;
            }
            response.Success = true;
            response.Message = "Book founded with success";
            response.Obj = book;
            return response;
        }

        public async Task<MessageHelper<Book>> AddBook(BookDTO bookDTO)
        {
            MessageHelper<Book> response = new();
            Book book = _mapper.Map<Book>(bookDTO);
            List<Author> authors = await _unitOfWork.Authors.GetMatchingAuthors(bookDTO.AuthorIds);
            if (authors is null)
            {
                response.Success = false;
                response.Message = "The authors required don't exist";
                return response;
            }
            foreach (Author author in authors)
            {
                book.Authors.Add(author);
            }
            await _unitOfWork.Books.Add(book);
            await _unitOfWork.Save();
            response.Success = true;
            response.Message = "Book created with success";
            response.Obj = book;
            return response;
        }

        public async Task<MessageHelper> DeleteBook(string isbn)
        {
            MessageHelper response = new();
            Book book = await _unitOfWork.Books.GetBookByISBN(isbn);
            if (book is null)
            {
                response.Success = false;
                response.Message = "Book doesn´t exist";
                return response;
            }
            bool task = book.DeleteBook();
            if (task == false)
            {
                response.Success = true;
                response.Message = "Book was already deleted";
                return response;
            }
            await _unitOfWork.Save();
            response.Success = true;
            response.Message = "Book deleted with success";
            return response;
        }

        public async Task<MessageHelper<Book>> UpdateBook(BookDTO bookDTO)
        {
            MessageHelper<Book> response = new();
            /*Author author = await _unitOfWork.Authors.GetById(bookDTO.AuthorId);
            if (author is null)
            {
                response.Success = false;
                response.Message = "Author doesn´t exist";
                return response;
            }*/
            Book book = _mapper.Map<Book>(bookDTO);
            Book bookToChange = await _unitOfWork.Books.GetBookByISBN(bookDTO.ISBN);
            if (bookToChange is null)
            {
                response.Success = false;
                response.Message = "Book doesn´t exist";
                response.Obj = bookToChange;

                return response;
            }
            List<Author> authors = await _unitOfWork.Authors.GetMatchingAuthors(bookDTO.AuthorIds);
            if (authors is null)
            {
                response.Success = false;
                response.Message = "The authors required don't exist";
                return response;
            }
            foreach (Author author in authors)
            {
                book.Authors.Add(author);
            }
            bookToChange.Update(book);
            await _unitOfWork.Save();
            response.Success = true;
            response.Message = "Book updated with success";
            response.Obj = bookToChange;
            return response;
        }

        public async Task<MessageHelper> ActivateBook(string isbn)
        {
            MessageHelper response = new();
            Book book = await _unitOfWork.Books.GetBookByISBN(isbn);
            if (book is null)
            {
                response.Success = false;
                response.Message = "Book doesn´t exist";
                return response;
            }
            bool task = book.ActivateBook();
            if (task == false)
            {
                response.Success = true;
                response.Message = "Book was already activated";
                return response;
            }
            await _unitOfWork.Save();
            response.Success = true;
            response.Message = "Book activated with success";
            return response;
        }
    }
}
