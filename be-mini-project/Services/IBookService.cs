using Mini_projeto_Book_Samsys.Helpers;
using Mini_projeto_Book_Samsys.Models;
using Mini_projeto_Book_Samsys.Models.DTOs;


namespace Mini_projeto_Book_Samsys.Services
{
    public interface IBookService
    {
        Task<MessageHelper<IEnumerable<Book>>> GetAllBooks(); 
        Task<MessageHelper<Book>> GetBookByISBN(string isbn);
        Task<MessageHelper<Book>> AddBook(BookDTO book);
        Task<MessageHelper> DeleteBook(string isbn);
        Task<MessageHelper<Book>> UpdateBook(BookDTO book);
        Task<MessageHelper> ActivateBook(string isbn);
    }
}
