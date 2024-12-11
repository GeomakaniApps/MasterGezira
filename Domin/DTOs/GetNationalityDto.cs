using DataLayer.Helpers;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class GetNationalityDto : Entity
    {
        public int id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public class GetNationalityResult : OperationResult
    {
        public List<GetNationalityDto> Nationalities { get; set; }
        public GetNationalityDto Nationality { get; set; }
    }
}
