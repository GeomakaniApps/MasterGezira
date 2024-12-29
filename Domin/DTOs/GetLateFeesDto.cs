using DataLayer.Helpers;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class GetLateFeesDto:Entity
    {
        public int Id { get; set; }
        public DateOnly FineDate { get; set; }
        public int FineRate { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class GetLateFeesResult : OperationResult
    {
        public List<GetLateFeesDto> LateFees { get; set; }
        public GetLateFeesDto LateFee { get; set; }
    }
}
