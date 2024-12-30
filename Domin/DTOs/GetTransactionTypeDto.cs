using DataLayer.Helpers;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class GetTransactionTypeDto:Entity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public class GetTransactionTypeResult:OperationResult
    {
        public List<GetTransactionTypeDto> TransactionTypes { get; set; }
        public GetTransactionTypeDto TransactionType { get; set; }
    }
}
