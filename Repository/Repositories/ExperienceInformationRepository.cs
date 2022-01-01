using Domain.Models;
using Repository.Context;
using Repository.Interfaces;
using Repository.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ExperienceInformationRepository: Repository<ExperienceInformation> , IExperienceInformationRepository
    {
        #region Cotext
        private readonly CVManagerContext context;
        #endregion
        public ExperienceInformationRepository(CVManagerContext _context) : base(_context)
        {
            context = _context;

        }
    }
    
}
