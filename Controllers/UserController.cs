using harry.Models;
using harry.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace harry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly userService _userService;

        public UserController(userService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<user>> Get() =>
            _userService.Get();


        [HttpPost]
        public ActionResult<user> Create(user user)
        {
            _userService.Create(user);

            return CreatedAtRoute("Getuser", new { id = user.Id.ToString(), name = user.name.ToString(), word = user.word.ToString() }, user);
        }

        
    }
}