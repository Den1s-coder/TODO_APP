using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO_APP.Service.DTO
{
    public class UpdateNoteDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
