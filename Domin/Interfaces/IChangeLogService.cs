using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IChangeLogService
    {
        void SetCreateChangeLogInfo<T>(T entity) where T : class;
        void SetUpdateChangeLogInfo<T>(T entity) where T : class;
        void SetDeleteChangeLogInfo<T>(T entity) where T : class;
        string GetUserId();
    }
}
