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
        public int Discount { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public int MemberTypeId { get; set; }
        public MemberType? MemberType { get; set; }
        public int ReferenceId { get; set; }
        public Reference? Reference { get; set; }

    }
}
