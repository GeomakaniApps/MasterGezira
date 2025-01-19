using DataLayer.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class ArchiveMembersRef:Entity
    {
        public int Id { get; set; }
        public DateOnly? BirthDate { get; set; }
        public int? SectionId { get; set; }
        public Section? Section { get; set; }
        public int MemberCode { get; set; }
        public string Name { get; set; }
        public int ReferenceId { get; set; }
        public Reference? Reference { get; set; }
        public int ChildrenOrder { get; set; }
        public string? Sex { get; set; }
        public int? ImageId { get; set; }
        public MembersProfilePictures? Image { get; set; }
        public DateOnly? JoinDate { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int? DeleteBy { get; set; }
        public DateTime? DeleteAt { get; set; }
        [DefaultValue(false)]
        public bool? Suspended { get; set; }
        public string? Remark { get; set; }
        public string DeletionReason { get; set; }
        public bool Archived { get; set; }
    }
}
