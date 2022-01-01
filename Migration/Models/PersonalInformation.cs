using System;
using System.Collections.Generic;

#nullable disable

namespace Migration.Models
{
    public partial class PersonalInformation
    {
        public PersonalInformation()
        {
            Cvs = new HashSet<Cv>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string CityName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }

        public virtual ICollection<Cv> Cvs { get; set; }
    }
}
