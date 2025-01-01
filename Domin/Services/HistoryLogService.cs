using Core.Infrastruture.RepositoryPattern.Repository;
using DataLayer.Models;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class HistoryLogService(IRepository<HistoryLog> _HistoryLogRepository) : IHistoryLogService
    {
        
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

            CompareAndLogProperty(logDetailsList, newMember, oldMember, nameof(newMember.Name), newMember.Name, oldMember.Name);
            CompareAndLogProperty(logDetailsList, newMember, oldMember, nameof(newMember.NationalId), newMember.NationalId?.ToString(), oldMember.NationalId?.ToString());
            CompareAndLogProperty(logDetailsList, newMember, oldMember, nameof(newMember.NationalityId), newMember.NationalityId?.ToString(), oldMember.NationalityId?.ToString());
            CompareAndLogProperty(logDetailsList, newMember, oldMember, nameof(newMember.PhoneNumber), newMember.PhoneNumber, oldMember.PhoneNumber);
            CompareAndLogProperty(logDetailsList, newMember, oldMember, nameof(newMember.Address), newMember.Address, oldMember.Address);
            CompareAndLogProperty(logDetailsList, newMember, oldMember, nameof(newMember.JobAddress), newMember.JobAddress, oldMember.JobAddress);
            CompareAndLogProperty(logDetailsList, newMember, oldMember, nameof(newMember.JobTelephone), newMember.JobTelephone, oldMember.JobTelephone);
            CompareAndLogProperty(logDetailsList, newMember, oldMember, nameof(newMember.JobId), newMember.JobId?.ToString(), oldMember.JobId?.ToString());
            CompareAndLogProperty(logDetailsList, newMember, oldMember, nameof(newMember.MemberTypeId), newMember.MemberTypeId?.ToString(), oldMember.MemberTypeId?.ToString());
            CompareAndLogProperty(logDetailsList, newMember, oldMember, nameof(newMember.SectionId), newMember.SectionId?.ToString(), oldMember.SectionId?.ToString());
            CompareAndLogProperty(logDetailsList, newMember, oldMember, nameof(newMember.CityId), newMember.CityId?.ToString(), oldMember.CityId?.ToString());
            CompareAndLogProperty(logDetailsList, newMember, oldMember, nameof(newMember.AreaId), newMember.AreaId?.ToString(), oldMember.AreaId?.ToString());
            CompareAndLogProperty(logDetailsList, newMember, oldMember, nameof(newMember.QualificationId), newMember.QualificationId?.ToString(), oldMember.QualificationId?.ToString());
            CompareAndLogProperty(logDetailsList, newMember, oldMember, nameof(newMember.BirthPlace), newMember.BirthPlace?.ToString(), oldMember.BirthPlace?.ToString());
            CompareAndLogProperty(logDetailsList, newMember, oldMember, nameof(newMember.Sex), newMember.Sex, oldMember.Sex);
            CompareAndLogProperty(logDetailsList, newMember, oldMember, nameof(newMember.Religion), newMember.Religion, oldMember.Religion);
            CompareAndLogProperty(logDetailsList, newMember, oldMember, nameof(newMember.Remark), newMember.Remark, oldMember.Remark);
            CompareAndLogProperty(logDetailsList, newMember, oldMember, nameof(newMember.MembersProfilePicturesId), newMember.MembersProfilePicturesId?.ToString(), oldMember.MembersProfilePicturesId?.ToString());
            CompareAndLogProperty(logDetailsList, newMember, oldMember, nameof(newMember.MaritalStatus), newMember.MaritalStatus, oldMember.MaritalStatus);
            CompareAndLogProperty(logDetailsList, newMember, oldMember, nameof(newMember.BirthDate), newMember.BirthDate?.ToString(), oldMember.BirthDate?.ToString());
            CompareAndLogProperty(logDetailsList, newMember, oldMember, nameof(newMember.JoinDate), newMember.JoinDate?.ToString(), oldMember.JoinDate?.ToString());


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

            CompareAndLogProperty(logDetailsList, newArea, OldArea, nameof(newArea.Name), newArea.Name, OldArea.Name);

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

        private void CompareAndLogProperty<T>(List<HistoryLog> logDetailsList, T newEntity, T oldEntity, string columnName, string newValue, string oldValue)
        {
            // تأكد من أن القيم غير متساوية أو أن هناك تغيير فعلي
            if (newValue != oldValue)
            {
                // الحصول على معرف الكائن (Id) من النوع T
                var entityId = GetEntityId(newEntity);

                // إضافة السجل في التاريخ إذا كان هناك تغيير
                logDetailsList.Add(new HistoryLog
                {
                    RowId = entityId, // استخدام معرف الكائن
                    ColumnName = columnName,
                    OldValue = oldValue ?? "null",  // إذا كانت القيمة القديمة null، قم بتسجيل "null"
                    NewValue = newValue ?? "null"   // إذا كانت القيمة الجديدة null، قم بتسجيل "null"
                });
            }
        }

        // دالة مساعدة للحصول على الـ Id من أي كائن
        private int GetEntityId<T>(T entity)
        {
            // نفترض أن الكائنات تحتوي على خاصية "Id" من نوع int
            var propertyInfo = entity.GetType().GetProperty("Id");
            if (propertyInfo != null)
            {
                return (int)propertyInfo.GetValue(entity);
            }
            throw new InvalidOperationException("Entity does not have an 'Id' property.");
        }

        //private void CompareAndLogProperty(List<HistoryLog> logDetailsList, Area newArea, Area oldArea, string columnName, string newValue, string oldValue)
        //{
        //    if (newValue != oldValue)
        //    {
        //        logDetailsList.Add(new HistoryLog
        //        {
        //            RowId = newArea.Id,  
        //            ColumnName = columnName,
        //            OldValue = oldValue ?? "null",  
        //            NewValue = newValue ?? "null"   
        //        });
        //    }
        //}


        private void CompareAndLogProperty(List<HistoryLog> logDetailsList, Member newMember, Member oldMember, string columnName, string newValue, string oldValue)
        {
            if (newValue != oldValue)
            {
                logDetailsList.Add(new HistoryLog
                {
                    RowId = newMember.Id, 
                    ColumnName = columnName,
                    OldValue = oldValue ?? "null", 
                    NewValue = newValue ?? "null" 
                });
            }
        }


    }

}
