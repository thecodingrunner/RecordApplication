
using RecordApplication.Entities;

namespace RecordApplication.Services
{
    public interface IAlbumsService
    {
        List<Album> GetAllAlbums();
        Album GetAlbumById(int id);
        Album PostAlbum(AlbumInput albumInput);
        Album UpdateAlbum(int id, AlbumInput albumInput);
        bool DeleteAlbum(int id);
        List<Album> GetAlbumsByArtist(string artistName);
        Album ConvertInputToAlbum(AlbumInput albumInput);
    }
}