using DataLayer.Helpers;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class GetQualificationDto : Entity
    {
        public int id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public class GetQualificationResult : OperationResult
    {
        public GetQualificationDto Qualification { get; set; }
        public List<GetQualificationDto> Qualifications { get; set; }
    }
}
