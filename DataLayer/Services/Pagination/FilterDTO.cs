using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Services.Pagination
{
    public class FilterDTO
    {
        public string? PropertyName { get; set; }
        public string? PropertyValue { get; set; }
        [DefaultValue(false)]
        public bool Range { get; set; }
    }
}
