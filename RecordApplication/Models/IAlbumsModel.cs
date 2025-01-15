
using RecordApplication.Entities;

namespace RecordApplication.Models
{
    public interface IAlbumsModel
    {
        List<Album> FindAlbums();
        Album FindAlbumById(int id);
        Album PostAlbum(Album album);
        Album UpdateAlbum(Album album);
    }
}