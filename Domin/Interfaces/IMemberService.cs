using DataLayer.Services.Pagination;
using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.DTOs.GetMemberDto;
using static Domain.DTOs.MemberDto;

namespace Domain.Interfaces
{
    public interface IMemberService
    {
        Task<GetMemberResult> GetAllAsync();
        // Task<GetMemberResult> GetAsync(int id);
        Task<GetMemberResult> GetByIdAsync(int id);
        Task<MemberResult> CreateAsync(MemberDto memberDto);
        Task<MemberResult> UpdateAsync(int id, MemberDto memberDto);
        Task<GetMemberResult> Filter(List<FilterDTO> filterDTOs, UserParams userParams);
        Task<MemberResult> DeleteAsync(int id);
        }
}
