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
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        //serve is service
        private IService serve;

        public ContactsController(IService serv)
        {
            serve = serv;
        }


        // GET: Contacts
        [HttpGet]
        public IActionResult GetContacts(string User)
        {
            List<ContactClone> contacts = serve.GetAllContacts(User);
            if (contacts == null)
            {
                return NotFound();
            }
            return new OkObjectResult(contacts) ;
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //  [ValidateAntiForgeryToken]
        public IActionResult Create(string User, [Bind("Id,Name,Server")] Contact contact)
        {
            if (serve.GetUser(User) != null) {
                if (serve.GetContact(User, contact.Id) == null)
                {
                    if (ModelState.IsValid)
                    {
                        serve.CreateContact(User, contact.Id, contact.Name, contact.Server);
                        return  StatusCode(201);
                        
                    }
                    return new NotFoundResult();
                }
                return new BadRequestResult();
            }
            return new BadRequestResult();
        }
        


        // GET: Contacts/Details/5
        [HttpGet("{id}")]
        public IActionResult Details(string User, string id)
        {
            if (id == null || serve.GetAllContacts(User) == null || serve.GetAllContacts(User).Count == 0)
            {
                return new NotFoundResult();
            }
            ContactClone contact = serve.GetContact(User, id);
            ContactClone c = new ContactClone() ;
            c.Id = contact.Id;
            c.Name = contact.Name;
            c.Server = contact.Server;
            c.Last = contact.Last;
            c.Lastdate = contact.Lastdate;
            if (contact == null) {
                return new NotFoundResult();
            }
            return new OkObjectResult(c);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string User, string id, string Name, string Server)
        {
            serve.EditContact(User, id, Name, Server);
            var contact = serve.GetContact(User, id);
            if (contact == null) {
                return new NotFoundResult();
            }
            return StatusCode(204);
        }
       
        [HttpDelete("{id}")]
        public IActionResult Delete(string User, string id)
        {
            if (serve.GetAllContacts(User) == null || serve.GetAllContacts(User).Count == 0)
            {
                return new NotFoundResult();
            }
            ContactClone contact = serve.GetContact(User, id);
            if (contact == null)
            {
                return new NotFoundResult();
            }
            serve.DeleteContact(User, id);
            return StatusCode(204);
        }
        

    }
}
