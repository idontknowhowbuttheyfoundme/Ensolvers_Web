using Ensolvers_Core.Entities;

namespace Ensolvers_Infrastructure.Interface
{
    public interface INoteRepository
    {
        public Task<IEnumerable<Note>> GetAllNotes();
        public Task<IEnumerable<Note>> GetAllArchivedNotes();
        public Task<Note> PostNote(Note newNote);
        public Task<Note> EditNoteContent(Note changedNote);
        public Task<bool> ArchiveNote(Note noteToArchive);
        public Task<bool> UnArchiveNote(Note noteToUnArchive);
        public Task<bool> RemoveNote(Note noteToDelete);
    }
}
