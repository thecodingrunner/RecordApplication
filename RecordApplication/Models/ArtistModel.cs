﻿using Microsoft.EntityFrameworkCore;
using RecordApplication.Entities;

namespace RecordApplication.Models
{
    public class ArtistModel : IArtistModel
    {
        private readonly AlbumDbContext _albumDbContext;

        public ArtistModel(AlbumDbContext albumDbContext)
        {
            _albumDbContext = albumDbContext;
        }

        public Artist? FindArtistByName(string name)
        {
            return _albumDbContext.Artists.FirstOrDefault(a => a.Name == name);
        }

        public Artist? AddArtistToDb(string name)
        {
            Artist artist = new Artist(name);
            _albumDbContext.Artists.Add(artist);
            return artist;
        }
    }
}
