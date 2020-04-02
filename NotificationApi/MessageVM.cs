//using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRHub
{
    public class MessageVM
    {
        public string Type { get; set; }
        public string Header { get; set; }
        public string Payload { get; set; }
        public string Message { get; set; }
        public string Reference { get; set; }
        public string TransactionNo { get; set; }

        public int    NotificationTypeId { get; set; }
        public int    ReferenceUserId { get; set; }
        public int notificationGroupId { get; set; }
        public string ReferenceUserName { get; set; }
        public bool   BroadCastAll { get; set; }
        public bool   BroadCastSpecificRole { get; set; }
        public bool   BroadCastSpecificUserList { get; set; }
        public string UserIdList { get; set; }
        public string UserRoleList { get; set; }
        public string BranchId { get; set; }



    }
}
