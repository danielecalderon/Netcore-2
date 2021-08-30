using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models
{
    public class ContactDetail
    {
        public int Id { get; set; }       
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }       
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }       
        public string Number { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }
    }
}
