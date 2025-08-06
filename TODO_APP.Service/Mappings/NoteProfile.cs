using AutoMapper;
using TODO_APP.Core.Model;
using TODO_APP.Service.DTO;

namespace TODO_APP.Service.Mappings
{
    public class NoteProfile : Profile
    {
        public NoteProfile() 
        {
            CreateMap<CreateNoteDto,Note>();
            CreateMap<UpdateNoteDto,Note>();
        }
    }
}
