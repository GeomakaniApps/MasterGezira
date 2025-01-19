using Domain.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs;
public  class GetMemberRefDto
{
 
    public string? Name { get; set; }
    
    public int MemberCode { get; set; }
    public DateOnly? BirthDate { get; set; }
    public int? SectionId { get; set; }
 
    public int ReferenceId { get; set; }
   
    public string? Sex { get; set; }
    
    public string? Image { get; set; }

    public DateOnly? JoinDate { get; set; }

    public string? Remark { get; set; }

    public class GetMemberRefResult : OperationResult
    {
        public GetMemberRefDto? MemberRef { get; set; }
        public List<GetMemberRefDto> MemberRefs { get; set; }
        
        public int Count { get; set; }


    }
}
