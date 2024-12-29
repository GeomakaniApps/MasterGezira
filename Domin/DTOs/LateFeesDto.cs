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
    public class LateFeesDto:Entity
    {
        [Required]
        public DateOnly FineDate { get; set; }
        [Range(1, 100, ErrorMessage = "Fine rate must be between 1 and 100.")]
        public int FineRate { get; set; }
    }
    public class LateFeesResult : OperationResult
    {
        public LateFeesDto LateFees { get; set; }
    }
}
