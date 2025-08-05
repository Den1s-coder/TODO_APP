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

        public async Task<IEnumerable<Note>> GetUserNotesAsync(Guid id)
        {
            var User = await _userManager.FindByIdAsync(id.ToString());

            if (User == null) throw new ArgumentNullException(nameof(User));

            return await _uow.Notes.GetUserNotesAsync(id);
        }
    }
}