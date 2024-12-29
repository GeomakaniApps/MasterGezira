using DataLayer.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class LateFees:Entity
    {
        public int Id { get; set; }
        public DateOnly FineDate { get; set; }
        public int FineRate { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
