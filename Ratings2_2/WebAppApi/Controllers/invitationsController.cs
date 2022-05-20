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
    public class invitationsController : Controller
    {
        //serve is service
        private IService serve;

        public invitationsController(IService serv)
        {
            serve = serv;
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create([Bind("From, To, Server")] invitation invitation)
        {
            Contact contact = new Contact();
            contact.Id = invitation.From;
            contact.Name = invitation.From;
            contact.Server = invitation.Server;
            ContactsController controller = new ContactsController(serve);
            return controller.Create(invitation.To, contact);
        }
    }



}
