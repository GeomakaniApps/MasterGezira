using DataLayer.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class MemberType : Entity
    {
        public int id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? Price { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
