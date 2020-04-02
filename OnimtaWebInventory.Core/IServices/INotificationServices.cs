using OnimtaWebInventory.Models;
using SignalRHub;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
    public interface INotificationServices
    {
        Task<IEnumerable<NotificationEventsVM>> GetNotificationEventDetailsByUserId(int userId);
        Task<NotificationSettingVM> GetNotificationSetting(int companyId);
        Task<NotificationEventsVM> AddNotificationEvents(NotificationEventsVM notificationEventsVM);
        Task<NotificationEventsVM> UpdateNotificationEventsDetailByUserId(int Id, int IsActive);
        Task<NotificationEventsVM> DeleteNotificationEventsDetailByUserId(int userId);
        Task<int> SendNotification(MessageVM messageVm);
        Task<NotificationEventsVM> UpdateUserNotificationReadByUserId(int userId);

        Task<NotificationTypeVM> GetNotificationUserIdsByNotificationTypeId(int notificationTypeId,string branchId, string transactionNo,int userId);

        Task<NotificationTypeVM> updateNotificationTypeDetails(NotificationTypeVM notificationTypeVM);
        Task<IEnumerable<NotificationTypeVM>> getAllNotificationTypeDetails(int companyId);

    }
}
