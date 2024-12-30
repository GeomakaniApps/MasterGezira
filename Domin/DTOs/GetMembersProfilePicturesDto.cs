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
    public class GetMembersProfilePicturesDto : Entity
    {
        public int Id { get; set; }
        public string Base64Image { get; set; }
    }
    public class GetImageResult : OperationResult
    {
        public GetMembersProfilePicturesDto GetImag { get; set; }
    }
}
