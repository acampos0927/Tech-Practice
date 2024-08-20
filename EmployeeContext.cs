// using Microsoft.EntityFrameworkCore;

// public class MetalMusicContext : DbContext
// {
//     public MetalMusicContext(DbContextOptions<MetalMusicContext> options) : base(options) { }

//     public DbSet<Band> Bands { get; set; }
//     public DbSet<Album> Albums { get; set; }
//     public DbSet<Song> Songs { get; set; }

//     protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         modelBuilder.Entity<Band>().HasData(
//             new Band { BandId = 1, Name = "Metallica", Genre = "Thrash Metal", FormationDate = new DateTime(1981, 10, 28) },
//             new Band { BandId = 2, Name = "Iron Maiden", Genre = "Heavy Metal", FormationDate = new DateTime(1975, 12, 25) }
//         );

//         modelBuilder.Entity<Album>().HasData(
//             new Album { AlbumId = 1, Title = "Master of Puppets", ReleaseDate = new DateTime(1986, 3, 3), BandId = 1 },
//             new Album { AlbumId = 2, Title = "The Number of the Beast", ReleaseDate = new DateTime(1982, 3, 22), BandId = 2 }
//         );

//        modelBuilder.Entity<Song>().HasData(
//     new Song { SongId = 1, Title = "Battery", Duration = TimeSpan.FromMinutes(5).Add(TimeSpan.FromSeconds(12)), AlbumId = 1 },
//     new Song { SongId = 2, Title = "Hallowed Be Thy Name", Duration = TimeSpan.FromMinutes(7).Add(TimeSpan.FromSeconds(12)), AlbumId = 2 }
// );

//     }
// }

using Microsoft.EntityFrameworkCore;

public class EmployeeContext : DbContext
{
    public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<EmployeeID> EmployeeIDs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasData(
            new Employee { EmployeeId = 1, Name = "John Doe", Position = "Developer", Department = "Engineering", HireDate = new DateTime(2020, 1, 15) },
            new Employee { EmployeeId = 2, Name = "Jane Smith", Position = "Manager", Department = "Sales", HireDate = new DateTime(2019, 6, 30) }
        );

        modelBuilder.Entity<Department>().HasData(
            new Department { DepartmentId = 1, Name = "Engineering" },
            new Department { DepartmentId = 2, Name = "Sales" }
        );

        modelBuilder.Entity<EmployeeID>().HasData(
            new EmployeeID { EmployeeIDId = 1, IDNumber = "ID123456", IssueDate = new DateTime(2020, 1, 15), EmployeeId = 1 },
            new EmployeeID { EmployeeIDId = 2, IDNumber = "ID789101", IssueDate = new DateTime(2019, 6, 30), EmployeeId = 2 }
        );
    }
}
