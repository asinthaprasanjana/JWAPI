using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Notification
{
  public  class NotificationRequest : BaseRequest
    { 
        public NotificationVM notificationVM { get; set; }
    }

    public class NotificationEventsRequest : BaseRequest
    {
        public NotificationEventsVM notificationEventsVM { get; set; }
    }
}
