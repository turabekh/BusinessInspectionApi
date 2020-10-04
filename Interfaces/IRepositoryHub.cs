using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IRepositoryHub
    {
        IBusinessRepository Business { get; }
        IEnforcementAgencyRepository EnforcementAgency { get; }
        IGuidelineRepository Guideline { get; } 
        IInspectionGuidelineRepository InspectionGuideline { get; }
        IInspectionRepository Inspection { get; }
        IInspectionTypeRepository InspectionType { get; }

        void Save();

    }
}
