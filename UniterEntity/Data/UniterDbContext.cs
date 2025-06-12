using Microsoft.EntityFrameworkCore;
using UniterEntity.Models;

namespace UniterEntity.Data;

public class UniterDbContext(DbContextOptions<UniterDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}
