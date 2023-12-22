using Application.DTO.Note;
using AutoMapper;
using Ensolvers_Application.Interface;
using Ensolvers_Core.Entities;
using Ensolvers_Infrastructure.Interface;

namespace Ensolvers_Application.Service
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;
        public NoteService(INoteRepository noteRepository, IMapper mapper)
        {
            _noteRepository = noteRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetNoteDTO>> GetAllNotes()
        {
            IEnumerable<Note> result;
            result = await _noteRepository.GetAllNotes();
            var dto = _mapper.Map<IEnumerable<GetNoteDTO>>(result);
            return dto;
        }
        public async Task<IEnumerable<GetNoteDTO>> GetAllArchivedNotes()
        {
            IEnumerable<Note> result;
            result = await _noteRepository.GetAllArchivedNotes();
            var dto = _mapper.Map<IEnumerable<GetNoteDTO>>(result);
            return dto;
        }
        public async Task<GetNoteDTO> PostNote(NewNoteDTO newNote)
        {
            var entity = _mapper.Map<Note>(newNote);
            var result = await _noteRepository.PostNote(entity);
            var dto = _mapper.Map<GetNoteDTO>(result);
            return dto;
        }
        public async Task<GetNoteDTO> EditNoteContent(EditNoteDTO changedNote)
        {
            var entity = _mapper.Map<Note>(changedNote);
            var result = await _noteRepository.EditNoteContent(entity);
            var dto = _mapper.Map<GetNoteDTO>(result);
            return dto;
        }
        public async Task<bool> ArchiveNote(NoteToggleArchiveDTO noteToArchive)
        {
            var entity = _mapper.Map<Note>(noteToArchive);
            var result = await _noteRepository.ArchiveNote(entity);
            return result;
        }
        public async Task<bool> UnArchiveNote(NoteToggleArchiveDTO noteToUnArchive)
        {
            var entity = _mapper.Map<Note>(noteToUnArchive);
            var result = await _noteRepository.UnArchiveNote(entity);
            return result;
        }
        public async Task<bool> RemoveNote(DeleteNoteDTO noteToDelete)
        {
            var entity = _mapper.Map<Note>(noteToDelete);
            var result = await _noteRepository.RemoveNote(entity);
            return result;
        }
    }
}
