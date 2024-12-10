using DataLayer.Helpers;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class GetMemberTypeDto : Entity
    {
        public int id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? Price { get; set; }
    }
    public class GetMemberTypeResult : OperationResult
    {
        public GetMemberTypeDto MemberType { get; set; }
        public List<GetMemberTypeDto> MemberTypes { get; set; }
    }
}
