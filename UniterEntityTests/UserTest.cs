using Microsoft.EntityFrameworkCore;
using UniterEntity.Data;
using UniterEntity.Models;
using UniterEntity.Repositories;

namespace UniterEntityTests;

[TestClass]
public class UserTest : IDisposable
{
    private UniterDbContext DbContext { get; set; } = null!;

    private UserRepository? _userRepository;
    private UserRepository UserRepository => _userRepository ??= new UserRepository(DbContext);

    [TestInitialize]
    public void Initialize()
    {
        var options = new DbContextOptionsBuilder<UniterDbContext>()
            .UseSqlite("Filename=UniterTestDb.db")
            .Options;
        DbContext = new UniterDbContext(options);
        DbContext.Database.EnsureDeleted();
        DbContext.Database.EnsureCreated();
    }

    [TestMethod]
    public void TestSimpleRegister()
    {
        var users = UserRepository.GetAll();
        Assert.AreEqual(users.Count(), 0);

        var user = new User() { Name = "Éléanore Petit", Email = "eleanore.petit@mail.com" };

        user = UserRepository.Register(user);
        Assert.AreEqual(user.Email, "eleanore.petit@mail.com");

        users = UserRepository.GetAll();
        Assert.AreEqual(users.Count(), 1);
        Assert.AreEqual(users.First().Email, "eleanore.petit@mail.com");
    }

    [TestMethod]
    public void TestSameEmailRegister()
    {
        var user = new User() { Name = "Éléanore Petit", Email = "eleanore.petit@mail.com" };
        var user2 = new User() { Name = "Eleanore Petit", Email = "eleanore.petit@mail.com" };

        user = UserRepository.Register(user);
        Assert.AreEqual(user.Email, "eleanore.petit@mail.com");
        Assert.ThrowsException<DbUpdateException>(() => user2 = UserRepository.Register(user2));

        var users = UserRepository.GetAll();
        Assert.AreEqual(users.Count(), 1);
        Assert.AreEqual(users.First().Email, "eleanore.petit@mail.com");
    }

    public void Dispose()
    {
        DbContext.Database.EnsureDeleted();
        DbContext.Dispose();
    }
}