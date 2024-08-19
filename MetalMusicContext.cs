using Microsoft.EntityFrameworkCore;

public class MetalMusicContext : DbContext
{
    public MetalMusicContext(DbContextOptions<MetalMusicContext> options) : base(options) { }

    public DbSet<Band> Bands { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Song> Songs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Band>().HasData(
            new Band { BandId = 1, Name = "Metallica", Genre = "Thrash Metal", FormationDate = new DateTime(1981, 10, 28) },
            new Band { BandId = 2, Name = "Iron Maiden", Genre = "Heavy Metal", FormationDate = new DateTime(1975, 12, 25) }
        );

        modelBuilder.Entity<Album>().HasData(
            new Album { AlbumId = 1, Title = "Master of Puppets", ReleaseDate = new DateTime(1986, 3, 3), BandId = 1 },
            new Album { AlbumId = 2, Title = "The Number of the Beast", ReleaseDate = new DateTime(1982, 3, 22), BandId = 2 }
        );

       modelBuilder.Entity<Song>().HasData(
    new Song { SongId = 1, Title = "Battery", Duration = TimeSpan.FromMinutes(5).Add(TimeSpan.FromSeconds(12)), AlbumId = 1 },
    new Song { SongId = 2, Title = "Hallowed Be Thy Name", Duration = TimeSpan.FromMinutes(7).Add(TimeSpan.FromSeconds(12)), AlbumId = 2 }
);

    }
}
