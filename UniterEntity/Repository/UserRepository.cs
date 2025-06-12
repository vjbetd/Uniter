using Microsoft.EntityFrameworkCore;
using UniterEntity.Data;
using UniterEntity.Model;

namespace UniterEntity.Repository;

public class UserRepository(UniterDbContext context)
{
    protected DbSet<User> Table => context.Users; // context.Set<User>();

    public IEnumerable<User> GetAll()
    {
        return Table.ToList();
    }

    public User Register(User user)
    {
        var entity = Table.Add(user).Entity;
        context.SaveChanges();
        return entity;
    }
}

