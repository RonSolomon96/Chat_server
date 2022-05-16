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
        public IActionResult GetContacts()
        {
            return new OkObjectResult(serve.GetAllContacts()); ;
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
      //  [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Server")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                serve.CreateContact(contact.Id, contact.Name, contact.Server);
                return new OkObjectResult(contact.Id);
            }
            return new NotFoundResult();
        }


        // GET: Contacts/Details/5
        [HttpGet("{id}")]
        public IActionResult Details(string id)
        {
            if (id == null || serve.GetAllContacts().Count == 0)
            {
                return new NotFoundResult();
            }
            Contact contact = serve.GetContact(id);
            if (contact == null) {
                return new NotFoundResult();
            }
            return new OkObjectResult(contact);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, string Name, string Server)
        {
            serve.EditContact(id, Name, Server);
            var contact = serve.GetContact(id);
            if (contact == null) {
                return new NotFoundResult();
            }
            return new OkObjectResult(contact.Id);
        }
       
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (serve.GetAllContacts().Count == 0)
            {
                return new NotFoundResult();
            }
            Contact contact = serve.GetContact(id);
            if (contact == null)
            {
                return new NotFoundResult();
            }
            serve.DeleteContact(id);
            return  new OkObjectResult(id);
        }
        

    }
}
