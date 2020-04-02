using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
//using OnimtaWebInventory.Models;
using SignalRHub;

namespace NotificationApi.Controllers
{

    [Route("api/[controller]/[action]")]
    [DisableCors]
    public class MessageController : Controller
    {
        private IHubContext<NotifyHub, ITypedHubClient> _hubContext;
        public string NotificationHeader, NotifcationBody;
        public bool BroadCastAll, BroadCastUserList, BroadCastUserRoleList;
        public int referenceUserId ,notificationGroupId ;
        public string referenceUserName;


        public int ApprovalnotificationGroupId = 1;


        public MessageController (IHubContext<NotifyHub, ITypedHubClient> hubContext)
        {   
            _hubContext = hubContext;
      
        }
       
        [HttpPost]
        [DisableCors]
        public async Task<string> Post([FromBody]MessageVM msg)
        {
            string returnMessage = string.Empty;
            try
            {

                //////////// to be removed
                this.BroadCastAll = true;
                //////////
                this.referenceUserName = msg.ReferenceUserName;
                await this.SetNotificationHeaderDetails(msg.NotificationTypeId, msg.Reference);

                msg.Header = this.NotificationHeader;
                msg.Payload = this.NotifcationBody;
                msg.notificationGroupId = this.notificationGroupId;
                msg.BroadCastSpecificUserList = this.BroadCastUserList;
                msg.BroadCastAll = this.BroadCastAll;


                await _hubContext.Clients.All.BroadcastMessage(msg);
                await _hubContext.Clients.User("5").BroadcastMessage(msg);
                returnMessage = msg.Header + " |  " + msg.Payload +" | " + msg.BroadCastSpecificUserList.ToString();
            }
            catch (Exception e)
            {
                returnMessage = e.ToString();
            }
            return returnMessage;
        }

        [HttpGet]
        public Task SendMessageToUser()
        {
            MessageVM messageVM = new MessageVM();
            return null;
          //  return _hubContext.Clients.Client(connectionId).BroadcastMessage(messageVM);
        }
        [HttpPut]
        public async Task< int> SetNotificationHeaderDetails(int notificationTypeId,string reference)
        {
           
            switch (notificationTypeId)
            {
                case 1:
                    this.NotificationHeader = "Purchase Order";
                    this.NotifcationBody = "You have a pending approval for" + " " + reference;

                    this.BroadCastUserList = true;
                    break;

                case 2:
                    this.NotificationHeader = "Stock Tranfer";
                    this.NotifcationBody = "Stock Transfer has been taken placed Transfer No -" + " " + reference;
                    this.BroadCastUserList = true;

                    break;

                case 3:
                    this.NotificationHeader = "Stock Adjusment";
                    this.NotifcationBody = "Stock Adjusment has been taken placed Adjusment No -" + " " + reference;
                    this.BroadCastUserList = true;

                    break;

                case 4:
                    this.NotificationHeader = "User ";
                    this.NotifcationBody = "You have a pending approval for" + " " + reference;
                    this.BroadCastUserList = true;

                    break;

                case 5:
                    this.NotificationHeader = "Purchase Order Fully Recieve ";
                    this.NotifcationBody = "A purchase order has been fully recieved Purchase No -" + " " + reference;
                    this.BroadCastUserList = true;

                    break;

                case 6:
                    this.NotificationHeader = "Purchase Order Partially Recieve ";
                    this.NotifcationBody = "A purchase order has been partially recieved Purchase No -" + " " + reference;
                    this.BroadCastUserList = true;

                    break;

                case 7:
                    this.NotificationHeader = "Purchase Order Bill  ";
                    this.NotifcationBody = "A purchase order has been billed Bill No -" + " " + reference;
                    this.BroadCastUserList = true;

                    break;

                case 8:
                    this.NotificationHeader = "Purchase Order Payement  ";
                    this.NotifcationBody = "A has been done" + " " + reference;
                    this.BroadCastUserList = true;

                    break;

                case 9:
                    this.NotificationHeader = "Stock Adjusment Approval";
                    this.NotifcationBody = "You have a pending approval for " + " " + reference;
                    this.BroadCastUserList = true;

                    break;

                case 10:
                    this.NotificationHeader = "Purchase Order Cancelation";
                    this.NotifcationBody = "A purchase order has been cancelled Reference No- " + " " + reference;
                    this.BroadCastUserList = true;

                    break;

                case 11:
                    this.NotificationHeader = "Stock Transfer Cancelation";
                    this.NotifcationBody = "A stock transfer has been cancelled Reference No- " + " " + reference;
                    this.BroadCastUserList = true;

                    break;

                case 12:
                    this.NotificationHeader = "Stock Adjusment Cancelation";
                    this.NotifcationBody = "A stock adjusment has been cancelled Reference No- " + " " + reference;
                    this.BroadCastUserList = true;

                    break;
                case 13:
                    this.NotificationHeader = "Supplier Payement Cancelation";
                    this.NotifcationBody = "A supplier Payement has been cancelled Reference No- " + " " + reference;
                    this.BroadCastUserList = true;

                    break;

                case 14:
                    this.NotificationHeader = "Customer Payement Cancelation";
                    this.NotifcationBody = "A customet Payement has been cancelled Reference No- " + " " + reference;
                    this.BroadCastUserList = true;

                    break;

                case 20:
                    this.NotificationHeader = "Purchase Order Request";
                    this.NotifcationBody = "New Purchase Order Request " + " " + reference;
                    this.BroadCastUserList = true;

                    break;

                case 21:
                    this.NotificationHeader = "Sales Order Quatation";
                    this.NotifcationBody = "You have a pending approval for sales order quatation Rreference No- " + " " + reference;
                    this.BroadCastUserList = true;

                    break;
                case 22:
                    this.NotificationHeader = "Sales Order";
                    this.NotifcationBody = "You have a pending approval for sales order Rreference No- " + " " + reference;
                    this.BroadCastUserList = true;

                    break;
                case 23:
                    this.NotificationHeader = "Sales Invoice";
                    this.NotifcationBody = "You have a pending approval for sales invoice Rreference No- " + " " + reference;
                    this.BroadCastUserList = true;

                    break;

                case 30:
                    this.NotificationHeader = "Supplier Payment";
                    this.NotifcationBody = "A supplier Payment has been made" + " " + reference;
                    this.BroadCastUserList = true;

                    break;

                case 31:
                    this.NotificationHeader = "Customer Payment";
                    this.NotifcationBody = "A Customer Payment has been made" + " " + reference;
                    this.BroadCastUserList = true;

                    break;


                case 100:
                    this.NotificationHeader = "Purchase Order Approved";
                    this.notificationGroupId = this.ApprovalnotificationGroupId;
                    this.NotifcationBody = "Your purchase order has been approved by " + " "
                      + this.referenceUserName + " Purchase No - "+reference;
                    this.BroadCastUserList = true;

                    break;
                case 101:
                    this.NotificationHeader = "Purchase Order Rejected";
                    this.notificationGroupId = this.ApprovalnotificationGroupId;
                    this.NotifcationBody = "Your purchase order has been rejected by " + " "
                      + this.referenceUserName + " Purchase No - " + reference;
                    this.BroadCastUserList = true;

                    break;

                case 102:
                    this.NotificationHeader = "Stock Adjusment Approved";
                    this.notificationGroupId = this.ApprovalnotificationGroupId;
                    this.NotifcationBody = "Your stock adjusment has been approved by " + " "
                      + this.referenceUserName + " Adjusment No - " + reference;
                    this.BroadCastUserList = true;

                    break;
                case 103:
                    this.NotificationHeader = "Stock Adjusment Rejected";
                    this.notificationGroupId = this.ApprovalnotificationGroupId;
                    this.NotifcationBody = "Your stock adjusment has been rejected by " + " "
                      + this.referenceUserName + " Adjusment No - " + reference;
                    this.BroadCastUserList = true;

                    break;

                case 104:
                    this.NotificationHeader = "Sales Order Approved";
                    this.notificationGroupId = this.ApprovalnotificationGroupId;
                    this.NotifcationBody = "Your sales order has been approved by " + " "
                      + this.referenceUserName + " Sales No - " + reference;
                    this.BroadCastUserList = true;

                    break;
                case 105:
                    this.NotificationHeader = "Sales Order Rejected";
                    this.notificationGroupId = this.ApprovalnotificationGroupId;
                    this.NotifcationBody = "Your sales order has been rejected by " + " "
                      + this.referenceUserName + " Adjusment No - " + reference;
                    this.BroadCastUserList = true;

                    break;
                case 106:
                    this.NotificationHeader = "Sales Quatation Approved";
                    this.notificationGroupId = this.ApprovalnotificationGroupId;
                    this.NotifcationBody = "Your sales quatation order has been approved by " + " "
                      + this.referenceUserName + " Quatation No - " + reference;
                    this.BroadCastUserList = true;

                    break;
                case 107:
                    this.NotificationHeader = "Sales Quatation Rejected";
                    this.notificationGroupId = this.ApprovalnotificationGroupId;
                    this.NotifcationBody = "Your sales quatation has been rejected by " + " "
                      + this.referenceUserName + " Quatation No - " + reference;
                    this.BroadCastUserList = true;

                    break;


            }

            return  0;
        }

        [HttpPost]
        [DisableCors]
        public async Task<string> JethroAttendance([FromBody]MessageVM msg)
        {
            string returnMessage = string.Empty;
            try
            {

               


                await _hubContext.Clients.All.BroadcastMessage(msg);
            }
            catch (Exception e)
            {
                returnMessage = e.ToString();
            }
            return returnMessage;
        }


    }
}