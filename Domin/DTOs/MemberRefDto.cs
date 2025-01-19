using DataLayer.Helpers;
using Domain.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.DTOs;

public class MemberRefDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public int MemberCode { get; set; }
    public DateOnly? BirthDate { get; set; }
    public int? SectionId { get; set; }
    [Required]
    public int ReferenceId { get; set; }
    [Required]
    [RegularExpression("^(أنثي|ذكر)$", ErrorMessage = "Invalid value for Sex. Allowed values are 'أنثي' or 'ذكر'.")]
    public string? Sex { get; set; }
    public string? Base64Image { get; set; }
    public IFormFile? Image { get; set; }
   
    public DateOnly? JoinDate { get; set; }

    public string? Remark { get; set; }

    public class MemberRefResult : OperationResult
    {
        public MemberRefDto? MemberRef { get; set; }
        //public GetMemberRefDto? Memberref { get; set; }
        //public MembersProfilePicturesDto? Image { get; set; } 

    }
}
