
using RecordApplication.Entities;

namespace RecordApplication.Services
{
    public interface IAlbumsService
    {
        List<Album> GetAllAlbums();
        Album GetAlbumById(int id);
        Album PostAlbum(Album album);
    }
}