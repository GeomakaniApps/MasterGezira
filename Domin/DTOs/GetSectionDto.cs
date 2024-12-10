using DataLayer.Helpers;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class GetSectionDto : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public class GetSectionResult : OperationResult
    {
        public List<GetSectionDto> Sections { get; set; }
        public GetSectionDto Section { get; set; }
    }
}
