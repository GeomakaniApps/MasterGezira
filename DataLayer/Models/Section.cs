using DataLayer.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Section : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double FirstTimeSubscriptionPrice { get; set; }
        public double RenewalSubscriptionPrice { get; set; }
        public double MaintenanceFee { get; set; }
        public double MembershipCardFee { get; set; }
        public double Swimming { get; set; }
        public double JoinFee { get; set; }
        public double NewReferenceFee { get; set; }
        public double PreviousYearsFee { get; set; }
        public double SeparateFee { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public int MemberTypeId { get; set; }
        public MemberType? MemberType { get; set; }
        public bool? Child { get; set; }

        public int ReferenceId { get; set; }
        public Reference? Reference { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        //public int? UpdateBy { get; set; }
        //public DateTime? UpdateAt { get; set; }
        public int? DeleteBy { get; set; }
        public DateTime? DeleteAt { get; set; }
       
    }
}
