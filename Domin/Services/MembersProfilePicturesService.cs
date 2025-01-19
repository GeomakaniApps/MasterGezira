using AutoMapper;
using Core.Infrastruture.RepositoryPattern.Repository;
using DataLayer.Models;
using Domain.DTOs;
using Domain.Helper;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Domain.DTOs.MembersProfilePicturesDto;
using static System.Net.Mime.MediaTypeNames;

namespace Domain.Services
{
    public class MembersProfilePicturesService(IRepository<MembersProfilePictures> _ImageReposatory ,IMapper _mapper , IChangeLogService _changeLogService,IHistoryLogService _historyLogService) : IMembersProfilePicturesService
    {
        public async Task<ImageResult> CreateAsync(MembersProfilePicturesDto imageDto)
        {
            var result = new ImageResult();
            if (imageDto.Image != null && imageDto.Image.Length > 0)
            {

                using (var stream = new MemoryStream())
                {
                    await imageDto.Image.CopyToAsync(stream);

                    var Images = new MembersProfilePictures
                    {
                        Name = Path.GetFileNameWithoutExtension(imageDto.Image.FileName),
                        ImageExtension = Path.GetExtension(imageDto.Image.FileName),
                        Image = stream.ToArray(),
                        //UploadedAt = DateTime.UtcNow,
                        //MemberId = imageDto.memberId,
                        //MemberRefId = imageDto.memberRefId
                    };
                    _changeLogService.SetCreateChangeLogInfo(Images);
                    await _ImageReposatory.AddAsync(Images);
                    imageDto.Id = Images.id;
                    imageDto.Base64Image = Convert.ToBase64String(Images.Image);
                }
            }
            result.Image = imageDto;
            result.SuccessMessage = MessageEnum.Created(typeof(MembersProfilePictures).Name);
            result.StatusCode = HttpStatusCode.Created;
            return result;
        }

        public async Task<ImageResult> DeleteAsync(int id)
        {
            var result = new ImageResult();
            var imeges = await _ImageReposatory.GetByIdAsync(id);
            if (imeges == null)
                return Helper.Helper.CreateErrorResult<ImageResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Image"));
            imeges.IsDeleted = true;
            await _ImageReposatory.UpdateAsync(imeges);
            result.SuccessMessage = MessageEnum.Deleted(typeof(MembersProfilePictures).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }

        public async Task<GetImageResult> GetAsync(int id)
        {
            var result = new GetImageResult();
            var Image = await _ImageReposatory.GetByIdAsync(id);
            if (Image == null)
                return Helper.Helper.CreateErrorResult<GetImageResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Image"));
            var imageDto = new GetMembersProfilePicturesDto
            {
                Id = Image.id,
                Base64Image = Convert.ToBase64String(Image.Image ?? new byte[0]),
            };

            result.GetImag = imageDto;
            result.SuccessMessage = MessageEnum.Getted(typeof(MembersProfilePictures).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }

        public async Task<ImageResult> UpdateAsync(int id, MembersProfilePicturesDto imageDto)
        {
            var result = new ImageResult();
            var imeges = await _ImageReposatory.GetByIdAsync(id);
            if (imeges == null)
                return Helper.Helper.CreateErrorResult<ImageResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Image"));
            imeges.IsDeleted = true;
            var oldImage = new MembersProfilePictures();
            _mapper.Map(imeges , oldImage);
            await _ImageReposatory.UpdateAsync(imeges);
            if (imageDto.Image != null && imageDto.Image.Length > 0)
            {

                using (var stream = new MemoryStream())
                {
                    await imageDto.Image.CopyToAsync(stream);

                    var images = new MembersProfilePictures
                    {
                        Name = Path.GetFileNameWithoutExtension(imageDto.Image.FileName),
                        ImageExtension = Path.GetExtension(imageDto.Image.FileName),
                        Image = stream.ToArray(),
                        //MemberId = imageDto.memberId
                    };
                    _changeLogService.SetCreateChangeLogInfo(images);
                    await _ImageReposatory.UpdateAsync(images);
                    imageDto.Base64Image = Convert.ToBase64String(images.Image);
                    await _historyLogService.CompareAndLogImageChanges(images, oldImage, (int)imeges.CreateBy);
                }
            }
            result.Image = imageDto;
            result.SuccessMessage = MessageEnum.Updated(typeof(MembersProfilePictures).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }
    }
}
