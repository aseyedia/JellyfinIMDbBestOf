using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MediaBrowser.Controller.Library;
using MediaBrowser.Model.Entities;

namespace IMDbBestOf
{
    [ApiController]
    [Route("api/[controller]")]
    public class EpisodePlaylistController : ControllerBase
    {
        private readonly ILibraryManager _libraryManager;

        public EpisodePlaylistController(ILibraryManager libraryManager)
        {
            _libraryManager = libraryManager;
        }

        /// <summary>
        /// Retrieves all episodes for a show, sorted by descending user ratings.
        /// </summary>
        /// <param name="showId">The ID of the show.</param>
        /// <returns>A JSON list of episodes ordered by rating.</returns>
        [HttpGet("{showId}")]
        public IActionResult GetRankedEpisodes(string showId)
        {
            // Validate and fetch the show item from the library.
            var show = _libraryManager.GetItem(new Guid(showId));
            if (show == null)
            {
                return NotFound("Show not found.");
            }

            // Retrieve episodes (adjust filtering as needed).
            var episodes = _libraryManager.GetChildren(show, recursive: true)
                .Where(e => e.UserData?.Rating != null)
                .OrderByDescending(e => e.UserData.Rating)
                .Select(e => new { e.Id, e.Name, Rating = e.UserData.Rating })
                .ToList();

            // Get configuration (assuming your Plugin class exposes it)
            var configuration = Plugin.Instance?.Configuration;
            string playlistName = configuration != null
                ? string.Format(configuration.PlaylistName, show.Name)
                : $"IMDb Best Of {show.Name}";

            // Optionally: Use playlistName to generate or update a playlist here

            return Ok(new { PlaylistName = playlistName, Episodes = episodes });
        }
    }
}
