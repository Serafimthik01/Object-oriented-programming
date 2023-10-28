namespace Laba3.Library
{
    public class Song
    {
        public ICollection<Album>? Album { get; set; }
        public int AlbumId {  get; set; }
        public Artist? Artist { get; set; }
        public int Id { get; set; }
        public string? NameSong { get; set; }
    }
}
