﻿using Microsoft.AspNetCore.Mvc;
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
            Artist artist = _artistService.CheckIfArtistExists(albumInput.ArtistName);
            if (artist == null)
            {
                artist = _artistService.AddArtistToDb(albumInput.ArtistName);
            }

            Album album = new Album(albumInput.AlbumName, artist.Id, artist, albumInput.ReleaseYear, albumInput.Units, albumInput.Genre, albumInput.Description);

            var postedAlbum = _albumsService.PostAlbum(album);
            if (postedAlbum == null)
            {
                return BadRequest("Could not post album");
            }
            return Ok(postedAlbum);
        }


    }
}
