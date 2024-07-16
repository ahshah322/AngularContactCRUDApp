using AngularContactCRUDApi.Data;
using AngularContactCRUDApi.DTOs;
using AngularContactCRUDApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularContactCRUDApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            this._context = context;
        }

        // GET: api/contact
        [HttpGet]
        public IActionResult GetAllContacts()
        {
            var contacts = _context.Contacts.ToList();
            return Ok(contacts);
        }

        // POST: api/contact
        [HttpPost]
        public IActionResult AddContacts(AddContactRequestDTO request)
        {
            var addContact = new Contact()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Favorite = request.Favorite,
            };

            _context.Contacts.Add(addContact);
            _context.SaveChanges();

            return Ok(addContact);
        }

        // DELETE: api/contact/1
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteContact(Guid id)
        {
            var contact = _context.Contacts.Find(id);

            if (contact is not null)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }

            return Ok();
        }
    }
}
