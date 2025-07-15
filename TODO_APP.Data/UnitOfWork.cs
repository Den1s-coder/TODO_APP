using TODO_APP.Data.Repos.Interfaces;

namespace TODO_APP.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TodoDBContext _context;
        public INoteRepository Notes { get; private set; }
        public IUserRepository Users { get; private set; }

        public UnitOfWork(TodoDBContext context, INoteRepository notes, IUserRepository users)
        {
            _context = context;
            Notes = notes;
            Users = users;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}