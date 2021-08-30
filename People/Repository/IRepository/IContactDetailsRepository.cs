using People.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Repository.IRepository
{
    public interface IContactDetailsRepository
    {
        ICollection<ContactDetail> GetContactDetails();
        ContactDetail GetContactDetail(int Id);
        bool ContactDetailsExists(int Id);

        bool CreateContactDetails(ContactDetail contactDetail);
        bool UpdateContactDetails(ContactDetail contactDetail);
        bool DeleteContactDetails(ContactDetail contactDetail);
        bool Save();
    }
}
