using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crm.core.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;
        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetContact")]
        public List<Contact> Get()
        {
            List<Contact> contacts = new List<Contact>();
            contacts.Add(new Contact { Id = 1, FirstName = "ceylan", LastName = "coskun" });
            contacts.Add(new Contact { Id = 1, FirstName = "ceren", LastName = "corbaci" });

            return contacts;
        }
    }

    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
