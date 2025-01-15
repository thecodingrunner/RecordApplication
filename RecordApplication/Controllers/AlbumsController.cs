using Microsoft.AspNetCore.Mvc;
using RecordApplication.Entities;
using RecordApplication.Models;
using RecordApplication.Services;

namespace RecordApplication.Controllers
{
    [Route("/")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumsService _albumsService;
        private readonly IArtistService _artistService;
        public AlbumsController(IAlbumsService albumsService, IArtistService artistService)
        {
            _albumsService = albumsService;
            _artistService = artistService;
        }

        [HttpGet]
        public IActionResult GetAlbums()
        {
            var albums = _albumsService.GetAllAlbums();
            if (albums == null || albums.Count == 0)
            {
                return BadRequest("Albums do not exist.");
            }
            return Ok(albums);
        }

        [HttpGet("/{id}")]
        public IActionResult GetAlbumById(int id)
        {
            var album = _albumsService.GetAlbumById(id);
            if (album == null) 
            {
                return BadRequest("Album does not exist.");
            }
            return Ok(album);
        }

        [HttpPost]
        public IActionResult PostAlbum(AlbumInput albumInput)
        {
            var album = ConvertInputToAlbum(albumInput);

            // Post album and set posted album
            var postedAlbum = album;
            try
            {
                postedAlbum = _albumsService.PostAlbum(album);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }

            // Return posted album
            return Ok(postedAlbum);
        }

        [HttpPut("/{id}")]
        public IActionResult PutAlbum(int id, AlbumInput albumInput) 
        {
            var album = ConvertInputToAlbum(albumInput);
            album.Id = id;
            Album updatedAlbum = _albumsService.UpdateAlbum(album);
            return Ok(updatedAlbum);
        }

        public Album ConvertInputToAlbum(AlbumInput albumInput)
        {
            // Check for artist and add if doesn't exist
            var artist = _artistService.CheckIfArtistExists(albumInput.ArtistName);
            if (artist == null)
            {
                artist = _artistService.AddArtistToDb(albumInput.ArtistName);
            }

            // Parse genre string to enum
            Genre parsedGenre;
            if (!Enum.TryParse(albumInput.Genre, out parsedGenre))
            {
                throw new ArgumentException("Genre is not a valid value.");
            }

            // Create new album using inputs
            Album album = new Album(albumInput.AlbumName, artist.Id, artist.Name, albumInput.ReleaseYear, albumInput.Units, parsedGenre, albumInput.Description);

            return album;
        }

    }
}
