using System;
using System.Collections.Generic;


namespace Domain.Models
{
    public partial class ExperienceInformation
    {
        public ExperienceInformation()
        {
            Cvs = new HashSet<Cv>();
        }

        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string CompnayField { get; set; }

        public virtual ICollection<Cv> Cvs { get; set; }
    }
}
