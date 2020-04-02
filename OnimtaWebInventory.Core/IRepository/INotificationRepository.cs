using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
   public interface INotificationRepository
    {
        Task <IEnumerable<NotificationEventsVM>> GetNotificationEventDetailsByUserId(int userId);
        Task<NotificationSettingVM> GetNotificationSetting(int companyId);
        Task<NotificationEventsVM> AddNotificationEvents(NotificationEventsVM notificationEventsVM);
        Task<NotificationEventsVM> UpdateNotificationEventsDetailByUserId(int Id, int IsActive);
        Task<NotificationEventsVM> DeleteNotificationEventsDetailByUserId(int userId);
        Task<NotificationEventsVM> UpdateUserNotificationReadByUserId(int userId);
        Task<NotificationTypeVM> updateNotificationTypeDetails(NotificationTypeVM notificationTypeVM);
        Task<IEnumerable<NotificationTypeVM>> getAllNotificationTypeDetails(int companyId);
        Task<NotificationTypeVM> GetNotificationUserIdsByNotificationTypeId(int notificationTypeId, string branchId, string referenceNo, int userId);

    }
}
