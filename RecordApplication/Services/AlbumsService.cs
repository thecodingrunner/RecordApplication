using RecordApplication.Entities;
using RecordApplication.Models;

namespace RecordApplication.Services
{
    public class AlbumsService : IAlbumsService
    {
        private readonly IAlbumsModel _albumsModel;

        public AlbumsService(IAlbumsModel albumsModel)
        {
            _albumsModel = albumsModel;
        }

        public List<Album>? GetAllAlbums()
        {
            return _albumsModel.FindAlbums();
        }

        public Album? GetAlbumById(int id)
        {
            return _albumsModel.FindAlbumById(id);
        }

        public Album PostAlbum(Album album)
        {
            return _albumsModel.PostAlbum(album);
        }
    }
}
