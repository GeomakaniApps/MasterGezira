using DataLayer.Helpers;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class GetReferenceDto : Entity
    {
        public int id { get; set; } 
        public string Name { get; set; }  = string.Empty;   
    }
    public class GetReferenceResult : OperationResult
    {
        public GetReferenceDto Reference { get; set; }
        public List<GetReferenceDto> References { get; set; }
    }
}
