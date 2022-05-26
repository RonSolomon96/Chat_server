using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppApi.Data;
using WebAppApi.Models;
using WebAppApi.Services;

namespace WebAppApi.Controllers
{
    [ApiController]
    [Route("api/Contacts/{User}/{id}/[controller]")]
    public class MessagesController : Controller
    {
        //serve is service
        private IService serve;

        public MessagesController(IService serv)
        {
            serve = serv;
        }


        [HttpGet]
        public IActionResult Get(string User, string id)
        {
            if(serve.GetContact(User, id) == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(serve.GetAllMessages(User, id));
        }

        [HttpPost]
        //  [ValidateAntiForgeryToken]
        public IActionResult Create(string User, string id, [Bind("Content")] Message message, bool ort = true)
        {

            ContactClone cont = serve.GetContact(User, id);
            if (cont == null)
            {
                return new NotFoundResult();
            }
            if (ModelState.IsValid)
            {
                serve.CreateMessage(User, id,ort, message.Content);
                cont.Last = message.Content;
                return StatusCode(201);

            } 
            return new NotFoundResult();
        }


        [HttpGet("{id2}")]
        public IActionResult Details(string User, string id, int id2)
        {
            if (serve.GetContact(User, id) == null)
            {
                return new NotFoundResult();
            }
            if (serve.GetAllMessages(User, id).Count == 0)
            {
                return new NotFoundResult();
            }
            Message message = serve.GetMessage(User, id, id2);
            if (message == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(message);
        }

        [HttpPut("{id2}")]
        public IActionResult Update(string User, string id, int id2, string Content)
        {
            if (serve.GetContact(User, id) == null)
            {
                return new NotFoundResult();
            }
            serve.EditMessage(User, id, id2, Content);
            var message = serve.GetMessage(User, id, id2);
            if (message == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(message.Id);
        }

        [HttpDelete("{id2}")]
        public IActionResult Delete(string User, string id, int id2)
        {
            if (serve.GetContact(User, id) == null)
            {
                return new NotFoundResult();
            }

            if (serve.GetAllMessages(User, id).Count == 0)
            {
                return new NotFoundResult();
            }
            Message message = serve.GetMessage(User, id, id2);
            if (message == null)
            {
                return new NotFoundResult();
            }
            serve.DeleteMessage(User, id, id2);
            return StatusCode(204);
        }
    }
}
