using Lab1.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext //dziedziczenie po EF framework
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) // konstruktor EF Core
        : base(options)
    {
    }

    public DbSet<Discount> Discounts { get; set; } // Deklaracja tabeli dla bazy głównej prze EF 
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) //konwersja enumów "builder"
    {
        modelBuilder.Entity<Discount>() //builder wybiera encje Discount
            .Property(d => d.Status) // wybieramy kolumne status po przez lambdę
            .HasConversion<string>(); //konwertuj na stringa (w innym wypadku były by cyfry odpowiadające kolejności enuma od 0 do 2)
    }
}