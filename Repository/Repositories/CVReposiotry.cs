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
    public class CVReposiotry : Repository<Cv> , ICVRepository
    {
        #region Context
        private readonly CVManagerContext context;
        #endregion
        public CVReposiotry(CVManagerContext _context) : base(_context)
        {
            context = _context;
        }
    }
}
