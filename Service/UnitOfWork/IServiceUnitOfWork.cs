using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.UnitOfWork
{
    public interface IServiceUnitOfWork : IDisposable
    {
        Lazy<ICVSerivce> CV { get; set; }
        Lazy<IExperienceInformationService> ExperienceInformation { get; set; }
        Lazy<IPersonalInformationService> PersonalInformation { get; set; }
    }
}
