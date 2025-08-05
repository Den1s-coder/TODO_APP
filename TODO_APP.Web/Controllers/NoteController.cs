using Microsoft.AspNetCore.Mvc;
using TODO_APP.Service.Interfaces;
using TODO_APP.Core.Model;
using TODO_APP.Service.DTO;
using System.Data;
using TODO_APP.Service.Services;

namespace TODO_APP.Web.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteService _noteService;
        private readonly IAuthService _authService;

        public NoteController(INoteService noteService, IAuthService authService)
        {
            _noteService = noteService;
            _authService = authService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var currentUser = await _authService.GetCurrentUserAsync();

            var notes = await _noteService.GetUserNotesAsync(currentUser.Id);
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
        public async Task<IActionResult> Create()
        {
            var currentUser = await _authService.GetCurrentUserAsync();
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            return View(new CreateNoteDto
            {
                UserId = currentUser.Id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNoteDto noteDto)
        {
            if (!ModelState.IsValid)
                return View(noteDto);
            
            try
            {
                await _noteService.AddAsync(noteDto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
                return View(noteDto);
            }
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
