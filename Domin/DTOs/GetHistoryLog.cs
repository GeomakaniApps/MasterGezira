using DataLayer.Helpers;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class GetHistoryLog : Entity
    {
        public int RowId { get; set; }
        public int ActionOwner { get; set; }
        public DateTime ActionDate { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
    }
    public class GetHistoryLogResult : OperationResult
    {
        public List<GetHistoryLog> historyLogs { get; set; }
    }
}
