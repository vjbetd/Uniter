using UniterApp.Models;
using UniterEntity.Data;
using UniterEntityTests;

namespace UniterAppTests;

[TestClass]
public class UserControllerTest
{
    private static UniterWebApplicationFactory<Program> _factory = null!;

    private static HttpClient CreateClient() => _factory.CreateClient();

    private HttpClient? _client;
    private HttpClient Client => _client ??= CreateClient();

    [ClassInitialize]
    public static void AssemblyInitialize(TestContext _)
    {
        _factory = new UniterWebApplicationFactory<Program>();

        using var scope = _factory.Services.CreateScope();
        var scopedServices = scope.ServiceProvider;
        var db = scopedServices.GetRequiredService<UniterDbContext>();
        db.Database.EnsureCreated();
    }

    [ClassCleanup(ClassCleanupBehavior.EndOfClass)]
    public static void AssemblyCleanup()
    {
        _factory.Dispose();
    }

    [TestMethod]
    public async Task TestUserRegister()
    {
        HttpResponseMessage response;
        IEnumerable<UserModel>? users;

        response = await Client.GetAsync("/User/GetAll");
        response.EnsureSuccessStatusCode();

        users = await response.Content.ReadFromJsonAsync<IEnumerable<UserModel>>();
        Assert.AreEqual(users.Count(), 0);

        response = await Client.PostAsJsonAsync("/User/Register", new { Name = "Éléanore Petit", Email = "eleanore.petit@mail.com" });
        response.EnsureSuccessStatusCode();

        users = await Client.GetFromJsonAsync<IEnumerable<UserModel>>("/User/GetAll");
        Assert.AreEqual(users.Count(), 1);
        Assert.AreEqual(users.First().Name, "Éléanore Petit");
        Assert.AreEqual(users.First().Email, "eleanore.petit@mail.com");

        // Server should throw an error because of email unicity
        response = await Client.PostAsJsonAsync("/User/Register", new { Name = "Eleanore Petit", Email = "eleanore.petit@mail.com" });

        users = await Client.GetFromJsonAsync<IEnumerable<UserModel>>("/User/GetAll");
        Assert.AreEqual(users.Count(), 1);
    }
}