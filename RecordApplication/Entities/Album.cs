namespace RecordApplication.Entities
{
    public class Album
    {
        public Album(string albumName, int artistId, string artistName, int releaseYear, int units, Genre genre, string description)
        {
            AlbumName = albumName;
            ArtistId = artistId;
            ArtistName = artistName;
            ReleaseYear = releaseYear;
            Units = units;
            Genre = genre;
            Description = description;
        }

        public int Id { get; set; }
        public string AlbumName { get; set; }
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public int ReleaseYear { get; set; }
        public int Units { get; set; }
        public Genre Genre { get; set; }
        public string Description { get; set; }
    }
}
