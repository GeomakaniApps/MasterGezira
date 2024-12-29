using DataLayer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{ 
    public class MembersAttachments : Entity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? FileName { get; set; }
        public byte[]? Attachment { get; set; }
        public bool IsDeleted { get; set; }
        public int? MemberId { get; set; }
        public int? MemberRefId { get; set; }
        public string? ImageExtension { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public int? DeleteBy { get; set; }
        public DateTime? DeleteAt { get; set; }
        public Member? Member { get; set; }
        public MembersAttachments()
        {
            IsDeleted = false;
        }
    }
}