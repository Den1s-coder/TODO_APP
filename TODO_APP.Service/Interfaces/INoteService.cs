using TODO_APP.Core.Model;

namespace TODO_APP.Service.Interfaces
{
    public interface INoteService
    {
        Task<Note> GetByIdAsync(int id);
        Task<IEnumerable<Note>> GetAllAsync();
        Task AddAsync(Note note);
        void Update(Note note);
        void Delete(Note note);
    }
}