using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using UniterApp.Models;
using UniterEntity.Models;
using UniterEntity.Repositories;

namespace UniterApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(
            IUserRepository userRepository    
        ) {
            _userRepository = userRepository;
        }

        // GET: User/GetAll
        [HttpGet("GetAll")]
        [Produces(MediaTypeNames.Application.Json)]
        public IEnumerable<UserModel> GetAll()
        {
            return _userRepository.GetAll().Select(u => new UserModel { Name = u.Name, Email = u.Email });
        }

        // POST: User/Register
        [HttpPost("Register")]
        // [ValidateAntiForgeryToken]
        public ActionResult<UserModel> Register(UserModel user)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Invalid user");
            }
            var entity = _userRepository.Register(new User { Name = user.Name, Email = user.Email });
            return new UserModel { Name = entity.Name, Email = entity.Email };
        }
    }
}
