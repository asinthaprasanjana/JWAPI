using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.NotificationType
{
    public class NotificationTypeResponse : BaseResponse
    {
        public NotificationTypeVM NotificationTypeVM { get; set; }
        public IEnumerable<NotificationTypeVM> NotificationTypeVMs { get; set; }
    }
}
