namespace Application.DTO.Note
{
    public class GetNoteDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateOnly LastEdited { get; set; }
    }
}
