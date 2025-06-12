using Microsoft.EntityFrameworkCore;
using UniterEntity.Model;

namespace UniterEntity.Data;

public class UniterDbContext(DbContextOptions<UniterDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}
