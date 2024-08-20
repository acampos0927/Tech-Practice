// public class Band
// {
//     public int BandId { get; set; }
//     public string Name { get; set; }
//     public string Genre { get; set; } = "Metal";
//     public DateTime FormationDate { get; set; }
//     public List<Album> Albums { get; set; } = new();
// }

// public class Album
// {
//     public int AlbumId { get; set; }
//     public string Title { get; set; }
//     public int BandId { get; set; }
//     public Band Band { get; set; }
//     public DateTime ReleaseDate { get; set; }
//     public List<Song> Songs { get; set; } = new();
// }

// public class Song
// {
//     public int SongId { get; set; }
//     public string Title { get; set; }
//     public int AlbumId { get; set; }
//     public Album Album { get; set; }
//     public TimeSpan Duration { get; set; }
// }

public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public string Department { get; set; }
    public DateTime HireDate { get; set; }
}

