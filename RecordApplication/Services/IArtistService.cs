using RecordApplication.Entities;

namespace RecordApplication.Services
{
    public interface IArtistService
    {
        Artist? AddArtistToDb(string artistName);
        Artist? CheckIfArtistExists(string artistName);
        Album ConvertInputToAlbum(AlbumInput albumInput);
    }
}