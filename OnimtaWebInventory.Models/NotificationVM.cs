using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
    public class NotificationVM
    {
        public int UserId { get; set; }
        public string NotificationMsg { get; set; }
        public int CompanyId { get; set; }
    }
}
