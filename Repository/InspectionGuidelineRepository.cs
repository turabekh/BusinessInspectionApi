using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class InspectionGuidelineRepository : RepositoryBase<InspectionGuideline>, IInspectionGuidelineRepository
    {
        public InspectionGuidelineRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
