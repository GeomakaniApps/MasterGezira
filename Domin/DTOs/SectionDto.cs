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
        public double Price { get; set; }
        [Range(0, 100, ErrorMessage = "Discount must be between 0 and 100.")]
        public int Discount { get; set; }
        [Required]
        public int MemberTypeId { get; set; }
    }
    public class SectionResult : OperationResult
    {
        public SectionDto Section { get; set; }
    }
}
