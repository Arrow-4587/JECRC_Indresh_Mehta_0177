using System.ComponentModel.DataAnnotations;
namespace Songs.Models.dto
{
    public class CreateSongs
    {
        [Required]
        public required string Name { get; set; }
        public required string Artist { get; set; }
        public required string Genre { get; set; }
        public required string Language { get; set; }
        public required string Duration { get; set; }

        public required string Credits { get; set; }
    }
}
