using Repository.Context;
using Repository.UnitOfWork;
using Service.Interfaces;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.UnitOfWork
{
    public class ServiceUnitOfWork : IServiceUnitOfWork
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;
        public Lazy<ICVSerivce> CV { get; set; }
        public Lazy<IExperienceInformationService> ExperienceInformation { get; set; }
        public Lazy<IPersonalInformationService> PersonalInformation { get; set; }

        public ServiceUnitOfWork(CVManagerContext context)
        {
            _repositoryUnitOfWork = new RepositoryUnitOfWork(context);

            CV = new Lazy<ICVSerivce>(() => new CVService(_repositoryUnitOfWork));
            PersonalInformation = new Lazy<IPersonalInformationService>(() => new PersonalInformationService(_repositoryUnitOfWork));
            ExperienceInformation = new Lazy<IExperienceInformationService>(() => new ExperienceInformationService(_repositoryUnitOfWork));
        }
        public void Dispose()
        {
        }
    }
}
