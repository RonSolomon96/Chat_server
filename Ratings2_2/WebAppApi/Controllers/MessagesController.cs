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
    [Route("api/Contacts/{id}/[controller]")]
    public class MessagesController : Controller
    {
        //serve is service
        private IService serve;

        public MessagesController(IService serv)
        {
            serve = serv;
        }


        [HttpGet]
        public IActionResult Get(string id)
        {
            if(serve.GetContact(id) == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(serve.GetAllMessages()); ;
        }

        [HttpPost]
        //  [ValidateAntiForgeryToken]
        public IActionResult Create(string id, [Bind("Content")] Message message)
        {
            if (serve.GetContact(id) == null)
            {
                return new NotFoundResult();
            }
            if (ModelState.IsValid)
            {
                serve.CreateMessage(message.Content);
                return new OkObjectResult(message.Id);
            }
            return new NotFoundResult();
        }


        [HttpGet("{id2}")]
        public IActionResult Details(string id, int id2)
        {
            if (serve.GetContact(id) == null)
            {
                return new NotFoundResult();
            }
            if (id2 == null || serve.GetAllMessages().Count == 0)
            {
                return new NotFoundResult();
            }
            Message message = serve.GetMessage(id2);
            if (message == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(message);
        }

        [HttpPut("{id2}")]
        public IActionResult Update(string id, int id2, string Content)
        {
            if (serve.GetContact(id) == null)
            {
                return new NotFoundResult();
            }
            serve.EditMessage(id2, Content);
            var message = serve.GetMessage(id2);
            if (message == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(message.Id);
        }

        [HttpDelete("{id2}")]
        public IActionResult Delete(string id, int id2)
        {
            if (serve.GetContact(id) == null)
            {
                return new NotFoundResult();
            }
            if (serve.GetAllMessages().Count == 0)
            {
                return new NotFoundResult();
            }
            Message message = serve.GetMessage(id2);
            if (message == null)
            {
                return new NotFoundResult();
            }
            serve.DeleteMessage(id2);
            return new OkObjectResult(id2);
        }


        private bool MessageExists(int id)
        {
          return serve.GetAllMessages().Any(e => e.Id == id);
        }
    }
}
