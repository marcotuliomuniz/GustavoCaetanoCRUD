using GustavoCaetanoCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace GustavoCaetanoCRUD.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}