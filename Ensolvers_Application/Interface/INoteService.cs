using Application.DTO.Note;

namespace Ensolvers_Application.Interface
{
    public interface INoteService
    {
        public Task<IEnumerable<GetNoteDTO>> GetAllNotes();
        public Task<IEnumerable<GetNoteDTO>> GetAllArchivedNotes();
        public Task<GetNoteDTO> PostNote(NewNoteDTO newNote);
        public Task<GetNoteDTO> EditNoteContent(EditNoteDTO changedNote);
        public Task<bool> ArchiveNote(NoteToggleArchiveDTO noteToArchive);
        public Task<bool> UnArchiveNote(NoteToggleArchiveDTO noteToUnArchive);
        public Task<bool> RemoveNote(DeleteNoteDTO noteToDelete);
    }
}
