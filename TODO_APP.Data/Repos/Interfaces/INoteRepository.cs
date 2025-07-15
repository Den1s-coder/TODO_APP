using TODO_APP.Core.Model;

namespace TODO_APP.Data.Repos.Interfaces
{
    public interface INoteRepository
    {
        Task<Note> GetByIdAsync(int id);
        Task<IEnumerable<Note>> GetAllAsync();
        Task AddAsync(Note note);
        void Update(Note note);
        void Delete(Note note);
    }
}