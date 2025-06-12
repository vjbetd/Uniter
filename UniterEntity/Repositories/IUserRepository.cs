using UniterEntity.Models;

namespace UniterEntity.Repositories;

public interface IUserRepository
{
    /// <summary>
    /// Gets all users.
    /// </summary>
    /// <returns>An enumerable of all users.</returns>
    public IEnumerable<User> GetAll();

    /// <summary>
    /// Registers a new user to the system.
    /// </summary>
    /// <param name="user">The new user to register.</param>
    /// <returns>The user entity registred.</returns>
    public User Register(User user);
}
