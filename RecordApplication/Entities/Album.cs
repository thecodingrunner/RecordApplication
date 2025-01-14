namespace RecordApplication.Entities
{
    public class Album
    {
        public Album(string albumName, int artistId, Artist artist, int releaseYear, int units, Genre genre, string description)
        {
            AlbumName = albumName;
            ArtistId = artistId;
            Artist = artist;
            ReleaseYear = releaseYear;
            Units = units;
            Genre = genre;
            Description = description;
        }

        public int Id { get; set; }
        public string AlbumName { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int ReleaseYear { get; set; }
        public int Units { get; set; }
        public Genre Genre { get; set; }
        public string Description { get; set; }
    }
}
