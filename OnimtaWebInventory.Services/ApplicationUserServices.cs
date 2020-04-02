using Dapper;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Newtonsoft.Json;
using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.Models;
using OnimtaWebInventory.UnitOfWork;
using SignalRHub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OnimtaWebInventory.Services
{
    public class ApplicationUserServices : IApplicationUserServices
    {
            IUnitOfWork _unitOfWork ;


        public ApplicationUserServices( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApplicationPageVM> AddNewApplicationPages(ApplicationPageVM applicationPageVM)
        {
            ApplicationPageVM applicationPageVm = new ApplicationPageVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    applicationPageVm = await _unitOfWork.ApplicationUserRepository.AddNewApplicationPages(applicationPageVM);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return applicationPageVM;
        }
        
        public async Task<ApplicationUserVM> AddNewApplicationUserDetails(ApplicationUserVM applicationUserVM)
        {
            ApplicationUserVM applicationUserVm = new ApplicationUserVM();
            FunctionApprovalTypeVm functionApprovalTypeVm = new FunctionApprovalTypeVm();
            ApprovalVM approvalVM = new ApprovalVM();
            ApprovalVM returnapprovalVM = new ApprovalVM();
            int UserCreationApprovalTypeId = 4;
            int createdUserId = applicationUserVM.UserID;
            MessageVM messageVM = new MessageVM();
            string[] OfficersId = new string[1000];

            using (_unitOfWork)
            {

                try
                {
                    _unitOfWork.BeginTransaction();
                
                    /* Perform transactional work here */
                    applicationUserVm = await _unitOfWork.ApplicationUserRepository.AddNewApplicationUserDetails(applicationUserVM);

                    // check Approval is Active or not
                    if (functionApprovalTypeVm.IsActive == 1)
                    {
                        approvalVM.ApprovalTypeId = UserCreationApprovalTypeId;
                        approvalVM.ReferenceNo = applicationUserVm.Username;
                        approvalVM.CreatedUserId = createdUserId;

                        // insert Approval details to Approval Task table and get the task ID  
                        //  returnapprovalVM = await _approvalServices.AddNewApprovalDetails(approvalVM);
       
                        // Assign approval officers UserId to an array
                        OfficersId = functionApprovalTypeVm.ApprovalOfficersId.Split(",");

                        for (int i = 0; i < OfficersId.Count(); i++)
                        {
                            int A = Convert.ToInt32(OfficersId[i]);
                            ApprovalEventVM approvalEventVM = new ApprovalEventVM();
                            approvalEventVM.ApprovalTaskId = returnapprovalVM.ApprovalTaskId;
                            approvalEventVM.CreatedUserId = createdUserId;
                            approvalEventVM.ReferenceNo = applicationUserVm.Username;
                            approvalEventVM.ApprovalTypeId = UserCreationApprovalTypeId;
                            approvalEventVM.UserId = Convert.ToInt32(OfficersId[i]);

                            // insert Approval details to Approval Events table against ApprovalUserId userId
                            // approvalEventVM = await _approvalServices.AddNewApprovalEventDetails(approvalEventVM);

                        }
                    }

                    try
                    {
                        messageVM.BroadCastAll = false;
                        messageVM.BroadCastSpecificUserList = true;
                        messageVM.UserIdList = functionApprovalTypeVm.ApprovalOfficersId;
                        messageVM.NotificationTypeId = UserCreationApprovalTypeId;
                        messageVM.Reference = applicationUserVm.Username;
                        messageVM.ReferenceUserId = createdUserId;

                        //  await _notificationServices.SendNotification(messageVM);
                    }
                    catch (Exception ex)
                    {

                    }
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return applicationUserVM;
        }

        public async Task<IEnumerable<ApplicationUserVM>> GetAllApplicationUserDetails(int companyId)
        {
            IEnumerable<ApplicationUserVM> applicationUserVM;
            using (_unitOfWork)
            {
                try
                {
                    applicationUserVM = await _unitOfWork.ApplicationUserRepository.GetAllApplicationUserDetails(companyId);
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
            return applicationUserVM;
        }

        public async Task<IEnumerable<ApplicationPageTreeVm>> GetApplicationPageDetails(int companyId)
        {
           IEnumerable <ApplicationPageTreeVm> applicationPageTreeVm;
            
            using (_unitOfWork)
            {
                try
                {
                         applicationPageTreeVm = await _unitOfWork.ApplicationUserRepository.GetApplicationPageDetails(companyId);

                        IEnumerable<ApplicationPageTreeChildrenVm> applicationPageTreeChildrenVm = new List<ApplicationPageTreeChildrenVm>
                        {
                            new ApplicationPageTreeChildrenVm(){Id =1,Data = 1, ExpandedIcon ="fa fa-folder-open" ,Label ="View", CollapsedIcon="fa fa-folder"},
                            new ApplicationPageTreeChildrenVm(){Id =2,Data = 2, ExpandedIcon ="fa fa-folder-open" ,Label ="Add", CollapsedIcon="fa fa-folder"},
                            new ApplicationPageTreeChildrenVm(){Id =3,Data = 3, ExpandedIcon ="fa fa-folder-open" ,Label ="Update", CollapsedIcon="fa fa-folder"},
                            new ApplicationPageTreeChildrenVm(){Id =4,Data = 4, ExpandedIcon ="fa fa-folder-open" ,Label ="Delete", CollapsedIcon="fa fa-folder"}

                        };

                            for (int i = 0; i < applicationPageTreeVm.Count(); i++)
                            {
                                applicationPageTreeVm.ElementAt(i).Children = applicationPageTreeChildrenVm;
                            }
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }

             }
            return applicationPageTreeVm;
        }

        public async Task<IEnumerable<ApplicationPageVM>> GetApplicationPagesByUserId(int userId,int companyId)
        {
            IEnumerable<ApplicationPageVM> applicationPageVM;
            using (_unitOfWork)
            {
                try
                {
                applicationPageVM = await _unitOfWork.ApplicationUserRepository.GetApplicationPagesByUserId(userId, companyId);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return applicationPageVM;
        }

        public async Task<IEnumerable<ApplicationPageVM>> GetApplicationPageSummery(int companyId,int PageId)
        {
            IEnumerable<ApplicationPageVM> applicationPageVM;
            using (_unitOfWork)
            {
                try
                {
                applicationPageVM = await _unitOfWork.ApplicationUserRepository.GetApplicationPageSummery(companyId ,PageId);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return applicationPageVM;
        }


        public async Task<ApplicationUserVM> GetApplicationUserDetails(string userName, string password)
        {
            ApplicationUserVM applicationUserVM = new ApplicationUserVM();
            IEnumerable<ApplicationPageVM> applicationPagesSummery;
            IEnumerable<ApplicationPageVM> userApplicationPages;
            IEnumerable<MenuModel> menuModel; ;

            int userRoleId = 0;
            int defaultPageId = 0;

            using (_unitOfWork)
            {
                try
                {
                    applicationUserVM = await _unitOfWork.ApplicationUserRepository.GetApplicationUserDetails(userName, password);
                    userRoleId = applicationUserVM.RoleId;
                    applicationPagesSummery =  await _unitOfWork.ApplicationUserRepository.GetApplicationPageSummery(1, defaultPageId);
                    userApplicationPages = await _unitOfWork.ApplicationUserRepository.GetApplicationPageDetailsByUserRoleId(userRoleId);
                    menuModel = await _unitOfWork.MenuRepository.GetMenuModelDetailsByUserRoleId(1, userRoleId);


                     for(int i =0;i< userApplicationPages.Count();i++)
                {
                    for (int x = 0; x < menuModel.Count(); x++)
                    {
                            if(userApplicationPages.ElementAt(i).PageId == menuModel.ElementAt(x).Id)
                        {
                             
                                  
                        } else
                        {
                            menuModel.ToList().RemoveAt(x);
                        }
                    }
                }

                     if(userApplicationPages.Count()>0)
                {
                    applicationUserVM.applicationPageVM = userApplicationPages;
                }

                    if (menuModel.Count() > 0)
                {
                    applicationUserVM.menuModel = menuModel;
                }

                    try
                {
                    int UserLogInEmailTemplateTypeId = 1;
                   
                    EmailVM emailVM = new EmailVM();
                    emailVM.TemplateTypeId = UserLogInEmailTemplateTypeId;
                    emailVM.ToEmail = applicationUserVM.Email;
                    emailVM.Subject = "User Log In - " + userName;
                    emailVM.Reference3 = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                   // Task taskA = Task.Factory.StartNew(() => _emailServices.SendEmail(emailVM));
                  //  taskA.Dispose();
                  

                } catch(Exception ex)
                {
                }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            } 
            return applicationUserVM;
        }

        public async Task<ApplicationUserVM> GetRefreshToken(string userName, string password)
        {
            ApplicationUserVM applicationUserVM = new ApplicationUserVM();
            using (_unitOfWork)
            {

                try
                {
                    applicationUserVM = await _unitOfWork.ApplicationUserRepository.GetApplicationUserDetails(userName, password);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return applicationUserVM;
        }


        public async Task<ApplicationUserVM> GetDetailedApplicationUserInfoByUserId(int userId)
        {
            ApplicationUserVM applicationUserVM = new ApplicationUserVM();

            using (_unitOfWork)
            {
                try
                {
                   applicationUserVM = await _unitOfWork.ApplicationUserRepository.GetDetailedApplicationUserInfoByUserId(userId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return applicationUserVM;
        }

        public async Task<ApplicationUserVM> GetApplicationUserDetailsByUserId(int userId)
        {
            ApplicationUserVM applicationUserVM = new ApplicationUserVM();
            ApprovalOfficerVM approvalOfficerVM  =  new ApprovalOfficerVM();

            using (_unitOfWork)
            {
                try
                {
                    approvalOfficerVM = await _unitOfWork.ApplicationUserRepository.GetApplicationUserDetailsByUserId(userId);
                    applicationUserVM.UserID = approvalOfficerVM.userId;
                    applicationUserVM.Username = approvalOfficerVM.UserName;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return applicationUserVM;
        }

        public async Task<ApplicationUserVM> UpdateApplicationUserDetails(ApplicationUserVM applicationUserVM)
        {
            ApplicationUserVM applicationUserVm = new ApplicationUserVM();
           
                    /* Perform transactional work here */
            using (_unitOfWork)
            {
                try
                {
                    applicationUserVM = await _unitOfWork.ApplicationUserRepository.UpdateApplicationUserDetails(applicationUserVM);
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
            return applicationUserVM;
        }

        public async Task<ApplicationUserVM> UserLogOut(int userId)
        {
            ApplicationUserVM applicationUserVM = new ApplicationUserVM();

            using (_unitOfWork)
            {
                try
                {
                   applicationUserVM = await _unitOfWork.ApplicationUserRepository.UserLogOut(userId);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return applicationUserVM;
        }

        public async Task<ApplicationUserBranchVM> AddNewUserBranchDetails(ApplicationUserBranchVM applicationUserBranchVM)
        {
            ApplicationUserBranchVM applicationUserBranchVm = new ApplicationUserBranchVM();
            using (_unitOfWork)
            {
                try
                {
                    applicationUserBranchVM = await _unitOfWork.ApplicationUserRepository.AddNewUserBranchDetails(applicationUserBranchVM);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return applicationUserBranchVM;
        }

        public async Task<UserBranchVm> UpdateUserBranchDetailsByBusinessProcessId(UserBranchVm userBranchVm)
        {
            UserBranchVm userBranch = new UserBranchVm();
            
            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    userBranch = await _unitOfWork.ApplicationUserRepository.UpdateUserBranchDetailsByBusinessProcessId(userBranchVm);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return userBranch;
        }

        public async Task<UserCommentVM> AddUserCommentDetails(UserCommentVM userCommentVM)
        {
            UserCommentVM userCommentVm = new UserCommentVM();
           
            using (_unitOfWork)
            {
                try
                {
                    userCommentVM = await _unitOfWork.ApplicationUserRepository.AddUserCommentDetails(userCommentVM);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return userCommentVM;
        }

        public async Task<IEnumerable<UserCommentVM>> GetUserCommmentDetails()
        {
            IEnumerable<UserCommentVM> userCommentVM;
            using (_unitOfWork)
            {
                try
                {
                    userCommentVM = await _unitOfWork.ApplicationUserRepository.GetUserCommmentDetails();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return userCommentVM;
        }
    }
}
