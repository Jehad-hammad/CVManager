using Repository.Interfaces;
using Repository.Interfaces.Common;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.UnitOfWork
{
    public interface IRepositoryUnitOfWork : IDisposable
    {
      
        Lazy<ICVRepository> CV { get; set; }
        Lazy<IExperienceInformationRepository> ExperienceInformation { get; set; }
        Lazy<IPersonalInformationRepository> PersonalInformation { get; set; }


    }
}
