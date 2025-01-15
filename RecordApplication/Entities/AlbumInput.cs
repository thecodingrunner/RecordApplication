namespace RecordApplication.Entities
{
    public class AlbumInput
    {
        public AlbumInput(string albumName, string artistName, int releaseYear, int units, string genre, string description)
        {
            AlbumName = albumName;
            ArtistName = artistName;
            ReleaseYear = releaseYear;
            Units = units;
            Genre = genre;
            Description = description;
        }

        public int Id { get; set; }
        public string AlbumName { get; set; }
        public string ArtistName { get; set; }
        public int ReleaseYear { get; set; }
        public int Units { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
    }
}
