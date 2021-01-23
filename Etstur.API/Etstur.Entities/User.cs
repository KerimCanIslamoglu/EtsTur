using System;
using System.Collections.Generic;
using System.Text;

namespace Etstur.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BloodType { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
