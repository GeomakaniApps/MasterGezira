using DataLayer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class HistoryLog : Entity
    {
        public int Id { get; set; }
        public int RowId { get; set; }
        public int ActionOwner { get; set; }            
        public DateTime ActionDate { get; set; }     
        public string TableName { get; set; }       
        public string ColumnName { get; set; }       
        public string? OldValue { get; set; }        
        public string? NewValue { get; set; }        

      
    }
}
