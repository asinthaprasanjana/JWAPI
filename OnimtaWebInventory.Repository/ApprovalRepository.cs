using Dapper;
using DBConnect;
using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Repository
{
    public class ApprovalRepository : DBContext, IApprovalRepository
    {
        public async Task<ApprovalVM> AddNewApproveByApprovalId(ApprovalVM approvalVM)
        {
            ApprovalVM approvalVm = new ApprovalVM();

            try {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@CompanyId", approvalVM.ComapanyId);
                dynamicParameterlist.Add("@ReferenceNo", approvalVM.ReferenceNo);
                dynamicParameterlist.Add("@ApprovalTypeId", approvalVM.ApprovalTypeId);
                dynamicParameterlist.Add("@ApprovalRecieversId", approvalVM.ApprovalOfficersId);
                dynamicParameterlist.Add("@CreatedUserId", approvalVM.CreatedUserId);
               // approvalVm = await dbConnection.QueryFirstOrDefaultAsync<ApprovalVM>("wkb.AddNewApproveByApprovalId", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return approvalVm;
        }

        public async Task<ApprovalVM> GetApprovalDetailsById(int id, int companyId,int pageId)
        {
            ApprovalVM approvalVM = new ApprovalVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@UserID", id);
                dynamicParameterlist.Add("@CompanyId", companyId);
                dynamicParameterlist.Add("@PageId", pageId);
                approvalVM = await dbConnection.QuerySingleOrDefaultAsync<ApprovalVM>("wkb.GetOwnApprovalTaskByUserID", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return approvalVM;
        }

        public async Task<FunctionApprovalTypeVm> GetFunctionApprovalDetailsByFunctionId( int functionId, int companyId)
        {
            FunctionApprovalTypeVm functionApprovalTypeVm = new FunctionApprovalTypeVm();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@FunctionId", functionId);
                dynamicParameterlist.Add("@CompanyId", companyId);
                functionApprovalTypeVm = await dbConnection.QuerySingleOrDefaultAsync<FunctionApprovalTypeVm>("wkb.GetFuncionApprovalDetailsByFuncionId", dynamicParameterlist,_transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return functionApprovalTypeVm;
        }

        public async Task<ChangeApprovalVM> UpdateApprovalDetailsByFunctionId(int functionId,int companyId,int status )
        {
            ChangeApprovalVM approvalVm = new ChangeApprovalVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@ApprovalTypeId", functionId);
                dynamicParameterlist.Add("@CompanyId", companyId);
                dynamicParameterlist.Add("@Status", status);
                approvalVm = await dbConnection.QuerySingleOrDefaultAsync<ChangeApprovalVM>("wkb.UpdateFunctionApprovalDetailsById", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return approvalVm;
        }

      public async Task<IEnumerable <ApprovalEventVM>> GetOwnApprovalDetailByUserID( int userID, int companyId , int pageId)
        {
          IEnumerable<ApprovalEventVM>  approvalEventVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@UserID", userID);
                dynamicParameterlist.Add("@CompanyId", companyId);
                dynamicParameterlist.Add("@PageId", pageId);
                approvalEventVM = await dbConnection.QueryAsync<ApprovalEventVM>("wkb.GetOwnApprovalTaskByUserID", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                return approvalEventVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApplicationUserVM> GetUserDetailsByUserId(int userId)
        {
            ApplicationUserVM applicationUserVM = new ApplicationUserVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@UserId", userId);
                applicationUserVM = await dbConnection.QuerySingleOrDefaultAsync<ApplicationUserVM>("usm.GetUserDetailsByUserId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return applicationUserVM;
        }

        public async Task<IEnumerable<FunctionApprovalTypeVm>> GetAllFunctionApprovalDetails()
        {
            IEnumerable<FunctionApprovalTypeVm> functionApprovalTypeVm;
            try
            { 
                functionApprovalTypeVm = await dbConnection.QueryAsync<FunctionApprovalTypeVm>("wkb.GetAllFuncionApprovalDetails", commandType: CommandType.StoredProcedure);
             }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return functionApprovalTypeVm;
        }

        public async Task<ApprovalTypeOwnVM> GetApprovalOfficerDetailsByApprovalTypeId(int approvalId)
        {
            ApprovalTypeOwnVM approvalTypeOwnVM = new ApprovalTypeOwnVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@ApprovalTypeId", approvalId);
                approvalTypeOwnVM = await dbConnection.QuerySingleOrDefaultAsync<ApprovalTypeOwnVM>("msd.GetApprovaltypeOwnDetailsById", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return approvalTypeOwnVM;
        }

        public async Task<ApplicationUserVM> GetApprovalOfficerByUserId(int userId)
        {
            ApplicationUserVM applicationUserVM = new ApplicationUserVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@UserId", userId);
                applicationUserVM = await dbConnection.QuerySingleOrDefaultAsync<ApplicationUserVM>("msd.GetApplicationUserDetailsById", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return applicationUserVM;
        }

        public async Task<ApprovalTypeOwnVM> UpdateApprovalOfficerDetailsByApprovalTypeId(int approvalTypeId, string approvalOfficerIdList, int companyId)
        {
            ApprovalTypeOwnVM approvalTypeOwnVM = new ApprovalTypeOwnVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@ApprovalTypeId", approvalTypeId);
                dynamicParameterlist.Add("@IdList", approvalOfficerIdList);
                dynamicParameterlist.Add("@CompanyId", companyId);
                approvalTypeOwnVM = await dbConnection.QuerySingleOrDefaultAsync<ApprovalTypeOwnVM>("msd.UpdateApprovaltypeOwnDetailsById", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
             }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return approvalTypeOwnVM;
        }

        public async Task<ApprovalVM> AddNewApprovalDetails(ApprovalVM approvalVM)
        {
            ApprovalVM approvalVm = new ApprovalVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                DynamicParameters a = new DynamicParameters();
              
                dynamicParameterlist.Add("@ApprovalTypeId", approvalVM.ApprovalTypeId);
                dynamicParameterlist.Add("@ReferenceNo", approvalVM.ReferenceNo);
                dynamicParameterlist.Add("@CreatedUserId", approvalVM.CreatedUserId);
               // approvalVm = await dbConnection.QuerySingleOrDefaultAsync<ApprovalVM>("wkb.AddNewApproveByApprovalId", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return approvalVm;
        }

        public async Task<IEnumerable<ApprovalEventVM>> GetAllApprovalEventsByUserId(int userId,int pageId)
        {
            IEnumerable<ApprovalEventVM> approvalEventVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@UserId", userId);
                dynamicParameterlist.Add("@PageId", pageId);
                approvalEventVM = await dbConnection.QueryAsync<ApprovalEventVM>("wkb.GetAllApprovalEventsByUserID", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return approvalEventVM;
        }

        public async Task<ApprovalEventVM> AddNewApprovalEventDetails(ApprovalEventVM approvalEventVM)
        {
            ApprovalEventVM approvalEventVm = new ApprovalEventVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@ReferenceNo", approvalEventVM.ReferenceNo);
                dynamicParameterlist.Add("@ApprovalTaskId", approvalEventVM.ApprovalTaskId);
                dynamicParameterlist.Add("@ApprovalTypeId", approvalEventVM.ApprovalTypeId);
                dynamicParameterlist.Add("@NotificationTypeId", approvalEventVM.NotificationTypeId);
                dynamicParameterlist.Add("@CreatedUserId", approvalEventVM.CreatedUserId);
                approvalEventVm = await dbConnection.QuerySingleOrDefaultAsync<ApprovalEventVM>("wkb.AddNewApprovalEventDetails", dynamicParameterlist,_transaction,  commandType: CommandType.StoredProcedure);

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return approvalEventVm;
        }

        public async Task<ApprovalResponseVM> UpdateApprovalRejectOrAcceptByTaskId(ApprovalResponseVM approvalResponseVM)
        {
            ApprovalResponseVM approvalResponseReturnVM = new ApprovalResponseVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@ApprovalTaskId", approvalResponseVM.ApprovalTaskId);
                dynamicParameterlist.Add("@IsApproved", approvalResponseVM.IsApproved);
                dynamicParameterlist.Add("@UserId", approvalResponseVM.UserId);
                dynamicParameterlist.Add("@UserComment", approvalResponseVM.UserComment);
                approvalResponseVM = await dbConnection.QuerySingleOrDefaultAsync<ApprovalResponseVM>("wkb.UpdateApprovalRejectOrAcceptByTaskId", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return approvalResponseVM;
        }

        public async Task<ApprovalTaskVM> GetApprovalTaskCreatedUserIdbyTaskId(string approvalTaskId)
        {
            ApprovalTaskVM approvalTaskVM = new ApprovalTaskVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@ApprovalTaskId", approvalTaskId);
                approvalTaskVM = await dbConnection.QuerySingleOrDefaultAsync<ApprovalTaskVM>("wkb.GetApprovalTaskCreatedUserIdbyTaskId", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return approvalTaskVM;
        }

        public Task<ApprovalVM> GetApprovalDetailsById(int id, int companyId)
        {
            throw new NotImplementedException();
        }
    }
}
