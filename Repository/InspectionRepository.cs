using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class InspectionRepository : RepositoryBase<Inspection>, IInspectionRepository
    {
        public InspectionRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public async Task<IEnumerable<Inspection>> GetAllInspections()
        {
            return await GetAll()
                .Include(i => i.Business)
                .Include(i => i.InspectionGuidelines).ThenInclude(g => g.Guideline)
                .Include(i => i.InspectionType)
                .Include(i => i.EnforcementAgency)
                .OrderBy(i => i.Id)
                .ToListAsync();
        }

        public async Task<Inspection> GetInspectionById(int id)
        {
            return await GetByCondition(i => i.Id.Equals(id))
                .Include(i => i.Business)
                .Include(i => i.InspectionGuidelines)
                .Include(i => i.InspectionType)
                .FirstOrDefaultAsync();
        }
    }
}
