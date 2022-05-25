using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using WebAppApi.Data;
using WebAppApi.Hubs;
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
        private readonly IHubContext<MyHub> hubContext;

        public invitationsController(IService serv, IHubContext<MyHub> _hubContext)
        {
            serve = serv;
            hubContext = _hubContext ;

        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("From, To, Server")] invitation invitation)
        {
            Contact contact = new Contact();
            contact.Id = invitation.From;
            contact.Name = invitation.From;
            contact.Server = invitation.Server;
            ContactsController controller = new ContactsController(serve);
            await hubContext.Clients.All.SendAsync("somthingAdded");
            return controller.Create(invitation.To, contact);
        }
    }



}
