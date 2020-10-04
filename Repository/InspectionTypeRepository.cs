using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class InspectionTypeRepository : RepositoryBase<InspectionType>, IInspectionTypeRepository
    {
        public InspectionTypeRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
