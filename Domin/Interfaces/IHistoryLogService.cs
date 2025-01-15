using DataLayer.Models;
using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IHistoryLogService
    {
        Task AddHistoryLogAsync(int rowId, int actionOwner, string tableName, string columnName, string oldValue, string newValue);
        Task LogListIfChangedAsync(int rowId, int actionOwner, string tableName, string columnName, IEnumerable<string> oldList, IEnumerable<string> newList);
       Task CompareAndLogMemberChanges(Member newMember, Member oldMember, int actionOwner);
        Task CompareAndLogAreaChanges(Area newArea, Area OldArea, int actionOwner);
        Task CompareAndLogCiryChanges(City newCity, City OldCity, int actionOwner);
        Task CompareAndLogJobChanges(Job newJob, Job OldJob, int actionOwner);
        Task CompareAndLogLateFeesChanges(LateFees newLateFees, LateFees OldLateFees, int actionOwner);
        Task CompareAndLogMemberRefChanges(MembersRef newMemberRef, MembersRef OldMemberRef, int actionOwner);
        Task CompareAndLogMemberTypeChanges(MemberType newMemberType, MemberType OldMemberType, int actionOwner);
        Task CompareAndLogNationalityChanges(Nationality newNationality, Nationality OldNationality, int actionOwner);
        Task CompareAndLogQualificationChanges(Qualification newQualification, Qualification OldQualification, int actionOwner);
        Task CompareAndLogReferenceChanges(Reference newReferencea, Reference OldReference, int actionOwner);
        Task CompareAndLogSectionChanges(Section newSection, Section OldSection, int actionOwner);
        Task CompareAndLogTransactionTypeChanges(TransactionType newTransactionType, TransactionType OldTransactionType, int actionOwner);
        Task CompareAndLogTransformationChanges(Transformation newTransformation, Transformation OldTransformation, int actionOwner);
        Task<GetHistoryLogResult> FindAllAsync(string tableName, string? columnName);
        Task CompareAndLogImageChanges(MembersProfilePictures newImage, MembersProfilePictures oldImage, int actionOwner);
        Task CompareAndLogAttachmentChanges(List<MembersAttachments> newAttachments, List<MembersAttachments> oldAttachments, int actionOwner);
     }
}

