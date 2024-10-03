namespace Mini_projeto_Book_Samsys.Repositories.Unit_of_work
{
    public interface IUnitOfWork
    {
        IBookRepository Books { get; }

        IAuthorRepository Authors { get; }

        Task<int> Save();
    }
}
