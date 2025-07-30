
namespace TODO_APP.Service.DTO
{
    public class CreateNoteDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
    }
}