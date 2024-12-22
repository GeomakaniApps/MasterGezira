using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class GetMemberDto
    {
        public int Id { get; set; }
        public int MemberCode { get; set; }
        public string? Name { get; set; }
        public long? NationalId { get; set; }
        public int? ImageId { get; set; }
        public string? Image { get; set; }
        public DateOnly? BirthDate { get; set; }
        public string? Address { get; set; }
        public string? JobAddress { get; set; }
        public int? JobTelephone { get; set; }
        public string? MaritalStatus { get; set; }
        public int? NationalityId { get; set; }
        public string? Religion { get; set; }
       public string? Sex { get; set; }
        public int? PhoneNumber { get; set; }
        public string? Remark { get; set; }
        public string? BirthPlace { get; set; }
        public CityDto? City { get; set; }
        public NationalityDto? Nationality { get; set; }
        public MemberTypeDto? MemberType { get; set; }
        public SectionDto? Section { get; set; }
        public JobDto? Job { get; set; }
        public AreaDto? Area { get; set; }
        public QualificationDto? Qualification { get; set; }
        public TransformationDto? Transformation { get; set; }

        public class GetMemberResult : OperationResult
        {
            public List<GetMemberDto> Members { get; set; }
            public GetMemberDto Member { get; set; }
        }
    }
}
