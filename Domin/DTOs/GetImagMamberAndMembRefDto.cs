using DataLayer.Helpers;
using Domain.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class GetImagMamberAndMembRefDto : Entity
    {
        public int Id { get; set; }
        public string Base64Image { get; set; }
    }
    public class GetImageResult : OperationResult
    {
        public GetImagMamberAndMembRefDto GetImag { get; set; }
    }
}
