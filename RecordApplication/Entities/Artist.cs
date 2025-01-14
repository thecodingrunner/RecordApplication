namespace RecordApplication.Entities
{
    public class Artist
    {
        public Artist(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
