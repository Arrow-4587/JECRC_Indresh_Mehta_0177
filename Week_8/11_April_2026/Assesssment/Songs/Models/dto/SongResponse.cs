namespace Songs.Models.dto
{
    public class SongResponse
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Artist { get; set; }
        public required string Genre { get; set; }
        public required string Language { get; set; }
        public required string Duration { get; set; }
    }
}
