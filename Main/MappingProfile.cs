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
            CreateMap<Business, BusinessDto>().ReverseMap(); ;
            CreateMap<County, CountyDto>().ReverseMap();
            CreateMap<EnforcementAgency, EnforcementAgencyDto>().ReverseMap();
            CreateMap<Guideline, GuidelineDto>().ReverseMap();
            CreateMap<Inspection, InspectionDto>()
                .ForMember(dest =>
                    dest.CertificateNumber,
                    opt => opt.MapFrom(src => src.Business.BRCCode))
                .ForMember(dest =>
                    dest.InspectionGuidelineDtos,
                    opt => opt.MapFrom(src => src.InspectionGuidelines))
                .ForMember(dest =>
                    dest.InspectionType,
                    opt => opt.MapFrom(src => src.InspectionType.Name));
            CreateMap<InspectionGuideline, InspectionGuidelineDto>().ReverseMap();
            CreateMap<InspectionType, InspectionTypeDto>().ReverseMap();
            CreateMap<Sector, SectorDto>().ReverseMap();
        }
    }
}
