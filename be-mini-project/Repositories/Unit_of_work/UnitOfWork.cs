using Mini_projeto_Book_Samsys.Data;

namespace Mini_projeto_Book_Samsys.Repositories.Unit_of_work
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MiniProjectDBContext _context;
        public IBookRepository Books { get; }

        public IAuthorRepository Authors { get; }

        public UnitOfWork(MiniProjectDBContext context, IBookRepository bookRepository, IAuthorRepository authorRepository)
        {  
            _context = context;
            Books = bookRepository;
            Authors = authorRepository;
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
