using Application.DTO.Note;
using Ensolvers_Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Ensolvers_Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;
        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _noteService.GetAllNotes();
            return Ok(result);
        }
        [HttpGet]
        [Route("GetArchived")]
        public async Task<IActionResult> GetAllArchived()
        {
            var result = await _noteService.GetAllArchivedNotes();
            return Ok(result);
        }
        [HttpPost]
        [Route("PostNew")]
        public async Task<IActionResult> PostNote(NewNoteDTO newNote)
        {
            var result = await _noteService.PostNote(newNote);
            return Ok(result);
        }
        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit(EditNoteDTO changedNote)
        {
            var result = await _noteService.EditNoteContent(changedNote);
            return Ok(result);
        }
        [HttpPut]
        [Route("Archive")]
        public async Task<IActionResult> Archive(NoteToggleArchiveDTO noteToArchive)
        {
            var result = await _noteService.ArchiveNote(noteToArchive);
            return Ok(result);
        }
        [HttpPut]
        [Route("UnArchive")]
        public async Task<IActionResult> UnArchive(NoteToggleArchiveDTO noteToUnArchive)
        {
            var result = await _noteService.UnArchiveNote(noteToUnArchive);
            return Ok(result);
        }
        [HttpDelete]
        [Route("Remove")]
        public async Task<IActionResult> Delete(DeleteNoteDTO noteToDelete)
        {
            var result = await _noteService.RemoveNote(noteToDelete);
            return Ok(result);
        }
    }
}
