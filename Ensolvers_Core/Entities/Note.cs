namespace Ensolvers_Core.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public bool IsArchived { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateOnly LastEdited { get; set; }
    }
}
