using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Parameters;
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

        public async Task<PageList<Inspection>> GetAllInspections(InspectionParameters inspectionParameters)
        {
            return await PageList<Inspection>.ToPageList(
                 GetAll()
                .Include(i => i.Business).ThenInclude(b => b.County)
                .Include(i => i.Business).ThenInclude(b => b.Sector)
                .Include(i => i.InspectionGuidelines).ThenInclude(g => g.Guideline)
                .Include(i => i.InspectionType)
                .Include(i => i.EnforcementAgency)
                .OrderBy(i => i.Id), inspectionParameters.PageNumber, inspectionParameters.PageSize
                );
        }



        public async Task<IEnumerable<Inspection>> GetAllInspections()
        {
            return await GetAll()
                .Include(i => i.Business).ThenInclude(b => b.County)
                .Include(i => i.Business).ThenInclude(b => b.Sector)
                .Include(i => i.InspectionGuidelines).ThenInclude(g => g.Guideline)
                .Include(i => i.InspectionType)
                .Include(i => i.EnforcementAgency)
                .OrderBy(i => i.Id)
                .ToListAsync();
        }

        public async Task<Inspection> GetInspectionById(int id)
        {
            return await GetByCondition(i => i.Id.Equals(id))
                .Include(i => i.Business).ThenInclude(b => b.County)
                .Include(i => i.Business).ThenInclude(b => b.Sector)
                .Include(i => i.InspectionGuidelines)
                .Include(i => i.InspectionType)
                .FirstOrDefaultAsync();
        }
    }
}
