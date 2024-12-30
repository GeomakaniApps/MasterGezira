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
    public class MembersAttachmentsDto : Entity
    {
        public int? Id { get; set; }
        [Required]
        public string? FileName { get; set; }
        public string? Base64Image { get; set; }
       [Required]
        public IFormFile? File { get; set; }
        public int? MemberId { get; set; }
    }
    public class AttachmentResult : OperationResult
    {

        public List<MembersAttachmentsDto> CreatedAttachment { get; set; }
    }
}
