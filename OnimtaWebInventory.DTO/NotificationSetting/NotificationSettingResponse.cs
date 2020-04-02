using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.NotificationSetting
{
    public class NotificationSettingResponse:BaseResponse
    {
        public IEnumerable<NotificationSettingVM> notificationSettingVM { get; set; }

    }
}
