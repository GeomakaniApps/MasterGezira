using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITransactionTypeService
    {
        Task<GetTransactionTypeResult> GetAllAsync();
        Task<GetTransactionTypeResult> GetAsync(int id);
        Task<TransactionTypeResult> CreateAsync(TransactionTypeDto transactionTypeDto);
        Task<TransactionTypeResult> UpdateAsync(int id, TransactionTypeDto transactionTypeDto);
        Task<TransactionTypeResult> DeleteAsync(int id);
    }
}
