using Song=Songs.Models.Entity.Songs;
using Songs.Models.dto; 
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Songs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        public static List<Song> songs = new List<Song>();
        public SongsController()
        {
            if (songs.Count == 0)
            {
                songs.Add(new Song()
                {
                    Id = Guid.NewGuid(),
                    Name = "Shape of You",
                    Artist = "Ed Sheeran",
                    Genre = "Pop",
                    Language = "English",
                    Duration = "4:35",
                    Credits = "Ed Sheeran"
                });
            }
        }

        // ✅ GET: api/songs
        [HttpGet]
        public IActionResult GetSongs()
        {
            return Ok(songs);
        }

        // ✅ GET: api/songs/{id}
        [HttpGet("{id}")]
        public IActionResult GetSongById(Guid id)
        {
            var song = songs.FirstOrDefault(s => s.Id == id);

            if (song == null)
            {
                return NotFound(new { message = "Song not found" });
            }

            return Ok(song);
        }

        // ✅ POST: api/songs
        [HttpPost]
        public IActionResult CreateSong([FromBody] Songs.Models.Entity.Songs song)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            song.Id = Guid.NewGuid();
            //song.CreatedAt = DateTime.UtcNow;

            songs.Add(song);

            return CreatedAtAction(nameof(GetSongById), new { id = song.Id }, song);
        }

        // ✅ PUT: api/songs/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateSong(Guid id, [FromBody] Songs.Models.Entity.Songs updatedSong)
        {
            var existingSong = songs.FirstOrDefault(s => s.Id == id);

            if (existingSong == null)
            {
                return NotFound(new { message = "Song not found" });
            }

            // Update fields
            existingSong.Name = updatedSong.Name;
            existingSong.Artist = updatedSong.Artist;
            existingSong.Genre = updatedSong.Genre;
            existingSong.Language = updatedSong.Language;
            existingSong.Duration = updatedSong.Duration;
            existingSong.Credits = updatedSong.Credits;

            return Ok(existingSong);
        }

        // ✅ DELETE: api/songs/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteSong(Guid id)
        {
            var song = songs.FirstOrDefault(s => s.Id == id);

            if (song == null)
            {
                return NotFound(new { message = "Song not found" });
            }

            songs.Remove(song);

            return Ok(new { message = "Song deleted successfully" });
        }

    }
}
