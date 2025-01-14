using RecordApplication.Entities;

namespace RecordApplication.Models
{
    public interface IArtistModel
    {
        Artist? AddArtistToDb(string name);
        Artist? FindArtistByName(string name);
    }
}