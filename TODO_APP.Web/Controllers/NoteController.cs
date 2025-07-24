using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TODO_APP.Service.Interfaces;

namespace TODO_APP.Web.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

    }
}
