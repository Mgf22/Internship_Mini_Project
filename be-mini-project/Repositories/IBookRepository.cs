using Mini_projeto_Book_Samsys.Models;
using Mini_projeto_Book_Samsys.Repositories.Unit_of_work;

namespace Mini_projeto_Book_Samsys.Repositories
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<Book> GetBookByISBN(string isbn);
        Task<List<Book>> GetMatchingBooks(List<int> bookIds);
    }
}
