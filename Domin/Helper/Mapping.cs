using AutoMapper;
using DataLayer.Models;
using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helper
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<Area, AreaDto>().ReverseMap();
            CreateMap<Area, GetAreaDto>().ReverseMap();
            CreateMap<Job, JobDto>().ReverseMap();
            CreateMap<Job, GetJobDto>().ReverseMap();
            CreateMap<Transformation, TransformationDto>().ReverseMap();
            CreateMap<Transformation, GetTransformationDto>().ReverseMap();
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<City, GetCityDto>().ReverseMap();
            CreateMap<Section, SectionDto>().ReverseMap();
            CreateMap<Section, GetSectionDto>().ReverseMap();
            CreateMap<MemberType, MemberTypeDto>().ReverseMap();
            CreateMap<MemberType, GetMemberTypeDto>().ReverseMap();
            CreateMap<Nationality, NationalityDto>().ReverseMap();
            CreateMap<Nationality, GetNationalityDto>().ReverseMap();
        }
    }
}
