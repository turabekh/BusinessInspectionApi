using Models;
using Models.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IInspectionRepository : IRepositoryBase<Inspection>
    {
        Task<IEnumerable<Inspection>> GetAllInspections();
        Task<PageList<Inspection>> GetAllInspections(InspectionParameters inspectionParameters);
        Task<Inspection> GetInspectionById(int id);

    }
}
