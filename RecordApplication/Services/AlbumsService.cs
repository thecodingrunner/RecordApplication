using RecordApplication.Entities;
using RecordApplication.Models;

namespace RecordApplication.Services
{
    public class AlbumsService : IAlbumsService
    {
        private readonly IAlbumsModel _albumsModel;
        private readonly IArtistModel _artistModel;

        public AlbumsService(IAlbumsModel albumsModel, IArtistModel artistModel)
        {
            _albumsModel = albumsModel;
            _artistModel = artistModel;
        }

        public List<Album>? GetAllAlbums()
        {
            return _albumsModel.FindAlbums();
        }

        public Album? GetAlbumById(int id)
        {
            return _albumsModel.FindAlbumById(id);
        }

        public Album PostAlbum(AlbumInput albumInput)
        {
            // Convert input to album
            var convertedAlbum = ConvertInputToAlbum(albumInput);

            return _albumsModel.PostAlbum(convertedAlbum);
        }

        public Album UpdateAlbum(int id, AlbumInput albumInput)
        {
            // Convert input to album
            var convertedAlbum = ConvertInputToAlbum(albumInput);
            convertedAlbum.Id = id;

            return _albumsModel.UpdateAlbum(convertedAlbum);
        }

        public bool DeleteAlbum(int id)
        {
            return _albumsModel.DeleteAlbum(id);
        }

        public List<Album> GetAlbumsByArtist(string artistName)
        {
            return _albumsModel.GetAlbumsByArtist(artistName);
        }

        public Album ConvertInputToAlbum(AlbumInput albumInput)
        {
            // Check for artist and add if doesn't exist
            var artist = _artistModel.FindArtistByName(albumInput.ArtistName);
            if (artist == null)
            {
                artist = _artistModel.AddArtistToDb(albumInput.ArtistName);
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
