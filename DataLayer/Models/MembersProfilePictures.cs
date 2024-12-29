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
        public int? memberId { get; set; }
        public int? memberRefId { get; set; }
        public string Name { get; set; }
        public string? ImageExtension { get; set; }
        public byte[]? Image { get; set; }
      //  public DateTime UploadedAt { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public ICollection<Member>? Members { get; set; }
    }
}
