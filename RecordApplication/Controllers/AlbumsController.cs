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
            var album = _artistService.ConvertInputToAlbum(albumInput);

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
            var album = _artistService.ConvertInputToAlbum(albumInput);
            album.Id = id;
            Album updatedAlbum = _albumsService.UpdateAlbum(album);
            return Ok(updatedAlbum);
        }

        [HttpDelete("/{id}")]
        public IActionResult DeleteAlbum(int id)
        {
            bool resultSuccessfully = _albumsService.DeleteAlbum(id);
            if (resultSuccessfully)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("/{artist}")]
        public IActionResult GetAlbumsByArtist(string artistName)
        {
            var albumsList = _albumsService.GetAlbumsByArtist(artistName);
            return Ok(albumsList);
        }
    }
}
