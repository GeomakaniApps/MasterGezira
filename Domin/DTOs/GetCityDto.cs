using DataLayer.Helpers;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class GetCityDto : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public class GetCityResult : OperationResult
    {
        public List<GetCityDto> Cities { get; set; }
        public GetCityDto City { get; set; }
    }
}
