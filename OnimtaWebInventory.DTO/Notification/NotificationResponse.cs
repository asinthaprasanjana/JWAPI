using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Notification
{
   public class NotificationResponse : BaseResponse
    {
        public IEnumerable<NotificationVM> notificationVM { get; set; }
    }
    public class NotificationEventsResponse : BaseResponse
    {
        public IEnumerable<NotificationEventsVM> notificationEventsVM { get; set; }
    }
}
