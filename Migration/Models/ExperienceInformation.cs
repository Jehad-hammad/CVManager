using System;
using System.Collections.Generic;

#nullable disable

namespace Migration.Models
{
    public partial class ExperienceInformation
    {
        public ExperienceInformation()
        {
            Cvs = new HashSet<Cv>();
        }

        public int Id { get; set; }
        public string CompanyName { get; set; }

        public virtual ICollection<Cv> Cvs { get; set; }
    }
}
