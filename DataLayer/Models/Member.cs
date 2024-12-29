using DataLayer.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Member : Entity
    {
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberCode { get; set; }
        public string? Name { get; set; }
        public long? NationalId { get; set; }
        public int? MembersProfilePicturesId { get; set; }
        public DateOnly? BirthDate { get; set; }
        public string? Address { get; set; }
        public int? JobId { get; set; }
        public string? JobAddress { get; set; }
        public string? JobTelephone { get; set; }
        public string? MaritalStatus { get; set; }
        public int? NationalityId { get; set; }
        public string? Religion { get; set; }
        public string? Sex { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Remark { get; set; }
        public int? MemberTypeId { get; set; }
        public int? SectionId { get; set; }
        public int? CityId { get; set; }
        public int? AreaId { get; set; }
        public int? QualificationId { get; set; }
        public int? TransformationId { get; set; }
        public string? BirthPlace { get; set; }
      //  public string? UserId { get; set; }
        public DateOnly? JoinDate { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int? DeleteBy { get; set; }
        public DateTime? DeleteAt { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public bool? IsActive { get; set; }
        [DefaultValue(false)]
        public bool Suspended { get; set; }
        public Area? Area { get; set; }
        public City? City { get; set; }
        public Job? Job { get; set; }
        public MemberType? MemberType { get; set; }
        public Nationality? Nationality { get; set; }
        public Qualification? Qualification { get; set; }
        public Section? Section { get; set; }
        public Transformation? Transformation { get; set; }
        public MembersProfilePictures? MembersPictures { get; set; }
        public ICollection<MembersAttachments> AttachmentMembers { get; set; } = new List<MembersAttachments>();
    }
}
