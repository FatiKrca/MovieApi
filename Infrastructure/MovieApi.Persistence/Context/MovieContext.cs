using Microsoft.EntityFrameworkCore;
using MovieApi.Domain.Entities;

namespace MovieApi.Persistence.Context
{
    // DbContext sınıfı, uygulamanızın veritabanı ile etkileşimini sağlar.
    public class MovieContext : DbContext
    {
        // Veritabanı bağlantısını yapılandırmak için OnConfiguring metodu kullanılır.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // SQL Server bağlantı dizesini belirler. Bu dize veritabanı bağlantısı için kullanılır.
            optionsBuilder.UseSqlServer("Server=EKSENIT;initial Catalog=ApiMovieDb;integrated Security=true; TrustServerCertificate=true");
        }

        // DbSet özellikleri, her biri bir veritabanı tablosunu temsil eder.
        // Aşağıdaki DbSet'ler ile ilgili tablolar üzerinde CRUD işlemleri yapılabilir.

        // Kategoriler tablosuna karşılık gelen DbSet
        public DbSet<Category> Categories { get; set; }

        // Cast (Oyuncu) tablosuna karşılık gelen DbSet
        public DbSet<Cast> Casts { get; set; }

        // Filmler tablosuna karşılık gelen DbSet
        public DbSet<Movie> Movies { get; set; }

        // Yorumlar tablosuna karşılık gelen DbSet
        public DbSet<Review> Reviews { get; set; }

        // Etiketler tablosuna karşılık gelen DbSet
        public DbSet<Tag> Tags { get; set; }
    }
}
