using TODO_APP.Data.Repos.Interfaces;

namespace TODO_APP.Data.Repos.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        INoteRepository Notes { get; }
        IUserRepository Users { get; }
        Task<int> CompleteAsync();
    }
}