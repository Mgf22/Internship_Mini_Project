using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Mini_projeto_Book_Samsys.Data;

namespace Mini_projeto_Book_Samsys.Repositories.Unit_of_work
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly MiniProjectDBContext _context;

        protected GenericRepository(MiniProjectDBContext context)
        {
            _context = context;
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
