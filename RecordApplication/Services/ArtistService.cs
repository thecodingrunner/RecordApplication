using RecordApplication.Entities;
using RecordApplication.Models;

namespace RecordApplication.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistModel _artistModel;

        public ArtistService(IArtistModel artistModel)
        {
            _artistModel = artistModel;
        }

        public Artist? CheckIfArtistExists(string artistName)
        {
            return _artistModel.FindArtistByName(artistName);
        }

        public Artist? AddArtistToDb(string artistName)
        {
            return _artistModel.AddArtistToDb(artistName);
        }

        public Album ConvertInputToAlbum(AlbumInput albumInput)
        {
            // Check for artist and add if doesn't exist
            var artist = CheckIfArtistExists(albumInput.ArtistName);
            if (artist == null)
            {
                artist = AddArtistToDb(albumInput.ArtistName);
            }

            // Parse genre string to enum
            Genre parsedGenre;
            if (!Enum.TryParse(albumInput.Genre, out parsedGenre))
            {
                throw new ArgumentException("Genre is not a valid value.");
            }

            // Create new album using inputs
            Album album = new Album(albumInput.AlbumName, artist.Id, artist.Name, albumInput.ReleaseYear, albumInput.Units, parsedGenre, albumInput.Description);

            return album;
        }
    }
}
