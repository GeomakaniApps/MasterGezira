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
    public class ImageMemberAndMembRefDto : Entity
    {
        public int? Id { get; set; }
        public IFormFile? Image { get; set; }
        public int? memberId { get; set; }
        public int? memberRefId { get; set; }
        public class ImageResult : OperationResult
        {
            public ImageMemberAndMembRefDto? Image { get; set; }
        }
    }
}
