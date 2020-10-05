using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IInspectionRepository : IRepositoryBase<Inspection>
    {
        Task<IEnumerable<Inspection>> GetAllInspections();
        Task<Inspection> GetInspectionById(int id);

    }
}
