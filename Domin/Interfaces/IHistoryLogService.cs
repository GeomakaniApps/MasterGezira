using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IHistoryLogService
    {
        Task AddHistoryLogAsync(int rowId, int actionOwner, string tableName, string columnName, string oldValue, string newValue);
        Task LogListIfChangedAsync(int rowId, int actionOwner, string tableName, string columnName, IEnumerable<string> oldList, IEnumerable<string> newList);
       Task CompareAndLogMemberChanges(Member newMember, Member oldMember, int actionOwner);
       Task CompareAndLogAreaChanges(Area newArea, Area OldArea, int actionOwner);
    }
}

