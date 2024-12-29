using DataLayer.Helpers;
using DataLayer.Models;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class GetSectionDto : Entity
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
        public bool IsDeleted { get; set; }
        public int MemberTypeId { get; set; }
        public MemberType? MemberType { get; set; }
        public int ReferenceId { get; set; }
        public Reference? Reference { get; set; }
    }
    public class GetSectionResult : OperationResult
    {
        public List<GetSectionDto> Sections { get; set; }
        public GetSectionDto Section { get; set; }
    }
}
