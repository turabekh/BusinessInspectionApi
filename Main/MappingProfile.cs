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
                    opt => opt.MapFrom(src => src.InspectionType.Name))
                .ForMember(dest =>
                    dest.BusinessName,
                    opt => opt.MapFrom(src => src.Business.BusinessName))
                .ForMember(dest =>
                    dest.County,
                    opt => opt.MapFrom(src => src.Business.County.CountyName
                    ))
                .ForMember(dest =>
                    dest.ZipCode,
                    opt => opt.MapFrom(src => src.Business.ZipCode))
                .ForMember(dest =>
                    dest.CountyCode,
                    opt => opt.MapFrom(src => src.Business.County.CountyId)
                );
            CreateMap<InspectionGuideline, InspectionGuidelineDto>().ReverseMap();
            CreateMap<InspectionType, InspectionTypeDto>().ReverseMap();
            CreateMap<Sector, SectorDto>().ReverseMap();
        }
    }
}
