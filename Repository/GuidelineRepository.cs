using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Repository
{
    public class GuidelineRepository : RepositoryBase<Guideline>, IGuidelineRepository
    {
        public GuidelineRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
