using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.DTOs.MembersProfilePicturesDto;

namespace Domain.Interfaces
{
    public interface IMembersAttachmentService
    {
         Task<AttachmentResult> GetAsync(int id);
        Task<AttachmentResult> CreateAsync(List<MembersAttachmentsDto> attachmentDtos);
       Task<AttachmentResult> UpdateAsync(int id, List<MembersAttachmentsDto> attachmentDtos);
        Task<AttachmentResult> DeleteAsync(int id);
    }
}
