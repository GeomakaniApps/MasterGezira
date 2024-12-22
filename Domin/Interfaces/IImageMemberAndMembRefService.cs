using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.DTOs.ImageMemberAndMembRefDto;

namespace Domain.Interfaces
{
    public interface IImageMemberAndMembRefService
    {
        Task<GetImageResult> GetAsync(int id);
        Task<ImageResult> CreateAsync(ImageMemberAndMembRefDto imgDto);
        Task<ImageResult> UpdateAsync(int id, ImageMemberAndMembRefDto ImgDto);
        Task<ImageResult> DeleteAsync(int id);
    }
}
