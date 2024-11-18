using BooksApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksApi
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {



        }

        //onModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = new Guid("00000000-0000-0000-0000-000000000001"), Name = "Sci-fi" },
                new Genre { Id = new Guid("00000000-0000-0000-0000-000000000002"), Name = "Fantasy" },
                new Genre { Id = new Guid("00000000-0000-0000-0000-000000000003"), Name = "Mystery" },
                new Genre { Id = new Guid("00000000-0000-0000-0000-000000000004"), Name = "Romance" },
                new Genre { Id = new Guid("00000000-0000-0000-0000-000000000005"), Name = "Horror" },
                new Genre { Id = new Guid("00000000-0000-0000-0000-000000000006"), Name = "Thriller" },
                new Genre { Id = new Guid("00000000-0000-0000-0000-000000000007"), Name = "Western" },
                new Genre { Id = new Guid("00000000-0000-0000-0000-000000000008"), Name = "Dystopian" },
                new Genre { Id = new Guid("00000000-0000-0000-0000-000000000009"), Name = "Memoir" },
                new Genre { Id = new Guid("00000000-0000-0000-0000-000000000010"), Name = "Biography" });

            modelBuilder.Entity<Author>().HasData(
                new Author { Id = new Guid("00000000-0000-0000-0000-000000000001"), FirstName = "Isaac", LastName = "Asimov", Country = "USA" },
                new Author { Id = new Guid("00000000-0000-0000-0000-000000000002"), FirstName = "Arthur", LastName = "Clarke", Country = "UK" },
                new Author { Id = new Guid("00000000-0000-0000-0000-000000000003"), FirstName = "Frank", LastName = "Herbert", Country = "USA" },
                new Author { Id = new Guid("00000000-0000-0000-0000-000000000004"), FirstName = "Philip", LastName = "Dick", Country = "USA" },
                new Author { Id = new Guid("00000000-0000-0000-0000-000000000005"), FirstName = "Ursula", LastName = "Le Guin", Country = "USA" },
                new Author { Id = new Guid("00000000-0000-0000-0000-000000000006"), FirstName = "Ray", LastName = "Bradbury", Country = "USA" },
                new Author { Id = new Guid("00000000-0000-0000-0000-000000000007"), FirstName = "H.G.", LastName = "Wells", Country = "UK" },
                new Author { Id = new Guid("00000000-0000-0000-0000-000000000008"), FirstName = "Robert", LastName = "Heinlein", Country = "USA" },
                new Author { Id = new Guid("00000000-0000-0000-0000-000000000009"), FirstName = "Margaret", LastName = "Atwood", Country = "Canada" },
                new Author { Id = new Guid("00000000-0000-0000-0000-000000000010"), FirstName = "Kim", LastName = "Robinson", Country = "USA" });

            modelBuilder.Entity<Book>().HasData(new Book
    {
        Id = new Guid("00000000-0000-0000-0000-000000000001"),
        Title = "Foundation",
        GenreId = new Guid("00000000-0000-0000-0000-000000000001"),
        Pages = 255,
        Year = 1951,
                CoverType = "Hardcover",
                ISBN = "978-0553293357"
    },
    new Book
    {
        Id = new Guid("00000000-0000-0000-0000-000000000002"),
        Title = "2001: A Space Odyssey",
        GenreId = new Guid("00000000-0000-0000-0000-000000000001"),
        Pages = 297,
        Year = 1968,
        CoverType = "Hardcover",
        ISBN = "978-0451457998"
    },
    new Book
    {
        Id = new Guid("00000000-0000-0000-0000-000000000003"),
        Title = "Dune",
        GenreId = new Guid("00000000-0000-0000-0000-000000000001"),
        Pages = 412,
        Year = 1965,
        CoverType = "Hardcover",
        ISBN = "978-0441172719"
    },
    new Book
    {
        Id = new Guid("00000000-0000-0000-0000-000000000004"),
        Title = "Do Androids Dream of Electric Sheep?",
        GenreId = new Guid("00000000-0000-0000-0000-000000000001"),
        Pages = 210,
        Year = 1968,
        CoverType = "Hardcover",
        ISBN = "978-0345404473"
    },
    new Book
    {
        Id = new Guid("00000000-0000-0000-0000-000000000005"),
        Title = "The Left Hand of Darkness",
        GenreId = new Guid("00000000-0000-0000-0000-000000000001"),
        Pages = 304,
        Year = 1969,
        CoverType = "Hardcover",
        ISBN = "978-0441478125"
    },
    new Book
    {
        Id = new Guid("00000000-0000-0000-0000-000000000006"),
        Title = "Fahrenheit 451",
        GenreId = new Guid("00000000-0000-0000-0000-000000000001"),
        Pages = 194,
        Year = 1953,
        CoverType = "Hardcover",
        ISBN = "978-1451673319"
    },
    new Book
    {
        Id = new Guid("00000000-0000-0000-0000-000000000007"),
        Title = "The War of the Worlds",
        GenreId = new Guid("00000000-0000-0000-0000-000000000001"),
        Pages = 192,
        Year = 1898,
        CoverType = "Hardcover",
        ISBN = "978-0451530653"
    },
    new Book
    {
        Id = new Guid("00000000-0000-0000-0000-000000000008"),
        Title = "Stranger in a Strange Land",
        GenreId = new Guid("00000000-0000-0000-0000-000000000001"),
        Pages = 408,
        Year = 1961,
        CoverType = "Hardcover",
        ISBN = "978-0441790340"
    },
    new Book
    {
        Id = new Guid("00000000-0000-0000-0000-000000000009"),
        Title = "The Handmaid's Tale",
        GenreId = new Guid("00000000-0000-0000-0000-000000000001"),
        Pages = 311,
        Year = 1985,
        CoverType = "Hardcover",
        ISBN = "978-0385490818"
    },
    new Book
    {
        Id = new Guid("00000000-0000-0000-0000-000000000010"),
        Title = "Red Mars",
        GenreId = new Guid("00000000-0000-0000-0000-000000000001"),
        Pages = 572,
        Year = 1993,
        CoverType = "Hardcover",
        ISBN = "978-0553560732"
    }
);

        }
    }

}
