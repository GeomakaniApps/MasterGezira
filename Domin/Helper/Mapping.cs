using AutoMapper;
using DataLayer.Models;
using Domain.DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Http;
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
            CreateMap<Qualification, GetQualificationDto>().ReverseMap();
            CreateMap<Qualification, QualificationDto>().ReverseMap();
            CreateMap<Reference, ReferenceDto>().ReverseMap();
            CreateMap<Reference, GetReferenceDto>().ReverseMap();
            CreateMap<ImageMemberAndMembRefService, GetImagMamberAndMembRefDto>().ReverseMap();
            CreateMap<MemberDto, Member>()
            .ForMember(dest => dest.ImageId, opt => opt.Ignore())
            .ForMember(dest => dest.Image, opt => opt.Ignore()); 
            CreateMap<Member, GetMemberDto>()
           .ForMember(dest => dest.Image, opt => opt.Ignore())
               .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
               .ForMember(dest => dest.Job, opt => opt.MapFrom(src => src.Job))
                .ForMember(dest => dest.Nationality, opt => opt.MapFrom(src => src.Nationality))
                .ForMember(dest => dest.MemberType, opt => opt.MapFrom(src => src.MemberType))
                .ForMember(dest => dest.Section, opt => opt.MapFrom(src => src.Section))
                .ForMember(dest => dest.Area, opt => opt.MapFrom(src => src.Area))
                .ForMember(dest => dest.Qualification, opt => opt.MapFrom(src => src.Qualification))
                .ForMember(dest => dest.Transformation, opt => opt.MapFrom(src => src.Transformation));

            CreateMap<LateFees,LateFeesDto>().ReverseMap();
            CreateMap<LateFees,GetLateFeesDto>().ReverseMap();

            CreateMap<MembersRef, MemberRefDto>()
            .ForMember(dest => dest.Image, opt => opt.Ignore())
            .ForMember(dest => dest.JoinDate, opt => opt.Ignore());
            CreateMap<MemberRefDto, MembersRef>()
                .ForMember(dest => dest.ImageId, opt => opt.Ignore())
                .ForMember(dest => dest.Image, opt => opt.Ignore())
                .ForMember(dest => dest.JoinDate, opt => opt.Ignore());

        }
    }
}
