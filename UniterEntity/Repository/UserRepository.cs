using UniterEntity.Data;
using UniterEntity.Model;

namespace UniterEntity.Repository;

public class UserRepository(UniterDbContext context)
{
    public IEnumerable<User> GetAll()
    {
        throw new NotImplementedException();
    }

    public User Register(User user)
    {
        throw new NotImplementedException();
    }
}

