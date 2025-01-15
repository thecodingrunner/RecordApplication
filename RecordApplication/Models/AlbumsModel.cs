using Microsoft.EntityFrameworkCore;
using RecordApplication.Entities;

namespace RecordApplication.Models
{
    public class AlbumsModel : IAlbumsModel
    {
        private readonly AlbumDbContext _albumDbContext;

        public AlbumsModel(AlbumDbContext albumDbContext) 
        {
            _albumDbContext = albumDbContext;
        }

        public List<Album>? FindAlbums()
        {
            var albums = _albumDbContext.Albums.ToList();
            return albums;
        }

        public Album? FindAlbumById(int id)
        {
            var album = _albumDbContext.Albums.FirstOrDefault(a => a.Id == id);
            return album;
        }

        public Album PostAlbum(Album album)
        {
            try
            {
                _albumDbContext.Albums.Add(album);
                _albumDbContext.SaveChanges();
            } 
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return album;
        }

        public Album UpdateAlbum(Album album)
        {
            //try
            //{
            //    _albumDbContext.Albums.Update(album);
            //    _albumDbContext.SaveChanges();
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
            return album;
        }
    }
}
