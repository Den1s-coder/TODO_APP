using TODO_APP.Core.Model;
using TODO_APP.Data.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TODO_APP.Data.Repos
{
    public class NoteRepository : INoteRepository
    {
        private readonly TodoDBContext _context;

        public NoteRepository(TodoDBContext context)
        {
            _context = context;
        }

        public async Task<Note?> GetByIdAsync(int id)
        {
            return await _context.Notes.FindAsync(id) ?? throw new Exception("Note not found");
        }

        public async Task<IEnumerable<Note>> GetAllAsync()
        {
            return await _context.Notes.ToListAsync();
        }

        public async Task AddAsync(Note note)
        {
            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync();
        }

        public void Update(Note note)
        {
            _context.Notes.Update(note);
        }

        public void Delete(Note note)
        {
            _context.Notes.Remove(note);
        }
    }
}
