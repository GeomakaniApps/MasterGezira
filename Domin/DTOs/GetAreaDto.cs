using DataLayer.Helpers;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class GetAreaDto:Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
    }
    public class GetAreaResult : OperationResult
    {
        public List<GetAreaDto> Areas { get; set; }
        public GetAreaDto Area { get; set; }
    }
}
