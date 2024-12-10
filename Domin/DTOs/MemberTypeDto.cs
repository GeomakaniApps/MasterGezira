using DataLayer.Helpers;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class MemberTypeDto : Entity
    {
        public string Name { get; set; } = string.Empty;
        public int? Price { get; set; }

    }
    public class MemberTypeResult : OperationResult
    {
        public MemberTypeDto MemberType { get; set; }
    }
}
