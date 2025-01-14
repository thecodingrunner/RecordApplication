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


    }
}
