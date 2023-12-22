using Application.DTO.Note;
using AutoMapper;
using Ensolvers_Core.Entities;

namespace Ensolvers_Application
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<DeleteNoteDTO, Note>().ReverseMap();
            CreateMap<GetNoteDTO, Note>().ReverseMap();
            CreateMap<NewNoteDTO, Note>().ReverseMap();
            CreateMap<NoteToggleArchiveDTO, Note>().ReverseMap();
            CreateMap<EditNoteDTO, Note>().ReverseMap();
        }
    }
}
