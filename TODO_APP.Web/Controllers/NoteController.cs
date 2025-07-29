using Microsoft.AspNetCore.Mvc;
using TODO_APP.Service.Interfaces;
using TODO_APP.Core.Model;
using TODO_APP.Web.DTO;
using System.Data;

namespace TODO_APP.Web.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var notes = await _noteService.GetAllAsync();
            return View(notes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var note = await _noteService.GetByIdAsync(id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateNoteDto
            {
                UserId = new Guid("11111111-1111-1111-1111-111111111111") // тимчасово
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNoteDto noteDto)
        {
            if (ModelState.IsValid)
            {
                var note = new Note
                {
                    Title = noteDto.Title,
                    Description = noteDto.Description,
                    UserId = noteDto.UserId,
                    CreatedAt = DateTime.UtcNow
                };
                await _noteService.AddAsync(note);
                return RedirectToAction(nameof(Index));
            }
            return View(noteDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var note = await _noteService.GetByIdAsync(id);
            if (note == null)
                return NotFound();

            return View(note);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var note = await _noteService.GetByIdAsync(id);
            if (note != null) _noteService.Delete(note);
            return RedirectToAction(nameof(Index));
        }
    }
}
