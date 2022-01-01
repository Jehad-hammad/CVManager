using Domain.Models;
using Repository.UnitOfWork;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ExperienceInformationService : IExperienceInformationService
    {
        private readonly IRepositoryUnitOfWork _repositoryUnitOfWork;
        public ExperienceInformationService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }

        public ExperienceInformation Add(ExperienceInformation entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExperienceInformation> AddRange(IEnumerable<ExperienceInformation> entities)
        {
            throw new NotImplementedException();
        }

        public ExperienceInformation Get(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExperienceInformation> GetAll()
        {
            throw new NotImplementedException();
        }

        public ExperienceInformation Remove(ExperienceInformation entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExperienceInformation> RemoveRange(IEnumerable<ExperienceInformation> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExperienceInformation> RemoveRangeByIDs(IEnumerable<long> IDs)
        {
            throw new NotImplementedException();
        }

        public ExperienceInformation Update(ExperienceInformation entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExperienceInformation> UpdateRange(IEnumerable<ExperienceInformation> entities)
        {
            throw new NotImplementedException();
        }
    }
}
