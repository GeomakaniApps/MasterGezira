using DataLayer.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class MembersProfilePictures : Entity
    {
        public int id { get; set; }
        public int? MemberId { get; set; }
        public int? MemberRefId { get; set; }
        public string Name { get; set; }
        public string? ImageExtension { get; set; }
        public byte[]? Image { get; set; }
        //  public DateTime UploadedAt { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public int? DeleteBy { get; set; }
        public DateTime? DeleteAt { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public ICollection<Member>? Members { get; set; }
        public MembersRef? MembersRefs { get; set; }
    }
}
