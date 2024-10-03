using Mini_projeto_Book_Samsys.Models;
using Mini_projeto_Book_Samsys.Repositories.Unit_of_work;

namespace Mini_projeto_Book_Samsys.Repositories
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        Task<List<Author>> GetMatchingAuthors(List<int> auhtorIds);
    }
}
