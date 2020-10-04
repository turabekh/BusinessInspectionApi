using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class BusinessRepository : RepositoryBase<Business>, IBusinessRepository
    {
        public BusinessRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
