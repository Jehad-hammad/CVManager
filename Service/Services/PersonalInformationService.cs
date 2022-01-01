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
    public class PersonalInformationService : IPersonalInformationService
    {
        private readonly IRepositoryUnitOfWork _repositoryUnitOfWork;
        public PersonalInformationService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }

        public PersonalInformation Add(PersonalInformation entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PersonalInformation> AddRange(IEnumerable<PersonalInformation> entities)
        {
            throw new NotImplementedException();
        }

        public PersonalInformation Get(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PersonalInformation> GetAll()
        {
            throw new NotImplementedException();
        }

        public PersonalInformation Remove(PersonalInformation entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PersonalInformation> RemoveRange(IEnumerable<PersonalInformation> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PersonalInformation> RemoveRangeByIDs(IEnumerable<long> IDs)
        {
            throw new NotImplementedException();
        }

        public PersonalInformation Update(PersonalInformation entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PersonalInformation> UpdateRange(IEnumerable<PersonalInformation> entities)
        {
            throw new NotImplementedException();
        }
    }
}
