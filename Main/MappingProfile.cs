using AutoMapper;
using Models;
using Models.DataTransferObjects.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Main
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Business, BusinessDto>();
            CreateMap<County, CountyDto>();
            CreateMap<EnforcementAgency, EnforcementAgencyDto>();
            CreateMap<Guideline, GuidelineDto>();
            CreateMap<Inspection, InspectionDto>();
            CreateMap<InspectionGuideline, InspectionGuidelineDto>();
            CreateMap<InspectionType, InspectionTypeDto>();
            CreateMap<Sector, SectorDto>();
        }
    }
}
