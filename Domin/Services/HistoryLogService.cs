using AutoMapper;
using Core.Infrastruture.RepositoryPattern.Repository;
using DataLayer.Models;
using Domain.DTOs;
using Domain.Helper;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Domain.Services
{
    public class HistoryLogService(IRepository<HistoryLog> _HistoryRepository ,IRepository<HistoryLog> _HistoryLogRepository , IMapper _mapper) : IHistoryLogService
    {
        public async Task<GetHistoryLogResult> FindAllAsync(string tableName , string? columnName)
        {
            var result = new GetHistoryLogResult();
            var historyLog = columnName == null
                ? await _HistoryLogRepository.FindAllAsync(m => m.TableName == tableName)
                : await _HistoryLogRepository.FindAllAsync(m => m.TableName == tableName && m.ColumnName == columnName); 
            if (!historyLog.Any())
                return Helper.Helper.CreateErrorResult<GetHistoryLogResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("History Log"));
            var historyLogDto = _mapper.Map<List<GetHistoryLog>>(historyLog);
            result.historyLogs = historyLogDto;
            result.SuccessMessage = MessageEnum.Getted(typeof(HistoryLog).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }
        public async Task AddHistoryLogAsync(int rowId, int actionOwner, string tableName, string columnName, string oldValue, string newValue)
        {
            var historyLog = new HistoryLog
            {
                RowId = rowId, 
                ActionOwner = actionOwner, 
                ActionDate = DateTime.UtcNow, 
                TableName = tableName, 
                ColumnName = columnName, 
                OldValue = oldValue, 
                NewValue = newValue  
            };

            await _HistoryLogRepository.AddAsync(historyLog);
        }

        public async Task LogListIfChangedAsync(int rowId, int actionOwner, string tableName, string columnName, IEnumerable<string> oldList, IEnumerable<string> newList)
        {
            var oldValues = string.Join(", ", oldList ?? Enumerable.Empty<string>());
            var newValues = string.Join(", ", newList ?? Enumerable.Empty<string>());

            await AddHistoryLogAsync(rowId, actionOwner, tableName, columnName, oldValues, newValues);
        }
        public async Task CompareAndLogMemberChanges(Member newMember, Member oldMember, int actionOwner)
        {
            var logDetailsList = new List<HistoryLog>();

            CompareAndLogProperty(logDetailsList, newMember, nameof(newMember.Name), newMember.Name, oldMember.Name);
            CompareAndLogProperty(logDetailsList, newMember, nameof(newMember.NationalId), newMember.NationalId?.ToString(), oldMember.NationalId?.ToString());
            CompareAndLogProperty(logDetailsList, newMember, nameof(newMember.NationalityId), newMember.NationalityId?.ToString(), oldMember.NationalityId?.ToString());
            CompareAndLogProperty(logDetailsList, newMember, nameof(newMember.PhoneNumber), newMember.PhoneNumber, oldMember.PhoneNumber);
            CompareAndLogProperty(logDetailsList, newMember, nameof(newMember.Address), newMember.Address, oldMember.Address);
            CompareAndLogProperty(logDetailsList, newMember, nameof(newMember.JobAddress), newMember.JobAddress, oldMember.JobAddress);
            CompareAndLogProperty(logDetailsList, newMember, nameof(newMember.JobTelephone), newMember.JobTelephone, oldMember.JobTelephone);
            CompareAndLogProperty(logDetailsList, newMember, nameof(newMember.JobId), newMember.JobId?.ToString(), oldMember.JobId?.ToString());
            CompareAndLogProperty(logDetailsList, newMember, nameof(newMember.MemberTypeId), newMember.MemberTypeId?.ToString(), oldMember.MemberTypeId?.ToString());
            CompareAndLogProperty(logDetailsList, newMember, nameof(newMember.SectionId), newMember.SectionId?.ToString(), oldMember.SectionId?.ToString());
            CompareAndLogProperty(logDetailsList, newMember, nameof(newMember.CityId), newMember.CityId?.ToString(), oldMember.CityId?.ToString());
            CompareAndLogProperty(logDetailsList, newMember, nameof(newMember.AreaId), newMember.AreaId?.ToString(), oldMember.AreaId?.ToString());
            CompareAndLogProperty(logDetailsList, newMember, nameof(newMember.QualificationId), newMember.QualificationId?.ToString(), oldMember.QualificationId?.ToString());
            CompareAndLogProperty(logDetailsList, newMember, nameof(newMember.BirthPlace), newMember.BirthPlace?.ToString(), oldMember.BirthPlace?.ToString());
            CompareAndLogProperty(logDetailsList, newMember, nameof(newMember.Sex), newMember.Sex, oldMember.Sex);
            CompareAndLogProperty(logDetailsList, newMember, nameof(newMember.Religion), newMember.Religion, oldMember.Religion);
            CompareAndLogProperty(logDetailsList, newMember, nameof(newMember.Remark), newMember.Remark, oldMember.Remark);
            CompareAndLogProperty(logDetailsList, newMember, nameof(newMember.MembersProfilePicturesId), newMember.MembersProfilePicturesId?.ToString(), oldMember.MembersProfilePicturesId?.ToString());
            CompareAndLogProperty(logDetailsList, newMember, nameof(newMember.MaritalStatus), newMember.MaritalStatus, oldMember.MaritalStatus);
            CompareAndLogProperty(logDetailsList, newMember, nameof(newMember.BirthDate), newMember.BirthDate?.ToString(), oldMember.BirthDate?.ToString());
            CompareAndLogProperty(logDetailsList, newMember, nameof(newMember.JoinDate), newMember.JoinDate?.ToString(), oldMember.JoinDate?.ToString());


            if (logDetailsList.Any())
            {
                foreach (var logDetail in logDetailsList)
                {
                    await AddHistoryLogAsync(
                        newMember.Id,           
                        actionOwner,            
                        "Member",               
                        logDetail.ColumnName,   
                        logDetail.OldValue,     
                        logDetail.NewValue      
                    );
                }
            }
        }
        public async Task CompareAndLogAreaChanges(Area newArea, Area OldArea , int actionOwner)
        {
            var logDetailsList = new List<HistoryLog>();

            CompareAndLogProperty(logDetailsList, newArea, nameof(newArea.Name), newArea.Name, OldArea.Name);

            if (logDetailsList.Any())
            {
                foreach (var logDetail in logDetailsList)
                {
                    await AddHistoryLogAsync(
                        newArea.Id,             
                        actionOwner,            
                        "Area",                 
                        logDetail.ColumnName,   
                        logDetail.OldValue,     
                        logDetail.NewValue      
                    );
                }
            }

        }
        public async Task CompareAndLogCiryChanges(City newCity, City OldCity, int actionOwner)
        {
            var logDetailsList = new List<HistoryLog>();

            CompareAndLogProperty(logDetailsList, newCity, nameof(newCity.Name), newCity.Name, OldCity.Name);

            if (logDetailsList.Any())
            {
                foreach (var logDetail in logDetailsList)
                {
                    await AddHistoryLogAsync(
                        newCity.Id,
                        actionOwner,
                        "City",
                        logDetail.ColumnName,
                        logDetail.OldValue,
                        logDetail.NewValue
                    );
                }
            }

        }
        public async Task CompareAndLogJobChanges(Job newJob, Job OldJob, int actionOwner)
        {
            var logDetailsList = new List<HistoryLog>();

            CompareAndLogProperty(logDetailsList, newJob, nameof(newJob.Name), newJob.Name, OldJob.Name);

            if (logDetailsList.Any())
            {
                foreach (var logDetail in logDetailsList)
                {
                    await AddHistoryLogAsync(
                        newJob.Id,
                        actionOwner,
                        "Job",
                        logDetail.ColumnName,
                        logDetail.OldValue,
                        logDetail.NewValue
                    );
                }
            }

        }
        public async Task CompareAndLogLateFeesChanges(LateFees newLateFees, LateFees OldLateFees, int actionOwner)
        {
            var logDetailsList = new List<HistoryLog>();

            CompareAndLogProperty(logDetailsList, newLateFees, nameof(newLateFees.FineRate), newLateFees.FineRate.ToString(), OldLateFees.FineRate.ToString());
            CompareAndLogProperty(logDetailsList, newLateFees, nameof(newLateFees.FineDate), newLateFees.FineDate.ToString(), OldLateFees.FineDate.ToString());

            if (logDetailsList.Any())
            {
                foreach (var logDetail in logDetailsList)
                {
                    await AddHistoryLogAsync(
                        newLateFees.Id,
                        actionOwner,
                        "LateFees",
                        logDetail.ColumnName,
                        logDetail.OldValue,
                        logDetail.NewValue
                    );
                }
            }

        }
        public async Task CompareAndLogMemberRefChanges(MembersRef newMemberRef, MembersRef OldMemberRef, int actionOwner)
        {
            var logDetailsList = new List<HistoryLog>();

            CompareAndLogProperty(logDetailsList, newMemberRef, nameof(newMemberRef.Name), newMemberRef.Name, OldMemberRef.Name);
            CompareAndLogProperty(logDetailsList, newMemberRef  , nameof(newMemberRef.MemberCode), newMemberRef.MemberCode.ToString(), OldMemberRef.MemberCode.ToString());
            CompareAndLogProperty(logDetailsList, newMemberRef, nameof(newMemberRef.BirthDate), newMemberRef.BirthDate.ToString(), OldMemberRef.BirthDate.ToString());
            CompareAndLogProperty(logDetailsList, newMemberRef, nameof(newMemberRef.JoinDate), newMemberRef.JoinDate.ToString(), OldMemberRef.JoinDate.ToString());
            CompareAndLogProperty(logDetailsList, newMemberRef,  nameof(newMemberRef.Sex), newMemberRef.Sex, OldMemberRef.Sex);
            CompareAndLogProperty(logDetailsList, newMemberRef, nameof(newMemberRef.Remark), newMemberRef.Remark, OldMemberRef.Remark);
            CompareAndLogProperty(logDetailsList, newMemberRef, nameof(newMemberRef.SectionId), newMemberRef.SectionId.ToString(), OldMemberRef.SectionId.ToString());
            CompareAndLogProperty(logDetailsList, newMemberRef, nameof(newMemberRef.Suspended), newMemberRef.Suspended.ToString(), OldMemberRef.Suspended.ToString());
            CompareAndLogProperty(logDetailsList, newMemberRef, nameof(newMemberRef.ReferenceId), newMemberRef.ReferenceId.ToString(), OldMemberRef.ReferenceId.ToString());

            if (logDetailsList.Any())
            {
                foreach (var logDetail in logDetailsList)
                {
                    await AddHistoryLogAsync(
                        newMemberRef.Id,
                        actionOwner,
                        "MemberRef",
                        logDetail.ColumnName,
                        logDetail.OldValue,
                        logDetail.NewValue
                    );
                }
            }

        }
        //public async Task CompareAndLogAttachmentChanges(List<MembersAttachments> newAttachments, List<MembersAttachments> oldAttachments, int actionOwner)
        //{
        //    var logDetailsList = new List<HistoryLog>();

        //    // قم بالمقارنة بين المرفقات القديمة والجديدة بناءً على الـ Id
        //    foreach (var newAttachment in newAttachments)
        //    {
        //        var oldAttachment = oldAttachments.FirstOrDefault(a => a.Id == oldAttachments.);
        //        if (oldAttachment == null) continue;
        //        var oldAttachmentId = oldAttachments.FirstOrDefault(a => a.Id == oldAttachment.Id);
        //            CompareAndLogList(logDetailsList, newAttachment, nameof(newAttachment.Name), newAttachment.Name?.Split(','), oldAttachmentId.Name?.Split(','));
        //            CompareAndLogList(logDetailsList, newAttachment, nameof(newAttachment.FileName), newAttachment.FileName?.Split(','), oldAttachmentId.FileName?.Split(','));
        //            CompareAndLogList(logDetailsList, newAttachment, nameof(newAttachment.MemberId), newAttachment.MemberId?.ToString().Split(','), oldAttachmentId.MemberId?.ToString().Split(','));
        //            CompareAndLogList(logDetailsList, newAttachment, nameof(newAttachment.MemberRefId), newAttachment.MemberRefId?.ToString().Split(','), oldAttachmentId.MemberRefId?.ToString().Split(','));
        //            CompareAndLogList(logDetailsList, newAttachment, nameof(newAttachment.CreateAt), newAttachment.CreateAt?.ToString().Split(','), oldAttachmentId.CreateAt?.ToString().Split(','));

        //    }

        //    if (logDetailsList.Any())
        //    {
        //        foreach (var logDetail in logDetailsList)
        //        {
        //            await LogListIfChangedAsync(
        //                newAttachments.FirstOrDefault()?.Id ?? 0,
        //                actionOwner,
        //                "MembersAttachments",
        //                logDetail.ColumnName,
        //                logDetail.OldValue.Split(','),
        //                logDetail.NewValue.Split(',')
        //            );
        //        }
        //    }
        //}
        public async Task CompareAndLogAttachmentChanges(List<MembersAttachments> newAttachments, List<MembersAttachments> oldAttachments, int actionOwner)
        {
            var logDetailsList = new List<HistoryLog>();

            for (int i = 0; i < Math.Min(newAttachments.Count, oldAttachments.Count); i++)
            {
                var newAttachment = newAttachments[i];
                var oldAttachment = oldAttachments[i];

                // قم بالمقارنة بين العنصر الجديد والقديم بناءً على المؤشر الحالي
                CompareAndLogList(logDetailsList, newAttachment, nameof(newAttachment.Name),
                    newAttachment.Name?.Split(','), oldAttachment.Name?.Split(','));

                CompareAndLogList(logDetailsList, newAttachment, nameof(newAttachment.FileName),
                    newAttachment.FileName?.Split(','), oldAttachment.FileName?.Split(','));

                CompareAndLogList(logDetailsList, newAttachment, nameof(newAttachment.MemberId),
                    newAttachment.MemberId?.ToString().Split(','), oldAttachment.MemberId?.ToString().Split(','));

                CompareAndLogList(logDetailsList, newAttachment, nameof(newAttachment.MemberRefId),
                    newAttachment.MemberRefId?.ToString().Split(','), oldAttachment.MemberRefId?.ToString().Split(','));
            }

            // قم بمعالجة النتائج
            if (logDetailsList.Any())
            {
                foreach (var logDetail in logDetailsList)
                {
                    await LogListIfChangedAsync(
                        newAttachments.FirstOrDefault()?.Id ?? 0,
                        actionOwner,
                        "MembersAttachments",
                        logDetail.ColumnName,
                        logDetail.OldValue.Split(','),
                        logDetail.NewValue.Split(',')
                    );
                }
            }

        }
    
        


        public async Task CompareAndLogImageChanges(MembersProfilePictures newImage, MembersProfilePictures oldImage, int actionOwner)
        {
            var logDetailsList = new List<HistoryLog>();

            CompareAndLogProperty(logDetailsList, newImage, nameof(newImage.Name), newImage.Name, oldImage.Name);
            CompareAndLogProperty(logDetailsList, newImage, nameof(newImage.MemberId), newImage.MemberId.ToString(), oldImage.MemberId.ToString());
            CompareAndLogProperty(logDetailsList, newImage, nameof(newImage.MemberRefId), newImage.MemberRefId.ToString(), oldImage.MemberRefId.ToString());

            if (logDetailsList.Any())
            {
                foreach (var logDetail in logDetailsList)
                {
                    await AddHistoryLogAsync(
                        oldImage.id,
                        actionOwner,
                        "MembersProfilePictures",
                        logDetail.ColumnName,
                        logDetail.OldValue,
                        logDetail.NewValue
                    );
                }
            }

        }
        public async Task CompareAndLogMemberTypeChanges(MemberType newMemberType, MemberType OldMemberType, int actionOwner)
        {
            var logDetailsList = new List<HistoryLog>();

            CompareAndLogProperty(logDetailsList, newMemberType, nameof(newMemberType.Name), newMemberType.Name, OldMemberType.Name);

            if (logDetailsList.Any())
            {
                foreach (var logDetail in logDetailsList)
                {
                    await AddHistoryLogAsync(
                        newMemberType.id,
                        actionOwner,
                        "MemberType",
                        logDetail.ColumnName,
                        logDetail.OldValue,
                        logDetail.NewValue
                    );
                }
            }

        }
        public async Task CompareAndLogNationalityChanges(Nationality newNationality, Nationality OldNationality, int actionOwner)
        {
            var logDetailsList = new List<HistoryLog>();

            CompareAndLogProperty(logDetailsList, newNationality, nameof(newNationality.Name), newNationality.Name, OldNationality.Name);

            if (logDetailsList.Any())
            {
                foreach (var logDetail in logDetailsList)
                {
                    await AddHistoryLogAsync(
                        newNationality.Id,
                        actionOwner,
                        "Nationality",
                        logDetail.ColumnName,
                        logDetail.OldValue,
                        logDetail.NewValue
                    );
                }
            }

        }
        public async Task CompareAndLogQualificationChanges(Qualification newQualification, Qualification OldQualification, int actionOwner)
        {
            var logDetailsList = new List<HistoryLog>();

            CompareAndLogProperty(logDetailsList, newQualification, nameof(newQualification.Name), newQualification.Name, OldQualification.Name);

            if (logDetailsList.Any())
            {
                foreach (var logDetail in logDetailsList)
                {
                    await AddHistoryLogAsync(
                        newQualification.id,
                        actionOwner,
                        "Qualification",
                        logDetail.ColumnName,
                        logDetail.OldValue,
                        logDetail.NewValue
                    );
                }
            }

        }
        public async Task CompareAndLogReferenceChanges(Reference newReferencea, Reference OldReference, int actionOwner)
        {
            var logDetailsList = new List<HistoryLog>();

            CompareAndLogProperty(logDetailsList, newReferencea , nameof(newReferencea.Name), newReferencea.Name, OldReference.Name);

            if (logDetailsList.Any())
            {
                foreach (var logDetail in logDetailsList)
                {
                    await AddHistoryLogAsync(
                        newReferencea.Id,
                        actionOwner,
                        "Reference",
                        logDetail.ColumnName,
                        logDetail.OldValue,
                        logDetail.NewValue
                    );
                }
            }

        }
        public async Task CompareAndLogSectionChanges(DataLayer.Models.Section newSection, DataLayer.Models.Section OldSection, int actionOwner)
        {
            var logDetailsList = new List<HistoryLog>();

            CompareAndLogProperty(logDetailsList, newSection, nameof(newSection.Name), newSection.Name, OldSection.Name);
            CompareAndLogProperty(logDetailsList, newSection, nameof(newSection.FirstTimeSubscriptionPrice), newSection.FirstTimeSubscriptionPrice.ToString(), OldSection.FirstTimeSubscriptionPrice.ToString());
            CompareAndLogProperty(logDetailsList, newSection, nameof(newSection.RenewalSubscriptionPrice), newSection.RenewalSubscriptionPrice.ToString(), OldSection.RenewalSubscriptionPrice.ToString());
            CompareAndLogProperty(logDetailsList, newSection, nameof(newSection.MaintenanceFee), newSection.MaintenanceFee.ToString(), OldSection.MaintenanceFee.ToString());
            CompareAndLogProperty(logDetailsList, newSection, nameof(newSection.MembershipCardFee), newSection.MembershipCardFee.ToString(), OldSection.MembershipCardFee.ToString());
            CompareAndLogProperty(logDetailsList, newSection, nameof(newSection.Swimming), newSection.Swimming.ToString(), OldSection.Swimming.ToString());
            CompareAndLogProperty(logDetailsList, newSection, nameof(newSection.PreviousYearsFee), newSection.PreviousYearsFee.ToString(), OldSection.PreviousYearsFee.ToString());
            CompareAndLogProperty(logDetailsList, newSection, nameof(newSection.JoinFee), newSection.JoinFee.ToString(), OldSection.JoinFee.ToString());
            CompareAndLogProperty(logDetailsList, newSection, nameof(newSection.NewReferenceFee), newSection.NewReferenceFee.ToString(), OldSection.NewReferenceFee.ToString());
            CompareAndLogProperty(logDetailsList, newSection, nameof(newSection.SeparateFee), newSection.SeparateFee.ToString(), OldSection.SeparateFee.ToString());
            CompareAndLogProperty(logDetailsList, newSection, nameof(newSection.MemberTypeId), newSection.MemberTypeId.ToString(), OldSection.MemberTypeId.ToString());
            CompareAndLogProperty(logDetailsList, newSection, nameof(newSection.ReferenceId), newSection.ReferenceId.ToString(), OldSection.ReferenceId.ToString());

            if (logDetailsList.Any())
            {
                foreach (var logDetail in logDetailsList)
                {
                    await AddHistoryLogAsync(
                        OldSection.Id,
                        actionOwner,
                        "Section",
                        logDetail.ColumnName,
                        logDetail.OldValue,
                        logDetail.NewValue
                    );
                }
            }

        }
        public async Task CompareAndLogTransactionTypeChanges(TransactionType newTransactionType, TransactionType OldTransactionType, int actionOwner)
        {
            var logDetailsList = new List<HistoryLog>();

            CompareAndLogProperty(logDetailsList, newTransactionType, nameof(newTransactionType.Name), newTransactionType.Name, OldTransactionType.Name);

            if (logDetailsList.Any())
            {
                foreach (var logDetail in logDetailsList)
                {
                    await AddHistoryLogAsync(
                        newTransactionType.Id,
                        actionOwner,
                        "TransactionType",
                        logDetail.ColumnName,
                        logDetail.OldValue,
                        logDetail.NewValue
                    );
                }
            }

        }
        public async Task CompareAndLogTransformationChanges(Transformation newTransformation, Transformation OldTransformation, int actionOwner)
        {
            var logDetailsList = new List<HistoryLog>();

            CompareAndLogProperty(logDetailsList, newTransformation, nameof(newTransformation.Name), newTransformation.Name, OldTransformation.Name);

            if (logDetailsList.Any())
            {
                foreach (var logDetail in logDetailsList)
                {
                    await AddHistoryLogAsync(
                        newTransformation.Id,
                        actionOwner,
                        "Transformation",
                        logDetail.ColumnName,
                        logDetail.OldValue,
                        logDetail.NewValue
                    );
                }
            }

        }
        private void CompareAndLogProperty<T>(List<HistoryLog> logDetailsList, T newEntity, string columnName, string newValue, string oldValue)
        {
            if (newValue != oldValue)
            {

                logDetailsList.Add(new HistoryLog
                {
                    ColumnName = columnName,
                    OldValue = oldValue ?? "null",  
                    NewValue = newValue ?? "null"   
                });
            }
        }
        private void CompareAndLogList<T>(List<HistoryLog> logDetailsList, MembersAttachments newAttachment, string columnName, IEnumerable<T> newValues, IEnumerable<T> oldValues)
        {
            var oldValueString = string.Join(", ", oldValues?.Select(v => v.ToString()) ?? Enumerable.Empty<string>());
            var newValueString = string.Join(", ", newValues?.Select(v => v.ToString()) ?? Enumerable.Empty<string>());

            if (oldValueString != newValueString)
            {
                logDetailsList.Add(new HistoryLog
                {
                    ColumnName = columnName,
                    OldValue = oldValueString,
                    NewValue = newValueString,
                });
            }
        }

    }

}
