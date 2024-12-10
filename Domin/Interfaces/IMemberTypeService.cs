using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IMemberTypeService
    {
        Task<MemberTypeResult> CreateAsync(MemberTypeDto memberTypeDto);
        Task<MemberTypeResult> UpdateAsync(int id , MemberTypeDto memberTypeDto);
        Task<MemberTypeResult> DeleteAsync(int id);
        Task<GetMemberTypeResult> GetAllAsync();
        Task<GetMemberTypeResult> GetAsync(int id);
    }
}
