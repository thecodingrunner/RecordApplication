
using RecordApplication.Entities;

namespace RecordApplication.Services
{
    public interface IAlbumsService
    {
        List<Album> GetAllAlbums();
        Album GetAlbumById(int id);
        Album PostAlbum(Album album);
        Album UpdateAlbum(Album album);
        bool DeleteAlbum(int id);
        List<Album> GetAlbumsByArtist(string artistName);
    }
}