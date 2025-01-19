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
            //CreateMap<MembersProfilePictures, MembersProfilePicturesDto>().ReverseMap();
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
            CreateMap<MembersProfilePictures, MembersProfilePicturesDto>()
                .ForMember(dest => dest.Base64Image, opt => opt.MapFrom(src => src.Image != null ? Convert.ToBase64String(src.Image) : null))
                .ReverseMap();
            CreateMap<MemberDto, Member>()
            .ForMember(dest => dest.MembersProfilePicturesId, opt => opt.Ignore())
            .ForMember(dest => dest.MembersPictures, opt => opt.Ignore())
            .ForMember(dest => dest.AttachmentMembers, opt => opt.Ignore());
            CreateMap<Member, GetMemberDto>()
           .ForMember(dest => dest.Image, opt => opt.Ignore())
               .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
               .ForMember(dest => dest.Job, opt => opt.MapFrom(src => src.Job))
                .ForMember(dest => dest.Nationality, opt => opt.MapFrom(src => src.Nationality))
                .ForMember(dest => dest.MemberType, opt => opt.MapFrom(src => src.MemberType))
                .ForMember(dest => dest.Section, opt => opt.MapFrom(src => src.Section))
                .ForMember(dest => dest.Area, opt => opt.MapFrom(src => src.Area))
                .ForMember(dest => dest.Qualification, opt => opt.MapFrom(src => src.Qualification))
                .ForMember(dest => dest.Transformation, opt => opt.MapFrom(src => src.Transformation))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.MembersPictures != null ? Convert.ToBase64String(src.MembersPictures.Image) : null))
                .ForMember(dest => dest.Attachment, opt => opt.MapFrom(src => src.AttachmentMembers));
            CreateMap<MembersAttachments, MembersAttachmentsDto>()
           .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName)) 
           .ForMember(dest => dest.Base64Image, opt => opt.MapFrom(src => src.Attachment != null ? Convert.ToBase64String(src.Attachment) : null));

            CreateMap<MembersAttachmentsDto, MembersAttachments>()
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName)) 
                .ForMember(dest => dest.Attachment, opt => opt.MapFrom(src => src.Base64Image != null ? Convert.FromBase64String(src.Base64Image) : null));

            CreateMap<LateFees,LateFeesDto>().ReverseMap();
            CreateMap<LateFees,GetLateFeesDto>().ReverseMap();
            CreateMap<TransactionType, TransactionTypeDto>().ReverseMap();
            CreateMap<TransactionType, GetTransactionTypeDto>().ReverseMap();

            CreateMap<MembersRef, MemberRefDto>()
            .ForMember(dest => dest.Image, opt => opt.Ignore())
             .ForMember(dest => dest.Base64Image,
        opt => opt.MapFrom(src => src.Image != null && src.Image.Image != null
            ? Convert.ToBase64String(src.Image.Image)
            : null))
            .ForMember(dest => dest.JoinDate, opt => opt.Ignore());
            CreateMap<MemberRefDto, MembersRef>()
                .ForMember(dest => dest.ImageId, opt => opt.Ignore())
             //   .ForMember(dest => dest.Image, opt => opt.Ignore())
                .ForMember(dest => dest.JoinDate, opt => opt.Ignore());
            CreateMap<Member, Member>();
            CreateMap <Area, Area> ();
            CreateMap<City, City>();
            CreateMap<Job, Job>();
            CreateMap<LateFees, LateFees>();
            CreateMap<MemberType, MemberType>();
            CreateMap<MembersRef, MembersRef>();
            CreateMap<Nationality, Nationality>();
            CreateMap<Qualification, Qualification>();
            CreateMap<Reference, Reference>();
            CreateMap<Section, Section>();
            CreateMap<TransactionType, TransactionType>();
            CreateMap<Transformation, Transformation>();
            CreateMap<MembersProfilePictures, MembersProfilePictures>();
            CreateMap<MembersAttachments, MembersAttachments>();
            CreateMap<HistoryLog, GetHistoryLog>().ReverseMap();


            CreateMap<MemberRefDto, MembersRef>()
            .ForMember(dest => dest.Image, opt => opt.Ignore())
            .ForMember(dest => dest.ImageId, opt => opt.Ignore());
            //.ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image))

            //.ForMember(dest => dest.JoinDate, opt => opt.MapFrom(src => src.JoinDate ?? DateOnly.FromDateTime(DateTime.UtcNow)));




            CreateMap<MembersRef, GetMemberRefDto>()
           .ForMember(dest => dest.Image, opt => opt.Ignore())
            .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image != null ? Convert.ToBase64String(src.Image.Image) : null))
           .ForMember(dest => dest.JoinDate, opt => opt.Ignore());


            CreateMap<MembersRef, ArchiveMembersRef>().ReverseMap();
            CreateMap<Member, ArchiveMember>().ReverseMap();

        }
    }
}
