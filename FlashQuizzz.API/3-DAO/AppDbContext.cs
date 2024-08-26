using Microsoft.EntityFrameworkCore;
using FlashQuizzz.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FlashQuizzz.API.DAO;

public class AppDbContext : IdentityDbContext<User> {

    public AppDbContext() { }

    public AppDbContext(DbContextOptions options) : base(options ){ }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     if (!optionsBuilder.IsConfigured)
    //     {
    //         optionsBuilder.UseSqlServer("CONNECTION_STRING");
    //     }
    // }

    public DbSet<FlashCard> FlashCard { get; set; }
    public DbSet<FlashCardCategory> FlashCardCategory { get; set; }
    public DbSet<FlashCardAnswer> FlashCardAnswer { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            base.OnModelCreating(modelBuilder);

            // Seed flashcard categories
            modelBuilder.Entity<FlashCardCategory>().HasData(
                new FlashCardCategory { FlashCardCategoryID = 1, FlashCardCategoryName = "HTML", FlashCardCategoryStatus = true },
                new FlashCardCategory { FlashCardCategoryID = 2, FlashCardCategoryName = "CSS", FlashCardCategoryStatus = true },
                new FlashCardCategory { FlashCardCategoryID = 3, FlashCardCategoryName = "JS", FlashCardCategoryStatus = true }
            );

            // Configure the relationship
            modelBuilder.Entity<FlashCard>()
                .HasOne(f => f.User)
                .WithMany(u => u.FlashCards)
                .HasForeignKey(r => r.UserID);
    }
}