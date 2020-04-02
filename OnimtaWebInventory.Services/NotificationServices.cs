using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.Models;
using OnimtaWebInventory.UnitOfWork;
using SignalRHub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OnimtaWebInventory.Services
{
    public  class NotificationServices : INotificationServices
    {
        private ILogger<NotificationServices> _logger;
        private readonly IUnitOfWork _unitOfWork;


        public string NotificationHeader, NotifcationBody, referenceUserName;

        public int PurchaseOrderNotificationTypeId = 1;

        public NotificationServices(IUnitOfWork unitOfWork, ILogger<NotificationServices> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<NotificationEventsVM> AddNotificationEvents(NotificationEventsVM notificationEventsVM)
        {
            NotificationEventsVM notificationEventsVm = new NotificationEventsVM();
           
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    notificationEventsVm = await  _unitOfWork.NotificationRepository.AddNotificationEvents(notificationEventsVM);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }


            return notificationEventsVm;
        }

        public async Task<NotificationEventsVM> DeleteNotificationEventsDetailByUserId(int userId)
        {
            NotificationEventsVM notificationEventsVM = new NotificationEventsVM();
           
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    notificationEventsVM = await  _unitOfWork.NotificationRepository.DeleteNotificationEventsDetailByUserId(userId);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }


            return notificationEventsVM;
        }

        public async Task<IEnumerable<NotificationEventsVM>> GetNotificationEventDetailsByUserId(int userId)
        {
           IEnumerable <NotificationEventsVM> notificationEventsVM ;
           
            using (_unitOfWork)
            {


                try
                {
                notificationEventsVM = await  _unitOfWork.NotificationRepository.GetNotificationEventDetailsByUserId(userId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
            return notificationEventsVM;
        }

        public async Task<NotificationSettingVM> GetNotificationSetting(int companyId)
        {
            NotificationSettingVM notificationSettingVm = new NotificationSettingVM();
           
            using (_unitOfWork)
            {


                try
                {
                notificationSettingVm = await  _unitOfWork.NotificationRepository.GetNotificationSetting(companyId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
            return notificationSettingVm;
        }

        public async Task<NotificationEventsVM> UpdateNotificationEventsDetailByUserId(int Id ,int IsActive)
        {
            NotificationEventsVM notificationEventsVM = new NotificationEventsVM();
           
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    notificationEventsVM = await  _unitOfWork.NotificationRepository.UpdateNotificationEventsDetailByUserId(Id, IsActive);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }
            return notificationEventsVM;
        }

        public async Task<int> SendNotification(MessageVM messageVm)
        {

            NotificationTypeVM notificationTypeVM = new NotificationTypeVM();
            string userIdList = "";
            bool sendNotification = false;
            try
            {
                using (var client = new HttpClient())
                {

                    ApplicationUserVM applicationUserVM = new ApplicationUserVM();
                    int approvalResponderUserId = messageVm.ReferenceUserId;



                    if (messageVm.NotificationTypeId >= 100)
                    {
                        if (approvalResponderUserId > 0)
                        {
                            ApprovalOfficerVM approvalOfficerVM = new ApprovalOfficerVM();

                            using (_unitOfWork)
                            {


                                try
                                {
                                   
                                    sendNotification = true;
                                approvalOfficerVM = await  _unitOfWork.ApplicationUserRepository.GetApplicationUserDetailsByUserId(approvalResponderUserId);

                                 applicationUserVM.UserID = approvalOfficerVM.userId;
                                 applicationUserVM.Username = approvalOfficerVM.UserName;


                                messageVm.ReferenceUserName = applicationUserVM.Username;
                                this.referenceUserName = applicationUserVM.Username;
                                messageVm.ReferenceUserName = applicationUserVM.Username;

                                    
                                }
                                catch (Exception ex)
                                {
                                    
                                    throw new Exception(ex.Message);

                                }
                            }
                           

                           
                        }
                    }
                    else if (messageVm.NotificationTypeId == 1)
                    {

                        sendNotification = true;
                    }
                    else if (messageVm.NotificationTypeId == 21 || messageVm.NotificationTypeId ==22)
                    {

                        sendNotification = true;
                    }
                    else
                    {
                        notificationTypeVM = await GetNotificationUserIdsByNotificationTypeId(messageVm.NotificationTypeId, messageVm.BranchId, messageVm.TransactionNo, messageVm.ReferenceUserId);
                        if (notificationTypeVM.ApprovalOffcerVM.Count() > 0)
                        {
                            sendNotification = true;
                            string[] OfficersId = new string[notificationTypeVM.ApprovalOffcerVM.Count() + 1];


                            for (int i = 0; i < notificationTypeVM.ApprovalOffcerVM.Count(); i++)
                            {
                                string userID = notificationTypeVM.ApprovalOffcerVM.ElementAt(i).userId.ToString();
                                OfficersId[i] = userID;

                            }
                            userIdList += String.Join(",", OfficersId);
                            messageVm.UserIdList = userIdList;
                        }
                    }


               
                   


                    if (sendNotification)
                    {
                        try
                        {

                            var myContent = JsonConvert.SerializeObject(messageVm);
                            var stringContent = new StringContent(myContent.ToString(), UnicodeEncoding.UTF8, "application/json");
                           //  client.BaseAddress = new Uri("http://localhost:60841/api/");
                            client.BaseAddress = new Uri("http://192.168.1.60:4205/api/");
                           // client.BaseAddress = new Uri("https://onimtanotificationapi.azurewebsites.net/api/");
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                          
                            HttpResponseMessage response = await client.PostAsync("Message/Post", stringContent);
                            if (response.IsSuccessStatusCode)
                            {
                                string result = await response.Content.ReadAsStringAsync();
                            }

                            try
                            {
                                _logger.LogInformation(myContent);
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex.ToString());
                        }
                    }
                
                }
            }
               catch(Exception ex)
               {
                throw new Exception(ex.Message);

            }

            return 0;
        }

        public async Task<NotificationEventsVM> UpdateUserNotificationReadByUserId(int userId)
        {
            NotificationEventsVM notificationEventsVM = new NotificationEventsVM();
          
              
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    notificationEventsVM = await  _unitOfWork.NotificationRepository.UpdateUserNotificationReadByUserId(userId);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }
            return notificationEventsVM;
        }

        public void SetNotificationHeaderDetails(int notificationTypeId, string reference)
        {
            if (notificationTypeId == PurchaseOrderNotificationTypeId)
            {
                this.NotificationHeader = "Purchase Order";
                this.NotifcationBody = "You have a pending approval for" + " " + reference;
            }

            switch (notificationTypeId)
            {
                case 1:
                    this.NotificationHeader = "Purchase Order";
                    this.NotifcationBody = "You have a pending approval for" + " " + reference;
                    break;

                case 100:
                    this.NotificationHeader = "Purchase Order Approved";
                    this.NotifcationBody = "Your purchase order has been approved by " + " "
                      + this.referenceUserName + " Reference No - " + reference;
                    break;


            }
        }

        public async Task<NotificationTypeVM> GetNotificationUserIdsByNotificationTypeId(int notificationTypeId, string branchId,string transactionNo, int userId)
        {
            NotificationTypeVM notificationTypeVM  = new NotificationTypeVM();

           

            using (_unitOfWork)
            {


                try
                {
                notificationTypeVM = await  _unitOfWork.NotificationRepository.GetNotificationUserIdsByNotificationTypeId(notificationTypeId, branchId, transactionNo, userId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

            return notificationTypeVM;
    
}


        public async Task<NotificationTypeVM> updateNotificationTypeDetails(NotificationTypeVM notificationTypeVM)
        {
            NotificationTypeVM notificationTypeVm = new NotificationTypeVM();
           

            
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    notificationTypeVm = await  _unitOfWork.NotificationRepository.updateNotificationTypeDetails(notificationTypeVM);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }

            return notificationTypeVm;
        }

        public async Task<IEnumerable<NotificationTypeVM>> getAllNotificationTypeDetails(int companyId)
        {
            IEnumerable<NotificationTypeVM> NotificationTypeVm;
          
            using (_unitOfWork)
            {


                try
                {
                NotificationTypeVm = await  _unitOfWork.NotificationRepository.getAllNotificationTypeDetails(companyId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

            return NotificationTypeVm;
        }
    }
}


