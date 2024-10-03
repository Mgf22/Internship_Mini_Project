using Microsoft.EntityFrameworkCore;
using Mini_projeto_Book_Samsys.Data;
using Mini_projeto_Book_Samsys.Models;
using Mini_projeto_Book_Samsys.Repositories.Unit_of_work;

namespace Mini_projeto_Book_Samsys.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        private readonly MiniProjectDBContext _context;

        public AuthorRepository(MiniProjectDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Author>> GetMatchingAuthors(List<int> authorIds)
        {
            return await _context.Authors.Where(a => authorIds.Contains(a.Id)).ToListAsync();
        }
    }
}
