using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.DTOs.MembersProfilePicturesDto;

namespace Domain.Interfaces
{
    public interface IMembersProfilePicturesService
    {
        Task<GetImageResult> GetAsync(int id);
        Task<ImageResult> CreateAsync(MembersProfilePicturesDto imgDto);
        Task<ImageResult> UpdateAsync(int id, MembersProfilePicturesDto ImgDto);
        Task<ImageResult> DeleteAsync(int id);
    }
}
