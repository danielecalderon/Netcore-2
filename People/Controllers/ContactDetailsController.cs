using Microsoft.AspNetCore.Mvc;
using People.Models;
using People.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Controllers
{
    [Route("api/ContactDetails")]
    [ApiController]   
    public class ContactDetailsController : Controller
    {
        private readonly IContactDetailsRepository _context;
        public ContactDetailsController(IContactDetailsRepository context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllContactDetails()
        {
           var contactList= _context.GetContactDetails();
            return Ok(contactList);
        }

        [HttpGet("{Id:int}",Name = "GetContactDetail")]
        public IActionResult GetContactDetail(int Id)
        {
            var contactDetail = _context.GetContactDetail(Id);
            if (contactDetail == null)
                return NotFound(); //404
            return Ok(contactDetail); //200
        }

        [HttpPost]
        public IActionResult CreateContactDetail(ContactDetail contactDetail)
        {
            if (contactDetail == null)
                return BadRequest(ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_context.CreateContactDetails(contactDetail))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the contact details");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetContactDetail", new { Id = contactDetail.Id }, contactDetail);
        }

        [HttpPut]
        public IActionResult UpdateContactDetail(int Id, ContactDetail contactDetail)
        {
            if (contactDetail == null || Id != contactDetail.Id)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_context.UpdateContactDetails(contactDetail))
            {

                ModelState.AddModelError("", $"Something went wrong when updating contact details");
                return StatusCode(500, ModelState);
            }

            return NoContent();//204
        }

        [HttpDelete]
        public IActionResult DeleteContactDetail(int Id)
        {
            if (!_context.ContactDetailsExists(Id))            
                return NotFound();            

            var contactDetailFromDb = _context.GetContactDetail(Id);
            if (contactDetailFromDb == null)
                return NotFound();

            if (!_context.DeleteContactDetails(contactDetailFromDb))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting contact details");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

    }
}
