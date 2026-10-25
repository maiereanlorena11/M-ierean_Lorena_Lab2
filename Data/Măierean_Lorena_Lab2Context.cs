using Microsoft.EntityFrameworkCore;

namespace Măierean_Lorena_Lab2.Data;

public class Măierean_Lorena_Lab2Context(DbContextOptions<Măierean_Lorena_Lab2Context> options) : DbContext(options)
{
    public DbSet<Măierean_Lorena_Lab2.Models.Book> Book { get; set; } = default!;
    public DbSet<Măierean_Lorena_Lab2.Models.Publisher> Publisher { get; set; } = default!;
    public DbSet<Măierean_Lorena_Lab2.Models.Author> Author { get; set; } = default!;
    public DbSet<Măierean_Lorena_Lab2.Models.Category> Category { get; set; } = default!;
}
