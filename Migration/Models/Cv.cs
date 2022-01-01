using System;
using System.Collections.Generic;

#nullable disable

namespace Migration.Models
{
    public partial class Cv
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? PersonalInformationId { get; set; }
        public int? ExperinceInformationId { get; set; }

        public virtual ExperienceInformation ExperinceInformation { get; set; }
        public virtual PersonalInformation PersonalInformation { get; set; }
    }
}
