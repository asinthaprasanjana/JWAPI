using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.NotificationType
{
    public class NotificationTypeRequest : BaseRequest
    {
        public NotificationTypeVM NotificationTypeVM { get; set; }
    }
}
