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
    public class ReferenceDto : Entity
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int Price { get; set; } 
    }
    public class ReferenceResult : OperationResult
    {
        public ReferenceDto Reference { get; set; }

    }
}
