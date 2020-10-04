using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class InspectionRepository : RepositoryBase<Inspection>, IInspectionRepository
    {
        public InspectionRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
