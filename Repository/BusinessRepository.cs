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
    public class BusinessRepository : RepositoryBase<Business>, IBusinessRepository
    {
        public BusinessRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public async Task<IEnumerable<Business>> GetAllBusinesses()
        {
            return await GetAll()
                .Include(b => b.County)
                .Include(b => b.Sector)
                .Include(b => b.Inspections)
                .OrderBy(b => b.BusinessName)
                .ToListAsync();
        }

        public async Task<Business> GetBusinessByBRCCode(string brcCode)
        {
            return await GetByCondition(b => b.BRCCode.Equals(brcCode))
                .Include(b => b.County)
                .Include(b => b.Sector)
                .Include(b => b.Inspections)
                .FirstOrDefaultAsync();
        }

        public async Task<Business> GetBusinessById(int id)
        {
            return await GetByCondition(b => b.BusinessId.Equals(id))
                .Include(b => b.County)
                .Include(b => b.Sector)
                .Include(b => b.Inspections)
                .FirstOrDefaultAsync();
        }
    }
}
