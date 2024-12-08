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
    public class GetJobDto:Entity
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
    public class GetJobResult : OperationResult
    {
        public List<GetJobDto> Jobs { get; set; }
        public GetJobDto Job { get; set; }
    }
}
