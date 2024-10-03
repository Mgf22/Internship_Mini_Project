using Microsoft.EntityFrameworkCore;
using Mini_projeto_Book_Samsys.Data;
using Mini_projeto_Book_Samsys.Models;
using Mini_projeto_Book_Samsys.Repositories.Unit_of_work;
using System.Data;

namespace Mini_projeto_Book_Samsys.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly MiniProjectDBContext _context;

        public BookRepository(MiniProjectDBContext context) : base(context) 
        {
            _context = context;
        }
        public async Task<Book> GetBookByISBN(string isbn)
        {
            return await _context.Books.FirstOrDefaultAsync(book => book.ISBN == isbn);
        }

        public async Task<List<Book>> GetMatchingBooks(List<int> bookIds)
        {
            return await _context.Books.Where(b => bookIds.Contains(b.Id)).ToListAsync();
        }
    }
}
