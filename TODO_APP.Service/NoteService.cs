using TODO_APP.Service.Interfaces;
using TODO_APP.Data.Repos.Interfaces;
using TODO_APP.Core.Model;
using TODO_APP.Service.DTO;
using AutoMapper;

namespace TODO_APP.Service
{
    public class NoteService : INoteService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

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

        public async Task AddAsync(CreateNoteDto noteDto)
        {
            if (noteDto == null)
                throw new ArgumentNullException(nameof(noteDto));

            var note = _mapper.Map<Note>(noteDto);

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