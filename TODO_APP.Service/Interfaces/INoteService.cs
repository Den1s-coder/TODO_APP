using TODO_APP.Core.Model;
using TODO_APP.Service.DTO;

namespace TODO_APP.Service.Interfaces
{
    public interface INoteService
    {
        Task<Note> GetByIdAsync(int id);
        Task<IEnumerable<Note>> GetAllAsync();
        Task<IEnumerable<Note>> GetUserNotesAsync(Guid id);
        Task AddAsync(CreateNoteDto noteDto);
        void Update(UpdateNoteDto noteDto);
        void Delete(Note note);
    }
}