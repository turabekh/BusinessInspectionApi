using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class EnforcementAgencyRepository : RepositoryBase<EnforcementAgency>, IEnforcementAgencyRepository
    {
        public EnforcementAgencyRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
