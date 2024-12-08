namespace Note.Data
{
    public class Note : Entity
    {
        public string? TextValue { get; set; }
        public int BookId { get; set; }
        public int ChapterNumber { get; set; }
        public int CharacterId { get; set; }
    }
}
