using DataLayer.Helpers;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class NationalityDto : Entity
    {
        public string Name { get; set; } = string.Empty;
    }
    public class NationalityResult : OperationResult
    {
        public NationalityDto Nationality { get; set; }
    }
}
