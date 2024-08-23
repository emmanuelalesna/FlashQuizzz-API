using Microsoft.EntityFrameworkCore;
using FlashQuizzz.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FlashQuizzz.API.DAO;

public class AppDbContext : IdentityDbContext<User> {

    public AppDbContext() { }

    public AppDbContext(DbContextOptions options) : base(options ){ }

    public DbSet<FlashCard> FlashCard { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            base.OnModelCreating(modelBuilder);

            // Configure the relationship
            modelBuilder.Entity<FlashCard>()
                .HasOne(f => f.User)
                .WithMany(u => u.FlashCards)
                .HasForeignKey(r => r.UserID);
    }
}