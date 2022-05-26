using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppApi.Data;
using Microsoft.AspNetCore.SignalR;
using WebAppApi.Hubs;
using WebAppApi.Models;
using WebAppApi.Services;

namespace WebAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class transferController : Controller
    {
        //serve is service
        private IService serve;
        private readonly IHubContext<MyHub> hubContext;

        public transferController(IService serv, IHubContext<MyHub> _hubContext)
        {
            serve = serv;
            hubContext = _hubContext;
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("From, To, Content")] transfer transfer)
        {
            Message message = new Message();
            message.Content = transfer.Content;
            MessagesController controller = new MessagesController(serve);
            await hubContext.Clients.All.SendAsync("somthingAdded");
            return controller.Create(transfer.To, transfer.From, message, false);
        }
    }

}

