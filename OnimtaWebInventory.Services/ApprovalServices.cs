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
    public class ApprovalServices : IApprovalServices
    {
      
        private readonly INotificationServices _notificationServices;
        private readonly IUnitOfWork _unitOfWork;



        public ApprovalServices( 
              INotificationServices InotificationServices, IUnitOfWork unitOfWork)
        {
           
          
            _notificationServices = InotificationServices;
            _unitOfWork = unitOfWork;
        }
        public async Task<ApprovalVM> AddNewApproveByApprovalId(ApprovalVM approvalVM)
        {
            ApprovalVM approvalVm = new ApprovalVM();
            MessageVM messageVM = new MessageVM();
           
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();

                    approvalVm = await _unitOfWork.ApprovalRepository.AddNewApproveByApprovalId(approvalVM);
                    _unitOfWork.CommitTransaction();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();

                    throw new Exception(ex.Message);
                }
            }

            try
            {
                messageVM.BroadCastAll = false;
                messageVM.BroadCastSpecificRole = false;
                messageVM.BroadCastSpecificUserList = true;
                messageVM.UserIdList = approvalVM.ApprovalOfficersId;
                await _notificationServices.SendNotification(messageVM);
            } catch(Exception ex)
            {

            }
                

           
            return approvalVm;
        }

        public async Task<ApprovalVM> GetApprovalDetailsById(int id, int companyId,int pageId)
        {
            ApprovalVM approvalVM = new ApprovalVM();
           
            
           using (_unitOfWork)
            {

                try
                {
                  approvalVM = await _unitOfWork.ApprovalRepository.GetApprovalDetailsById(id, companyId,pageId);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return approvalVM;
        }

        public async Task<FunctionApprovalTypeVm> GetFunctionApprovalDetailsByFunctionId(int approvalTypeId, int notificationtypeId,string referenceNo,int userId, int companyId)
        {
            FunctionApprovalTypeVm functionApprovalTypeVm = new FunctionApprovalTypeVm();

            ApplicationUserVM applicationUserVM = new ApplicationUserVM();
          
                 
            using (_unitOfWork)
            {

                try
                {
                   
                     functionApprovalTypeVm = await _unitOfWork.ApprovalRepository.GetFunctionApprovalDetailsByFunctionId(approvalTypeId, companyId);
 
                     if (functionApprovalTypeVm.IsActive == 1)
                {

                    ApprovalVM returnapprovalVM = new ApprovalVM();
                    string[] OfficersId = new string[1000];
                    ApprovalVM approvalVM = new ApprovalVM();

                    MessageVM messageVM = new MessageVM();
                                  

                    try
                    {
                        messageVM.BroadCastAll = false;
                        messageVM.BroadCastSpecificUserList = true;
                        messageVM.UserIdList = functionApprovalTypeVm.ApprovalOfficersId;
                        messageVM.NotificationTypeId = notificationtypeId;
                        messageVM.Reference = referenceNo;
                        messageVM.ReferenceUserId = userId;

                        Task taskA = Task.Factory.StartNew(() =>
                               _notificationServices.SendNotification(messageVM)
                           );
                        taskA.Dispose();
                    }
                    catch (Exception ex)
                    {

                    }
                }
                }
                catch (Exception ex)
                {
                  
                    throw new Exception(ex.Message);
                }
            }
            return functionApprovalTypeVm;
        }

        public async Task<ChangeApprovalVM> UpdateApprovalDetailsByFunctionId(int functionId, int companyId, int status)
        {
            ChangeApprovalVM approvalVm = new ChangeApprovalVM();
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();

                    approvalVm = await _unitOfWork.ApprovalRepository.UpdateApprovalDetailsByFunctionId(functionId, companyId, status);
                    _unitOfWork.CommitTransaction();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();

                    throw new Exception(ex.Message);
                }
            }

                  
            return approvalVm;
        }

        public async Task<IEnumerable<ApprovalEventVM>> GetOwnApprovalDetailByUserID(int userID, int companyId, int pageId)
        {
            IEnumerable<ApprovalEventVM>  approvalEventVM;
           
            using (_unitOfWork)
            {


                try
                {
                approvalEventVM = await  _unitOfWork.ApprovalRepository.GetOwnApprovalDetailByUserID(userID, companyId,pageId);

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
            return approvalEventVM;
        }

        public async Task<IEnumerable<FunctionApprovalTypeVm>> GetAllFunctionApprovalDetails()
        {
            IEnumerable<FunctionApprovalTypeVm> functionApprovalTypeVm = new List<FunctionApprovalTypeVm>();
            

            ApprovalOfficerVM applicationUserVM = new ApprovalOfficerVM();
            IEnumerable<ApprovalOfficerVM> approvalOfficers;




            string[] userIdList;

            using (_unitOfWork)
            {


                try
                {
                      functionApprovalTypeVm = await  _unitOfWork.ApprovalRepository.GetAllFunctionApprovalDetails();

                            for (int i = 0; i < functionApprovalTypeVm.Count(); i++)
                            {
                                if(functionApprovalTypeVm.ElementAt(i).ApprovalOfficersId != null)
                                {
                                    userIdList = functionApprovalTypeVm.ElementAt(i).ApprovalOfficersId.Split(",");

                                    List<ApprovalOfficerVM> userList = new List<ApprovalOfficerVM>(150);
                                    for (int y = 0; y < userIdList.Count(); y++)
                                    {
                                        approvalOfficers = new List<ApprovalOfficerVM>
                                    {
                                        await  _unitOfWork.ApplicationUserRepository.GetApplicationUserDetailsByUserId(Convert.ToInt32(userIdList[y]))
                                    };
                                        userList.Add(approvalOfficers.ToList()[0]);
                                        approvalOfficers = null;
                                    }

                                    functionApprovalTypeVm.ElementAt(i).ApprovalOffcerVM = userList;

                                }

                            }
           
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
          
            return functionApprovalTypeVm;
        }

        public async Task<IEnumerable<ApplicationUserVM>> GetApplicationUserDetailsByUserId(int approvalId)
        {
            ApprovalTypeOwnVM approvalTypeOwnVM = new ApprovalTypeOwnVM();
            List<ApplicationUserVM> UserList = new List<ApplicationUserVM>();
            string idList = "";
            string[] approvalOfficerIdList = { };
           
               
            using (_unitOfWork)
            {


                try
                {
                          approvalTypeOwnVM = await  _unitOfWork.ApprovalRepository.GetApprovalOfficerDetailsByApprovalTypeId(approvalId);

                        idList = approvalTypeOwnVM.ApprovalOfficersId.ToString();
                        approvalOfficerIdList = idList.Split(',');
                        for (int i = 0; i < approvalOfficerIdList.Length; i++)
                        {
                            ApplicationUserVM applicationUser = new ApplicationUserVM();

                            applicationUser = await  _unitOfWork.ApprovalRepository.GetApprovalOfficerByUserId(int.Parse(approvalOfficerIdList[i]));
                            if(applicationUser != null)
                            {
                                UserList.Add(applicationUser);
                            }
                    
                        }
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }

            return UserList.AsEnumerable();
        }

        public async Task<ApprovalTypeOwnVM> UpdateApprovalOfficerDetailsByApprovalTypeId(int approvalTypeId, string approvalOfficerIdList, int companyId)
        {
           

            ApprovalTypeOwnVM approvalTypeOwnVM = new ApprovalTypeOwnVM();
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();

                    approvalTypeOwnVM = await  _unitOfWork.ApprovalRepository.UpdateApprovalOfficerDetailsByApprovalTypeId(approvalTypeId, approvalOfficerIdList, companyId);
                    _unitOfWork.CommitTransaction();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();

                    throw new Exception(ex.Message);
                }
            }

                   
            return approvalTypeOwnVM;
        }

        public async Task<ApprovalVM> AddNewApprovalDetails(ApprovalVM approvalVM)
        {
            ApprovalVM approvalVm = new ApprovalVM();
          
            using (_unitOfWork)
            {


                try
                {
                    //_unitOfWork.BeginTransaction();

                    approvalVm = await  _unitOfWork.ApprovalRepository.AddNewApprovalDetails(approvalVM);
                    //_unitOfWork.CommitTransaction();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();

                    throw new Exception(ex.Message);
                }
            }
            return approvalVm;
        }

        public async Task<IEnumerable<ApprovalEventVM>> GetAllApprovalEventsByUserId(int userId, int pageId)
        {
            IEnumerable<ApprovalEventVM> approvalEventVM;

           
             
            using (_unitOfWork)
            {

                try
                {
                     approvalEventVM = await  _unitOfWork.ApprovalRepository.GetAllApprovalEventsByUserId(userId,pageId);
                     approvalEventVM.GroupBy(m => m.ApprovalTaskId).Select(y=>y.First());
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
            return approvalEventVM;
        }

        public async Task<ApprovalEventVM> AddNewApprovalEventDetails(ApprovalEventVM approvalEventVM)
        {
            ApprovalEventVM approvalEventVm = new ApprovalEventVM();

            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    approvalEventVm = await  _unitOfWork.ApprovalRepository.AddNewApprovalEventDetails(approvalEventVM);
                   _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }

            return approvalEventVm;
        }

        public async Task<ApprovalResponseVM> UpdateApprovalRejectOrAcceptByTaskId(ApprovalResponseVM approvalResponseVM)
        {
            ApprovalResponseVM approvalReturnResponseVM = new ApprovalResponseVM();
            FunctionApprovalTypeVm functionApprovalTypeVm = new FunctionApprovalTypeVm();

            MessageVM messageVM = new MessageVM();

           

            using (_unitOfWork)
            {

                try
                {
                    _unitOfWork.BeginTransaction();

                    approvalReturnResponseVM = await  _unitOfWork.ApprovalRepository.UpdateApprovalRejectOrAcceptByTaskId(approvalResponseVM);
                    _unitOfWork.CommitTransaction();

                    try
                    {
                    messageVM.BroadCastAll = false;
                    messageVM.BroadCastSpecificRole = false;
                    messageVM.BroadCastSpecificUserList = true;
                    messageVM.UserIdList = approvalResponseVM.ApprovalOwnerUserId.ToString();
                    messageVM.NotificationTypeId = approvalResponseVM.NotificationTypeId;
                    messageVM.Reference = approvalResponseVM.ReferenceNo;
                    messageVM.ReferenceUserId = approvalResponseVM.UserId;


                    await _notificationServices.SendNotification(messageVM);

                }
                catch (Exception ex)
                {

                }
            
            }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();

                    throw new Exception(ex.Message);
                }
            }


            return approvalResponseVM;
        }

       
    }
}
