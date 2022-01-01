using Repository.Context;
using Repository.Interfaces;
using Repository.Interfaces.Common;
using Repository.Repositories;
using Repository.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.UnitOfWork
{
    public class RepositoryUnitOfWork : IRepositoryUnitOfWork
    {
        private CVManagerContext _Context;
        
        public Lazy<ICVRepository> CV { get; set; }
        public Lazy<IExperienceInformationRepository> ExperienceInformation { get; set; }
        public Lazy<IPersonalInformationRepository> PersonalInformation { get; set; }

        public RepositoryUnitOfWork(CVManagerContext context  )
        {
            _Context = context;
            CV = new Lazy<ICVRepository>(() => new CVReposiotry(_Context));
            PersonalInformation = new Lazy<IPersonalInformationRepository>(() => new PersonalInformationRepository(_Context));
            ExperienceInformation = new Lazy<IExperienceInformationRepository>(() => new ExperienceInformationRepository(_Context));

        }

        public void Dispose()
        {
            _Context.Dispose();
            CV = null;
            PersonalInformation = null;
            ExperienceInformation = null;
        }
    }
}
