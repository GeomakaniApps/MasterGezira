using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.DTOs.GetMemberRefDto;
using static Domain.DTOs.MemberRefDto;

namespace Domain.Interfaces;

public interface IMemberRefService
{
    //Task<MemberRefResult> GetAllAsync();
    Task<GetMemberRefResult> GetAsync(int id);
    Task<MemberRefResult> CreateAsync(MemberRefDto memberRefDto);
    Task<MemberRefResult> UpdateAsync(int id, MemberRefDto memberRefDto);
    Task<MemberRefResult> DeleteAsync(int id,string deletionReason);
    Task<MemberRefResult> UnArchiveAsync(int id);
}
