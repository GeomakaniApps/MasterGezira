using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ChangeLogService(IHttpContextAccessor _httpContextAccessor): IChangeLogService
    {
        private string GetUserName()
        {
            var userName = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
            if (string.IsNullOrEmpty(userName))
            {
                throw new Exception("The user does not have a username.");
            }
            return userName;
        }
        public string GetUserId()
        {
            var nameId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (string.IsNullOrEmpty(nameId))
                throw new Exception("The employee does not have an ID to process payments.");
            return nameId;
        }
        public void SetCreateChangeLogInfo<T>(T entity) where T : class
        {
            //  var userName = GetUserName();  
            var nameId = GetUserId();
            var UserId = Convert.ToInt32(nameId);
            var createByProperty = entity.GetType().GetProperty("CreateBy");
            var createAtProperty = entity.GetType().GetProperty("CreateAt");

            
            if (createByProperty != null)
            {
                createByProperty.SetValue(entity, UserId);
            }
            if (createAtProperty != null)
            {
                createAtProperty.SetValue(entity, DateTime.UtcNow);
            }
        }
        public void SetUpdateChangeLogInfo<T>(T entity) where T : class
        {
            var userName = GetUserId();
            var UserId = Convert.ToInt32(userName);

            var UpdateByProperty = entity.GetType().GetProperty("UpdateBy");
            var UpdateAtProperty = entity.GetType().GetProperty("UpdateAt");

            if (UpdateByProperty != null)
            {
                UpdateByProperty.SetValue(entity, UserId);
            }
            if (UpdateAtProperty != null)
            {
                UpdateAtProperty.SetValue(entity, DateTime.UtcNow);
            }
        }
        public void SetDeleteChangeLogInfo<T>(T entity) where T : class
        {
            var userName = GetUserId();
            var UserId = Convert.ToInt32(userName);
            var CancelByProperty = entity.GetType().GetProperty("DeleteBy");
            var CancelAtProperty = entity.GetType().GetProperty("DeleteAt");

            if (CancelByProperty != null)
            {
                CancelByProperty.SetValue(entity, UserId);
            }

            if (CancelAtProperty != null)
            {
                CancelAtProperty.SetValue(entity, DateTime.UtcNow);
            }
        }
    }
}

