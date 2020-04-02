using Dapper;
using DBConnect;
using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace OnimtaWebInventory.Repository
{
    public class BranchRepository :DBContext, IBranchRepository
    {
        public async Task<BranchVM> AddNewBranchDetails(BranchVM branchVM)
        {
            BranchVM branchVm = new BranchVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@BranchName", branchVM.BranchName);
                dynamicParameterlist.Add("@DisplayName", branchVM.DisplayName);
                dynamicParameterlist.Add("@BranchTypeId", branchVM.BranchTypeId);
                dynamicParameterlist.Add("@PhoneNo", branchVM.PhoneNo);
                dynamicParameterlist.Add("@Address", branchVM.Address);
                dynamicParameterlist.Add("@City", branchVM.City);
                dynamicParameterlist.Add("@CompanyId", branchVM.CompanyId);
                dynamicParameterlist.Add("@CreatedUserId", branchVM.CreatedUserId);
                branchVm = await dbConnection.QuerySingleOrDefaultAsync<BranchVM>("msd.AddBranch", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return branchVm;
        }

        public async Task<WareHouseVM> AddNewWareHouseDetails(WareHouseVM wareHouseVM)
        {
            WareHouseVM wareHouseVm = new WareHouseVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.AddDynamicParams(wareHouseVM);
                wareHouseVM = await dbConnection.QuerySingleOrDefaultAsync<WareHouseVM>("msd.AddNewWareHouseDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

           } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return wareHouseVM;
        }

        public async Task<IEnumerable<BranchVM>>GetBranchDetailByCompanyId(int companyId)
        {
          IEnumerable<BranchVM> branchVM;
                try
                {
                   
                    var Parameterlist = new DynamicParameters();
                    Parameterlist.Add("@CompanyId" , companyId);
                    branchVM = await dbConnection.QueryAsync<BranchVM>("msd.GetBranchDetailsByCompanyId", Parameterlist,_transaction, commandType: CommandType.StoredProcedure);
            
                     return branchVM;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
        }

        public async Task<IEnumerable<BranchVM>> GetBranchDetailsByUserId(int userId, int businessProcessId)
        {
            IEnumerable<BranchVM> branchVM;
            try
            {
                var dynamicParameterslist = new DynamicParameters();
                dynamicParameterslist.Add("@UserId", userId);
                dynamicParameterslist.Add("@BusinessProcessId", businessProcessId);
                branchVM = await dbConnection.QueryAsync<BranchVM>("msd.GetBranchDetailsByUserId", dynamicParameterslist, commandType: CommandType.StoredProcedure);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return branchVM;
        }

        public async Task<WareHouseVM> GetWareHouseDetailsByBranchId(int BranchId)
        {
            WareHouseVM wareHouseVM = new WareHouseVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@BranchId", BranchId);
                wareHouseVM = await dbConnection.QuerySingleOrDefaultAsync<WareHouseVM>("msd.GetWareHouseDetailsByBranchId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
           
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return wareHouseVM;
        }

        public async Task<BranchVM> UpdateBranchDetails(BranchVM branchVM)
        {
            BranchVM branchVm = new BranchVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", branchVM.Id);
                dynamicParameterlist.Add("@BranchId", branchVM.BranchId);
                dynamicParameterlist.Add("@BranchName", branchVM.BranchName);
                dynamicParameterlist.Add("@DisplayName", branchVM.DisplayName);
                dynamicParameterlist.Add("@BranchTypeId", branchVM.BranchTypeId);
                dynamicParameterlist.Add("@PhoneNo", branchVM.PhoneNo);
                dynamicParameterlist.Add("@Address", branchVM.Address);
                dynamicParameterlist.Add("@City", branchVM.City);
                dynamicParameterlist.Add("@CompanyId", branchVM.CompanyId);
                dynamicParameterlist.Add("@CreatedUserId", branchVM.CreatedUserId);
                branchVm = await dbConnection.QuerySingleOrDefaultAsync<BranchVM>("msd.UpdateBranchDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return branchVm;
        }

        public async Task<WareHouseVM> UpdateWareHouseDetails(WareHouseVM wareHouseVM)
        {
            WareHouseVM wareHouseVm = new WareHouseVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.AddDynamicParams(wareHouseVM);
                wareHouseVM = await dbConnection.QuerySingleOrDefaultAsync<WareHouseVM>(" ", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return wareHouseVM;
        }
    }
}
