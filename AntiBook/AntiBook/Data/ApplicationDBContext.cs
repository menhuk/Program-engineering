using AntiBook.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AntiBook.Data
{
    public class ApplicationDBContext: IdentityDbContext<AppUser>
    {

        public class ApplicationDBContex : DbContext
        {
            public ApplicationDBContex(DbContextOptions dbContextOptions) :
                base(dbContextOptions)
            {

            }
            public DbSet<Books> Books { get; set; }
            public DbSet<Authors> Authors { get; set; }
            public DbSet<Bookhouse> Bookhouses { get; set; }
            public DbSet<Cities> Cities { get; set; }
            public DbSet<Coverages> Coverages { get; set; }
            public DbSet<Genres> Genres { get; set; }
            public DbSet<Languages> Languages { get; set; }
            public DbSet<Rent_log> Rent_Logs { get; set; }
            public DbSet<Users> Users { get; set; }
            public DbSet<AuthorBook> AuthorBooks { get; set; }
            protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);

                builder.Entity<AuthorBook>(x => x.HasKey(p => new { p.AuthorsId, p.BooksId }));
                
                builder.Entity<AuthorBook>()
                    .HasOne(u => u.Books)
                    .WithMany(u => u.AuthorBook)
                    .HasForeignKey(p => p.BooksId);
                
                builder.Entity<AuthorBook>()
                    .HasOne(u => u.Authors)
                    .WithMany(u => u.AuthorBook)
                    .HasForeignKey(p => p.AuthorsId);


                List<IdentityRole> roles = new List<IdentityRole>
                {
                    new IdentityRole
                    {
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    },
                    new IdentityRole
                    {
                        Name = "User",
                        NormalizedName = "USER"
                    }
                };
                builder.Entity<IdentityRole>().HasData(roles);
            }
        }
    }
}
