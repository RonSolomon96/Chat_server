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
        private IContactsService serve;

        public ContactsController(IContactsService serv)
        {
            serve = serv;
        }


        // GET: Contacts
        [HttpGet]
        public IActionResult GetContacts()
        {
            return new OkObjectResult(serve.GetAll()); ;
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
                serve.Create(contact.Id, contact.Name, contact.Server);
                return new OkObjectResult(contact.Id);
            }
            return new NotFoundResult();
        }


        // GET: Contacts/Details/5
        [HttpGet("{id}")]
        public IActionResult Details(string id)
        {
            if (id == null || serve.GetAll().Count == 0)
            {
                return new NotFoundResult();
            }
            Contact contact = serve.Get(id);
            if (contact == null) {
                return new NotFoundResult();
            }
            return new OkObjectResult(contact);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, string Name, string Server)
        {
            serve.Edit(id, Name, Server);
            var contact = serve.Get(id);
            if (contact == null) {
                return new NotFoundResult();
            }
            return new OkObjectResult(contact.Id);
        }
       
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (serve.GetAll().Count == 0)
            {
                return new NotFoundResult();
            }
            Contact contact = serve.Get(id);
            if (contact == null)
            {
                return new NotFoundResult();
            }
            serve.Delete(id);
            return  new OkObjectResult(id);
        }
        /*
        

        // GET: Contacts/Create
        public IActionResult Create()
        {
            return View();
        }

       

        // GET: Contacts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Contact == null)
            {
                return NotFound();
            }

            var contact = await _context.Contact.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Server,Last,Lastdate")] Contact contact)
        {
            if (id != contact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Contact == null)
            {
                return NotFound();
            }

            var contact = await _context.Contact
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        

        private bool ContactExists(string id)
        {
          return (_context.Contact?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        */

    }
}
