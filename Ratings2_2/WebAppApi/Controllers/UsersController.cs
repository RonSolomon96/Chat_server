using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppApi.Data;
using WebAppApi.Models;
using WebAppApi.Services;

namespace WebAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        //serve is service
        private IService serve;

        public UsersController(IService serv)
        {
            serve = serv;
        }


        [HttpGet]
        public IActionResult GetUsers()
        {
            return new OkObjectResult(serve.GetAllUsers());
        }


        [HttpPost]
        //  [ValidateAntiForgeryToken]
        public IActionResult CreateUser([Bind("Username, Password, Nickname, Server")] User user)
        {
            if (serve.GetUser(user.UserName) == null)
            {
                if (ModelState.IsValid)
                {
                    serve.CreateUser(user.UserName, user.Password, user.Nickname, user.Server);
                    return new OkObjectResult(user.UserName);
                }
                return new NotFoundResult();
            }
            //user already exists
            return new BadRequestResult();
        }


        [HttpGet("{Username}")]
        public IActionResult Details(string Username)
        {
            if (Username == null || serve.GetAllUsers().Count == 0)
            {
                return new NotFoundResult();
            }
            User user = serve.GetUser(Username);
            if (user == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(user);
        }
    }
}
