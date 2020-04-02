using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
 public  class NotificationSettingVM
    {

        public int NotificationId { get; set; }
        public int CompanyId { get; set; }
        public string NotificationName { get; set; }
        public int status { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDateTime { get; set; }

    }
}
