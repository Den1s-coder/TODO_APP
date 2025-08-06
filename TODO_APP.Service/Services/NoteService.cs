using TODO_APP.Service.Interfaces;
using TODO_APP.Data.Repos.Interfaces;
using TODO_APP.Core.Model;
using TODO_APP.Service.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace TODO_APP.Service
{
    public class NoteService : INoteService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public NoteService(IUnitOfWork uow, IMapper mapper, UserManager<User> userManager)
        {
            _uow = uow;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Note> GetByIdAsync(int id)
        {
            return await _uow.Notes.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Note>> GetAllAsync()
        {
            return await _uow.Notes.GetAllAsync();
        }

        public async Task AddAsync(CreateNoteDto CreateNoteDto)
        {
            if (CreateNoteDto == null)
                throw new ArgumentNullException(nameof(CreateNoteDto));

            var note = _mapper.Map<Note>(CreateNoteDto);

            await _uow.Notes.AddAsync(note);
        }

        public async Task Update(UpdateNoteDto UpdateNoteDto)
        {
            if (UpdateNoteDto == null)
                throw new ArgumentNullException(nameof(UpdateNoteDto));

            var note = _mapper.Map<Note>(UpdateNoteDto);

            await _uow.Notes.Update(note);
        }

        public async Task Delete(Note note)
        {
            await _uow.Notes.Delete(note);
        }

        public async Task<IEnumerable<Note>> GetUserNotesAsync(Guid id)
        {
            var User = await _userManager.FindByIdAsync(id.ToString());

            if (User == null) throw new ArgumentNullException(nameof(User));

            return await _uow.Notes.GetUserNotesAsync(id);
        }
    }
}