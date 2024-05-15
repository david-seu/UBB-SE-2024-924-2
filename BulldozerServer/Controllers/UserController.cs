using BulldozerServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BulldozerServer.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
    }
}
