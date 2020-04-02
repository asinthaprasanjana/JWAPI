using Dapper;
using DBConnect;
using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Repository
{
    public class ApplicationUserRepository : DBContext, IApplicationUserRepository
    {
      
        public async Task<ApplicationUserVM> GetApplicationUserDetails( string userName, string password)
        {
            ApplicationUserVM applicationUserVM = new ApplicationUserVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@UserName", userName);
                dynamicParameterlist.Add("@Password", password);

                applicationUserVM = await dbConnection.QuerySingleOrDefaultAsync<ApplicationUserVM>("msd.GetApplicationUserDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return applicationUserVM;
        }

        public async Task<IEnumerable<ApplicationPageTreeVm>> GetApplicationPageDetails(int companyId)
        {
            try
            {
                IEnumerable<ApplicationPageTreeVm> applicationPageTreeVm;
                var dynamicParameterlist = new DynamicParameters(companyId);
                applicationPageTreeVm = await dbConnection.QueryAsync<ApplicationPageTreeVm>("msd.GetApplicationPageDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                return applicationPageTreeVm;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ApplicationPageVM>> GetApplicationPageDetailsByUserRoleId(int userRoleId)
        {
            try
            {
                IEnumerable<ApplicationPageVM> applicationPageVM ;
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@UserRoleId", userRoleId);
                applicationPageVM = await dbConnection.QueryAsync<ApplicationPageVM>("msd.GetApplicationPageDetailsByUserRoleId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                return applicationPageVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<IEnumerable<ApplicationPageVM>> GetApplicationPagesByUserId(int userId, int companyId)
        {
            IEnumerable<ApplicationPageVM> applicationPageVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@userId", userId);
                dynamicParameterlist.Add("@companyId", companyId);
                applicationPageVM = await dbConnection.QueryAsync<ApplicationPageVM>("[msd].[GetApplicationPagesByUserId]",dynamicParameterlist,commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return applicationPageVM;
        }

        public async Task<ApplicationUserVM> AddNewApplicationUserDetails(ApplicationUserVM applicationUserVM)
        {
            ApplicationUserVM applicationUserVm = new ApplicationUserVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@roleId",applicationUserVM.RoleId);
                dynamicParameterlist.Add("@userID", applicationUserVM.UserID);
                dynamicParameterlist.Add("@Branch", applicationUserVM.Branch);
                dynamicParameterlist.Add("@UserName", applicationUserVM.Username);
                dynamicParameterlist.Add("@Token", applicationUserVM.Token);
                dynamicParameterlist.Add("@password", applicationUserVM.newPassword);
                dynamicParameterlist.Add("@CompanyId", applicationUserVM.CompanyId);
                dynamicParameterlist.Add("@FirstName", applicationUserVM.FirstName);
                dynamicParameterlist.Add("@LastName", applicationUserVM.LastName);
                dynamicParameterlist.Add("@NicNo", applicationUserVM.NicNo);
                dynamicParameterlist.Add("@BirthDay", applicationUserVM.Birthday);
                dynamicParameterlist.Add("@MobileNo", applicationUserVM.MobileNo);
                dynamicParameterlist.Add("@Email", applicationUserVM.Email);
                dynamicParameterlist.Add("@roleName", applicationUserVM.RoleName);
                dynamicParameterlist.Add("@Address", applicationUserVM.Address);

                applicationUserVM = await dbConnection.QuerySingleOrDefaultAsync<ApplicationUserVM>("msd.AddApplicationUserDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return applicationUserVM;
        }

        public async Task<ApplicationUserVM> UpdateApplicationUserDetails(ApplicationUserVM applicationUserVM)
        {
            ApplicationUserVM applicationUserVm = new ApplicationUserVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@UserId", applicationUserVM.UserID);
                dynamicParameterlist.Add("@RoleId", applicationUserVM.RoleId);

                dynamicParameterlist.Add("@FirstName", applicationUserVM.FirstName);
                dynamicParameterlist.Add("@LastName", applicationUserVM.LastName);
                dynamicParameterlist.Add("@NIC", applicationUserVM.NicNo);
                dynamicParameterlist.Add("@Birthday", applicationUserVM.Birthday);
                dynamicParameterlist.Add("@MobileNo", applicationUserVM.MobileNo);
                dynamicParameterlist.Add("@Address", applicationUserVM.Address);
                dynamicParameterlist.Add("@Email", applicationUserVM.Email);

                dynamicParameterlist.Add("@UserName", applicationUserVM.Username);

                applicationUserVM = await dbConnection.QuerySingleOrDefaultAsync<ApplicationUserVM>("usm.UpdateApplicationUser", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return applicationUserVM;
        }

        public async Task<IEnumerable<ApplicationPageVM>> GetApplicationPageSummery(int companyId,int PageId)
        {
            try
            {
                IEnumerable<ApplicationPageVM> applicationPagevm;
                var dynamicParameterlist = new DynamicParameters();
                applicationPagevm = await dbConnection.QueryAsync<ApplicationPageVM>("msd.GetApplicationPageDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                return applicationPagevm;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<ApplicationPageVM> AddNewApplicationPages(ApplicationPageVM applicationPageVM)
        {
            ApplicationPageVM applicationPageVm = new ApplicationPageVM();
            try
            {
                var dynamicParam = new DynamicParameters();
                dynamicParam.Add("@PageName", applicationPageVM.PageName);
                dynamicParam.Add("@IsMainMenu", applicationPageVM.IsMainMenu);
                dynamicParam.Add("@RouterLink", applicationPageVM.RouterLink);
                dynamicParam.Add("@MainMenuId", applicationPageVM.MainMenuId);
                dynamicParam.Add("@PriorityNo", applicationPageVM.PriorityNo);
                dynamicParam.Add("@IsActive", applicationPageVM.IsActive);
                dynamicParam.Add("@Icon", applicationPageVM.Icon);
                dynamicParam.Add("@ExpirationDate", applicationPageVM.ExpirationDate);

                applicationPageVm = await dbConnection.QuerySingleOrDefaultAsync<ApplicationPageVM>("msd.AddNewApplicationPages", dynamicParam, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return applicationPageVm;
        }

        public async Task<IEnumerable<ApplicationUserVM>> GetAllApplicationUserDetails(int companyId)
        {
            IEnumerable<ApplicationUserVM> applicationUserVm;
            try
            {
               var dynamicParameterlist = new DynamicParameters(companyId);
                applicationUserVm = await dbConnection.QueryAsync<ApplicationUserVM>("msd.GetAllApplicationUserDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return applicationUserVm;
        }
        

        public async Task<ApplicationUserVM> GetDetailedApplicationUserInfoByUserId(int userId)
        {
            ApplicationUserVM approvalOfficerVM = new ApplicationUserVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@UserId", userId);
                approvalOfficerVM = await dbConnection.QuerySingleOrDefaultAsync<ApplicationUserVM>("msd.GetApplicationUserDetailsById", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return approvalOfficerVM;
        }

        public async Task<ApplicationUserVM> GetApplicationUserPassByUserName(string userName)
        {
            ApplicationUserVM applicationUserVM = new ApplicationUserVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@UserName", userName);
                applicationUserVM = await dbConnection.QuerySingleOrDefaultAsync<ApplicationUserVM>("usm.GetApplicationUserDetailsByUserName", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return applicationUserVM;
        }

        public async Task<ApprovalOfficerVM> GetApplicationUserDetailsByUserId(int userId)
        {
            ApprovalOfficerVM approvalOfficerVM = new ApprovalOfficerVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@UserId", userId);
                approvalOfficerVM = await dbConnection.QuerySingleOrDefaultAsync<ApprovalOfficerVM>("msd.GetApplicationUserDetailsById", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return approvalOfficerVM;
        }

        public async Task<ApplicationUserVM> UserLogOut(int userId)
        {
            ApplicationUserVM applicationUserVM = new ApplicationUserVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@UserId", userId);
                applicationUserVM = await dbConnection.QuerySingleOrDefaultAsync<ApplicationUserVM>("msd.UserLogOut", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return applicationUserVM;
        }

        public async Task<ApplicationUserBranchVM> AddNewUserBranchDetails(ApplicationUserBranchVM applicationUserBranchVM)
        {
            ApplicationUserBranchVM applicationUserBranchVm = new ApplicationUserBranchVM();

            try
            {
                var dynamicParamterlist = new DynamicParameters();
                dynamicParamterlist.AddDynamicParams(applicationUserBranchVM);
                applicationUserBranchVM = await dbConnection.QuerySingleOrDefaultAsync<ApplicationUserBranchVM>("msd.AddNewUserBranchDetails", dynamicParamterlist, _transaction, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return applicationUserBranchVM;
        }

        public async Task<UserBranchVm> UpdateUserBranchDetailsByBusinessProcessId(UserBranchVm userBranchVm)
        {
            UserBranchVm userBranch = new UserBranchVm();
            try
            {
                var dynamicParamterlist = new DynamicParameters();
                dynamicParamterlist.Add("@BusinessProcessId", userBranchVm.BusinessProcessId);
                dynamicParamterlist.Add("@UserId", userBranchVm.UserId);
                dynamicParamterlist.Add("@Branches", userBranchVm.Branches);
                dynamicParamterlist.Add("@LastModifiedUserId", userBranchVm.LastModifiedUserId);
                userBranch = await dbConnection.QuerySingleOrDefaultAsync<UserBranchVm>("msd.UpdateUserBranchDetailsByBusinessProcessId", dynamicParamterlist,_transaction, commandType: CommandType.StoredProcedure);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return userBranch;
        }

        public async Task<UserCommentVM> AddUserCommentDetails(UserCommentVM userCommentVM)
        {
            UserCommentVM userCommentVm = new UserCommentVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.AddDynamicParams(userCommentVM);
                userCommentVM = await dbConnection.QuerySingleOrDefaultAsync<UserCommentVM>("msd.AddUserCommentDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return userCommentVM;
        }

        public async Task<IEnumerable<UserCommentVM>> GetUserCommmentDetails()
        {
            IEnumerable<UserCommentVM> userCommentVM ;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                userCommentVM = await dbConnection.QueryAsync<UserCommentVM>("msd.GetUserCommmentDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return userCommentVM;
        }
    }
}