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
    public class transferController : Controller
    {
        //serve is service
        private IService serve;

        public transferController(IService serv)
        {
            serve = serv;
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create([Bind("From, To, Content")] transfer transfer)
        {
            Message message = new Message();
            message.Content = transfer.Content;
            MessagesController controller = new MessagesController(serve);
            return controller.Create(transfer.To, transfer.From, message, false);
        }
    }

}

