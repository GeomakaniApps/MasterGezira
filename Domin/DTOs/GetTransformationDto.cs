using DataLayer.Helpers;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class GetTransformationDto:Entity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public class GetTransformationResult : OperationResult
    {
        public GetTransformationDto Transformation { get; set; }
        public List<GetTransformationDto> Transformations { get; set; }
    }
}
