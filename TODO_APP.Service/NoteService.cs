using TODO_APP.Service.Interfaces;
using TODO_APP.Data.Repos.Interfaces;
using TODO_APP.Core.Model;

namespace TODO_APP.Service
{
    public class NoteService : INoteService
    {
        private readonly IUnitOfWork _uow;

        public NoteService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Note> GetByIdAsync(int id)
        {
            return await _uow.Notes.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Note>> GetAllAsync()
        {
            return await _uow.Notes.GetAllAsync();
        }

        public async Task AddAsync(Note note)
        {
            await _uow.Notes.AddAsync(note);
        }

        public void Update(Note note)
        {
            _uow.Notes.Update(note);
        }

        public void Delete(Note note)
        {
            _uow.Notes.Delete(note);
        }
    }
}