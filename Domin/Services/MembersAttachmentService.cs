using AutoMapper;
using Core.Infrastruture.RepositoryPattern.Repository;
using DataLayer.Models;
using Domain.DTOs;
using Domain.Helper;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using static Domain.DTOs.MembersProfilePicturesDto;

namespace Domain.Services
{
    public class MembersAttachmentService(IRepository<MembersAttachments> _AttachmentRepository, IMapper _mapper, IChangeLogService _changeLogService , IHistoryLogService _historyLogService) : IMembersAttachmentService
    {

        public async Task<AttachmentResult> CreateAsync(List<MembersAttachmentsDto> attachmentDtos)
        {
            var result = new AttachmentResult();
            var createdAttachments = new List<MembersAttachments>();

            foreach (var attachmentDto in attachmentDtos)
            {
                if (attachmentDto != null)
                {
                    byte[] fileBytes = null;
                    if (attachmentDto.File != null && attachmentDto.File.Length > 0)
                    {
                        using (var stream = new MemoryStream())
                        {
                            await attachmentDto.File.CopyToAsync(stream);
                            fileBytes = stream.ToArray();
                        }
                    }

                    var attachment = new MembersAttachments
                    {
                        Name = attachmentDto.FileName, 
                        FileName = attachmentDto.File?.FileName, 
                        Attachment = fileBytes, 
                        MemberId = attachmentDto.MemberId,
                        ImageExtension  = Path.GetExtension(attachmentDto.File.FileName)
                    };

                    _changeLogService.SetCreateChangeLogInfo(attachment);

                    await _AttachmentRepository.AddAsync(attachment);
                    attachmentDto.Base64Image = Convert.ToBase64String(fileBytes);
                    createdAttachments.Add(attachment);
                }
            }

            result.CreatedAttachment = _mapper.Map<List<MembersAttachmentsDto>>(createdAttachments);
            result.SuccessMessage = MessageEnum.Created(typeof(MembersAttachments).Name);
            result.StatusCode = HttpStatusCode.Created;

            return result;
        }

        public async Task<AttachmentResult> GetAsync(int id)
        {
            var result = new AttachmentResult();
            var AttachmentCondition = (Expression<Func<MembersAttachments, bool>>)(mt => mt.IsDeleted == false && mt.MemberId == id);
            var Attachments = await _AttachmentRepository.FindAllAsync(AttachmentCondition);
            if (!Attachments.Any())
                return Helper.Helper.CreateErrorResult<AttachmentResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Attachment"));
            var AttachmentDtos = Attachments.Select(mt => new MembersAttachmentsDto
            {
                FileName = mt.FileName,
                MemberId = mt.MemberId,
                Base64Image = mt.Attachment != null
           ? Convert.ToBase64String(mt.Attachment)  
           : null  
            }).ToList();

            result.CreatedAttachment = AttachmentDtos;
            result.SuccessMessage = MessageEnum.Getted(typeof(Section).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }

        public async Task<AttachmentResult> UpdateAsync(int id, List<MembersAttachmentsDto> attachmentDtos)
        {
            var result = new AttachmentResult();
            var AttachmentCondition = (Expression<Func<MembersAttachments, bool>>)(mt => mt.IsDeleted == false && mt.MemberId == id);
            var Attachments = await _AttachmentRepository.FindAllAsync(AttachmentCondition);
            var createdAttachments = new List<MembersAttachments>();
            var oldAttachments = new List<MembersAttachments>();
            _mapper.Map(Attachments, oldAttachments);
            foreach (var attachment in Attachments)
            {
                attachment.IsDeleted = true;
                _changeLogService.SetDeleteChangeLogInfo(attachment);
            };
            await _AttachmentRepository.UpdateRangeAsync(Attachments);
            foreach (var attachmentDto in attachmentDtos)
            {
                if (attachmentDto != null)
                {
                    byte[] fileBytes = null;
                    if (attachmentDto.File != null && attachmentDto.File.Length > 0)
                    {
                        using (var stream = new MemoryStream())
                        {
                            await attachmentDto.File.CopyToAsync(stream);
                            fileBytes = stream.ToArray();
                        }
                    }

                    var attachment = new MembersAttachments
                    {
                        Name = attachmentDto.FileName,
                        FileName = attachmentDto.File?.FileName,
                        Attachment = fileBytes,
                        MemberId = attachmentDto.MemberId,
                        ImageExtension = Path.GetExtension(attachmentDto.File.FileName)
                    };

                    _changeLogService.SetCreateChangeLogInfo(attachment);
                    await _AttachmentRepository.AddAsync(attachment);
                    attachmentDto.Base64Image = Convert.ToBase64String(fileBytes);
                    createdAttachments.Add(attachment);
                }
            };
            if (createdAttachments == null || !createdAttachments.Any())
            {
                throw new InvalidOperationException("No created attachments to compare and log.");
            }

            var actionOwner = createdAttachments.FirstOrDefault()?.CreateBy ?? 0;
            if (actionOwner == 0)
            {
                throw new InvalidOperationException("Action owner (CreateBy) is not set for created attachments.");
            }

            await _historyLogService.CompareAndLogAttachmentChanges(createdAttachments, oldAttachments, actionOwner);

            //  await  _historyLogService.CompareAndLogAttachmentChanges(createdAttachments, oldAttachments , (int)createdAttachments[0].CreateBy );
            result.CreatedAttachment = _mapper.Map<List<MembersAttachmentsDto>>(createdAttachments);
            result.SuccessMessage = MessageEnum.Created(typeof(MembersAttachments).Name);
            result.StatusCode = HttpStatusCode.Created;

            return result;
        }
        
        public async Task<AttachmentResult> DeleteAsync(int id)
        {
            var result = new AttachmentResult();
            var AttachmentCondition = (Expression<Func<MembersAttachments, bool>>)(mt => mt.IsDeleted == false && mt.MemberId == id);
            var Attachments = await _AttachmentRepository.FindAllAsync(AttachmentCondition);
            foreach (var attachment in Attachments)
            {
                attachment.IsDeleted = true;
                _changeLogService.SetDeleteChangeLogInfo(attachment);
            };
            if (Attachments == null)
                return Helper.Helper.CreateErrorResult<AttachmentResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Attachment"));
            await _AttachmentRepository.UpdateRangeAsync(Attachments);
            result.SuccessMessage = MessageEnum.Deleted(typeof(MembersAttachments).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }
    }


}

