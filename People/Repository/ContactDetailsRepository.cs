using People.Data;
using People.Models;
using People.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Repository
{
    public class ContactDetailsRepository : IContactDetailsRepository
    {
        private readonly ApplicationDbContext _context;
        public ContactDetailsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
             

        public ContactDetail GetContactDetail(int Id)
        {
           return _context.ContactDetails.FirstOrDefault(c => c.Id == Id);
        }

        public ICollection<ContactDetail> GetContactDetails()
        {
            return _context.ContactDetails.ToList();
        }

        public bool ContactDetailsExists(int Id)
        {
            return _context.ContactDetails.Any(n => n.Id == Id);
        }

        public bool CreateContactDetails(ContactDetail contactDetail)
        {
            _context.ContactDetails.Add(contactDetail);
            return Save();
        }
      
        public bool UpdateContactDetails(ContactDetail contactDetail)
        {
            _context.ContactDetails.Update(contactDetail);
            return Save();                
        }

        public bool DeleteContactDetails(ContactDetail contactDetail)
        {
            _context.ContactDetails.Remove(contactDetail);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() == 1 ? true : false;
        }
    }
}
