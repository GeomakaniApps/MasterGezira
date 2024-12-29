using DataLayer.Helpers;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class SectionDto : Entity
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public double FirstTimeSubscriptionPrice { get; set; }
        [Required]
        public double RenewalSubscriptionPrice { get; set; }
        public double MaintenanceFee { get; set; }
        public double MembershipCardFee { get; set; }
        public double Swimming { get; set; }
        public double JoinFee { get; set; }
        public double NewReferenceFee { get; set; }
        public double PreviousYearsFee { get; set; }
        public double SeparateFee { get; set; }
        [Required]
        public int MemberTypeId { get; set; }
        [Required]
        public int ReferenceId { get; set; }
    }
    public class SectionResult : OperationResult
    {
        public SectionDto Section { get; set; }
    }
}
