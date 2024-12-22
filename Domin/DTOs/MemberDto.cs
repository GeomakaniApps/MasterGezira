using DataLayer.Helpers;
using Domain.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class MemberDto : Entity
    {
        [Required]
        public string? Name { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@"^(?!0)\d{14}$", ErrorMessage = "NationalId must be a 14-digit number and cannot start with zero.")]
        public long? NationalId { get; set; }
        [Required]
        public DateOnly? BirthDate { get; set; }
        public string? Address { get; set; }
        [Required]
        public int? JobId { get; set; }
        public string? JobAddress { get; set; }
        [Required]
      //  [StringLength(11, MinimumLength = 8, ErrorMessage = "Job Telephone should be between 8 and 11 characters long.")]
     //   [RegularExpression("^(?!010|011|012|015)\\d{5,8}$", ErrorMessage = "Job Telephone format is invalid.")]
        public int? JobTelephone { get; set; }
        [Required]
        [RegularExpression("^(اعزب|متزوج)$", ErrorMessage = "Invalid value for religion. Allowed values are 'اعزب' or 'متزوج'.")]
        public string? MaritalStatus { get; set; }
        [Required]
        public int? NationalityId { get; set; }
        [Required]
        [RegularExpression("^(مسيحي|مسلم)$", ErrorMessage = "Invalid value for religion. Allowed values are 'مسيحي' or 'مسلم'.")]
        public string? Religion { get; set; }
        [Required]
        [RegularExpression("^(أنثي|ذكر)$", ErrorMessage = "Invalid value for Sex. Allowed values are 'أنثي' or 'ذكر'.")]
        public string? Sex { get; set; }
        //[Required]
        //[StringLength(11, MinimumLength = 11, ErrorMessage = "Phone Number should be exactly 11 characters long.")]
        //[RegularExpression("^(010|011|012|015)\\d{8}$", ErrorMessage = "Phone Number format is invalid.")]
        [Required]
      //  [Range(10000000000, 99999999999, ErrorMessage = "Phone Number should be exactly 11 digits.")]
        public int? PhoneNumber { get; set; }
        [Required]
        public string? Remark { get; set; }
        [Required]
        public int? MemberTypeId { get; set; }
        [Required]
        public int? SectionId { get; set; }
        [Required]
        public int? CityId { get; set; }
        [Required]
        public int? AreaId { get; set; }
        [Required]
        public int? QualificationId { get; set; }
        //[Required]
        //public int? TransformationId { get; set; }
        public string? BirthPlace { get; set; }
        public IFormFile? Image { get; set; }
        public class MemberResult : OperationResult
        {
            public MemberDto? Member { get; set; }
        }
    }
}
