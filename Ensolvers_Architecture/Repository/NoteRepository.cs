using Ensolvers_Core.Entities;
using Ensolvers_Infrastructure.DataContext;
using Ensolvers_Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ensolvers_Infrastructure.Repository
{
    public class NoteRepository : INoteRepository
    {
        private readonly EnsolversDbContext _context;
        public NoteRepository(EnsolversDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Note>> GetAllNotes()
        {
            IEnumerable<Note> result;
            result = await _context.Notes.Where(p => p.IsArchived == false).ToListAsync();
            return result;
        }
        public async Task<IEnumerable<Note>> GetAllArchivedNotes()
        {
            IEnumerable<Note> result;
            result = await _context.Notes.Where(p => p.IsArchived == true).ToListAsync();
            return result;
        }
        public async Task<Note> PostNote(Note newNote)
        {
            try
            {
                await _context.Notes.AddAsync(newNote);
                _context.SaveChanges();
                return newNote;
            }
            catch
            {
                return null;
            }
        }
        public async Task<Note> EditNoteContent(Note changedNote)
        {
            try
            {
                Note noteToChange = await _context.Notes.FindAsync(changedNote.Id);
                noteToChange.Content = changedNote.Content;
                noteToChange.Title = changedNote.Title;
                _context.SaveChanges();
                return noteToChange;
            }
            catch
            {
                return null;
            }
        }
        public async Task<bool> ArchiveNote(Note noteToArchive)
        {
            try
            {
                noteToArchive.IsArchived = true;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> UnArchiveNote(Note noteToUnArchive)
        {
            try
            {
                noteToUnArchive.IsArchived = false;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> RemoveNote(Note noteToDelete)
        {
            try
            {
                _context.Notes.Remove(noteToDelete);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
