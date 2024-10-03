using Mini_projeto_Book_Samsys.Models.DTOs;
using Mini_projeto_Book_Samsys.Models;
using Mini_projeto_Book_Samsys.Helpers;

namespace Mini_projeto_Author_Samsys.Services
{
       public interface IAuthorService
        {
            Task<MessageHelper<IEnumerable<Author>>> GetAllAuthors();
            Task<MessageHelper<Author>> GetAuthorById(int id);
            Task<MessageHelper<Author>> AddAuthor(AuthorDTO author);
            Task<MessageHelper> DeleteAuthor(int id);
            Task<MessageHelper<Author>> UpdateAuthor(int id, AuthorDTO author);
        }
}
