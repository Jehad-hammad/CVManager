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
    public class CVService : ICVSerivce
    {
        private readonly IRepositoryUnitOfWork _repostoryUnitOfWork;
        public CVService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repostoryUnitOfWork = repositoryUnitOfWork;
        }
        public Cv Add(Cv entity)
        {
            Cv postedItem = _repostoryUnitOfWork.CV.Value.Add(entity);
            return postedItem;
        }

        public IEnumerable<Cv> AddRange(IEnumerable<Cv> entities)
        {
            throw new NotImplementedException();
        }

        public Cv Get(long Id)
        {
            Cv cv = _repostoryUnitOfWork.CV.Value.FirstOrDefault(x => x.Id == Id, i => i.PersonalInformation, e => e.ExperinceInformation);
            return cv;
        }

        public IEnumerable<Cv> GetAll()
        {
            IEnumerable<Cv> cv = _repostoryUnitOfWork.CV.Value.Find(x=>true , i=>i.PersonalInformation,l => l.ExperinceInformation);
            return cv;
        }

        public Cv Remove(Cv entity)
        {
            PersonalInformation personalInformation = entity.PersonalInformation;
            ExperienceInformation experienceInformation = entity.ExperinceInformation;
            Cv cv = _repostoryUnitOfWork.CV.Value.Remove(entity);

            if (personalInformation != null)
            {
                _repostoryUnitOfWork.PersonalInformation.Value.Remove(personalInformation);
            }
            if (experienceInformation != null)
            {
                _repostoryUnitOfWork.ExperienceInformation.Value.Remove(experienceInformation);

            }
            return entity;
        }

        public IEnumerable<Cv> RemoveRange(IEnumerable<Cv> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cv> RemoveRangeByIDs(IEnumerable<long> IDs)
        {
            throw new NotImplementedException();
        }

        public Cv Update(Cv entity)
        {
            PersonalInformation personalInformation = entity.PersonalInformation;
            ExperienceInformation experienceInformation = entity.ExperinceInformation;

            _repostoryUnitOfWork.ExperienceInformation.Value.Update(experienceInformation);
            _repostoryUnitOfWork.PersonalInformation.Value.Update(personalInformation);

            entity.PersonalInformation = null;
            entity.ExperinceInformation = null;

            Cv UpdatedItem = _repostoryUnitOfWork.CV.Value.Update(entity);
            return UpdatedItem;
        }

        public IEnumerable<Cv> UpdateRange(IEnumerable<Cv> entities)
        {
            throw new NotImplementedException();
        }
    }
}
