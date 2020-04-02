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
    public class BusinessPartnerRepository : DBContext, IBusinessPartnerRepository
    {
        public async Task<BusinessPartnerVM> AddBusinessPartner(BusinessPartnerVM businessPartnerVm)
        {
            BusinessPartnerVM businessPartnerVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@CompanyId",businessPartnerVm.CompanyId);
                dynamicParameterlist.Add("@BankName", businessPartnerVm.BankName);
                dynamicParameterlist.Add("@BusinessPartnerTypeId", businessPartnerVm.BusinessPartnerTypeId);
                dynamicParameterlist.Add("@Addressing", businessPartnerVm.Addressing);
                dynamicParameterlist.Add("@FirstName", businessPartnerVm.FirstName);
                dynamicParameterlist.Add("@LastName", businessPartnerVm.LastName);
                dynamicParameterlist.Add("@CompanyName", businessPartnerVm.CompanyName);
                dynamicParameterlist.Add("@CompanyOwner", businessPartnerVm.CompanyOwner);
                dynamicParameterlist.Add("@CompanyCode", businessPartnerVm.CompanyCode);
                dynamicParameterlist.Add("@City", businessPartnerVm.City);
                dynamicParameterlist.Add("@Province", businessPartnerVm.Province);
                dynamicParameterlist.Add("@DisplayName", businessPartnerVm.DisplayName);
                dynamicParameterlist.Add("@Address1", businessPartnerVm.Address1);
                dynamicParameterlist.Add("@Address2", businessPartnerVm.Address2);
                dynamicParameterlist.Add("@Address3", businessPartnerVm.Address3);
                dynamicParameterlist.Add("@Email", businessPartnerVm.Email);
                dynamicParameterlist.Add("@NIC", businessPartnerVm.NIC);
                dynamicParameterlist.Add("@MobileNo", businessPartnerVm.MobileNo);
                dynamicParameterlist.Add("@LandPhoneNo", businessPartnerVm.LandPhoneNo);
                dynamicParameterlist.Add("@CreatedUserId", businessPartnerVm.CreatedUserId);
                dynamicParameterlist.Add("@Description", businessPartnerVm.Description);
                dynamicParameterlist.Add("@Country", businessPartnerVm.Country);
                dynamicParameterlist.Add("@BankId", businessPartnerVm.BankId);
                dynamicParameterlist.Add("@BranchName", businessPartnerVm.BranchName);
                dynamicParameterlist.Add("@AccountNo", businessPartnerVm.AccountNo);
                dynamicParameterlist.Add("@BrcNo", businessPartnerVm.BrcNo);
                dynamicParameterlist.Add("@VatRegNo", businessPartnerVm.VatRegNo);
                dynamicParameterlist.Add("@DiscountRate", businessPartnerVm.DiscountRate);
                dynamicParameterlist.Add("@CreditPeriod", businessPartnerVm.CreditPeriod);
                dynamicParameterlist.Add("@RegisteredAs", businessPartnerVm.RegisteredAs);
                dynamicParameterlist.Add("@GroupId", businessPartnerVm.BspGroupId);
                dynamicParameterlist.Add("@IsForiegn", businessPartnerVm.IsForiegn);

                businessPartnerVM = await dbConnection.QuerySingleOrDefaultAsync<BusinessPartnerVM>("bsp.AddBusinessPartner", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
                return businessPartnerVm;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async  Task<BusinessPartnerGroupVM> AddBusinessPartnerGroupDetails(BusinessPartnerGroupVM businessPartnerGroupVM)
        {
            BusinessPartnerGroupVM businessPartnerGroupVm = new BusinessPartnerGroupVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@GroupCode", businessPartnerGroupVM.GroupCode);
                dynamicParameterlist.Add("@GroupName", businessPartnerGroupVM.GroupName);
                dynamicParameterlist.Add("@BusinessPartnerTypeId", businessPartnerGroupVM.BusinessPartnerTypeId);
                dynamicParameterlist.Add("@BusinessPartnerTypeName", businessPartnerGroupVM.BusinessPartnerTypeName);
                dynamicParameterlist.Add("@CreatedUserId", businessPartnerGroupVM.CreatedUserId);
               // dbConnection.Open();
                businessPartnerGroupVM = await dbConnection.QuerySingleOrDefaultAsync<BusinessPartnerGroupVM>("bsp.AddBusinessPartnerGroupDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
                //dbConnection.Close();
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return businessPartnerGroupVM;
        }

        public async Task<BusinessPartnerVM> DeleteBusinessPartner(int businessPartnerId)
        {
            BusinessPartnerVM businessPartnerVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@BusinessPartnerId",businessPartnerId);
                businessPartnerVM=await dbConnection.QuerySingleOrDefaultAsync<BusinessPartnerVM>("msd.DeleteBusinessPartnerByBusinessPartnerId", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
                return businessPartnerVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<BusinessPartnerGroupVM>> GetAllBusinessPartnerGroupDetails()
        {
            IEnumerable<BusinessPartnerGroupVM> businessPartnerGroupVM;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                businessPartnerGroupVM = await dbConnection.QueryAsync<BusinessPartnerGroupVM>("bsp.GetAllBusinessPartnerGroupDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return businessPartnerGroupVM;
        }

        public async Task<IEnumerable<BankVM>> GetBusinessPartnerBanks()
        {
            IEnumerable<BankVM> bankVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                bankVM = await dbConnection.QueryAsync<BankVM>("bsp.GetBusinessPartnerBankDetails",dynamicParameterlist ,commandType: CommandType.StoredProcedure);
                return bankVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<BusinessPartnerVM>> GetBusinessPartnerDetails(int businessPartnerTypeId,int companyId, int pageId,int isActive)
        {
            IEnumerable<BusinessPartnerVM> businessPartnerVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@BusinessPartnerTypeId", businessPartnerTypeId);
                dynamicParameterlist.Add("@CompanyId", companyId);
                dynamicParameterlist.Add("@PageId", pageId);
                dynamicParameterlist.Add("@IsActive", isActive);
                businessPartnerVM = await dbConnection.QueryAsync<BusinessPartnerVM>("bsp.GetBusinessPartnerDetailsByCompanyId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                return businessPartnerVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<BusinessPartnerVM> GetBusinessPartnerDetailsByBspId(int businessPartnerId)
        {
            BusinessPartnerVM businessPartnerVM = new BusinessPartnerVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@BSPId", businessPartnerId);
                businessPartnerVM = await dbConnection.QuerySingleOrDefaultAsync<BusinessPartnerVM>("msd.GetBusinessPartnerDetailsById", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                return businessPartnerVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<BusinessPartnerVM>> GetBusinessPartnerDetailsByBSPName(string name, int businessPartnerTypeId)
        {
            IEnumerable<BusinessPartnerVM> businessPartnerVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Name", name);
                dynamicParameterlist.Add("@BusinessPartnerTypeId", businessPartnerTypeId);
                businessPartnerVM = await dbConnection.QueryAsync<BusinessPartnerVM>("bsp.GetBusinessPartnerDetailsByBSPName", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return businessPartnerVM;
        }

        public async Task<BusinessPartnerVM> GetBusinessPartnerDetailsByMobileNumber(int mobileNo, int businessPartnerTypeId)
        {
            BusinessPartnerVM businessPartnerVM = new BusinessPartnerVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@BusinessPartnerTypeId", businessPartnerTypeId);
                dynamicParameterlist.Add("@MobileNo", mobileNo);
                businessPartnerVM = await dbConnection.QuerySingleOrDefaultAsync<BusinessPartnerVM>("bsp.GetBusinessPartnerDetailsByMobileNumber", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return businessPartnerVM;
        }

        public async Task<IEnumerable<BusinessPartnerGroupVM>> GetBusinessPartnerGroupDetailsByGroupId(int groupCode)
        {
            IEnumerable<BusinessPartnerGroupVM> businessPartnerGroupVM;

            try
            {
                var dynamicParamterlist = new DynamicParameters();
                dynamicParamterlist.Add("@GroupCode", groupCode);
                businessPartnerGroupVM = await dbConnection.QueryAsync<BusinessPartnerGroupVM>("bsp.GetBusinessPartnerGroupDetailsByGroupId", dynamicParamterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return businessPartnerGroupVM;
        }

        public async Task<IEnumerable<BusinessPartnerGroupVM>> GetBusinessPartnerGroupDetailsByBspTypeId(int bspTypeId)
        {
            IEnumerable<BusinessPartnerGroupVM> businessPartnerGroupVM;

            try
            {
                var dynamicParamterlist = new DynamicParameters();
                dynamicParamterlist.Add("@BspTypeId", bspTypeId);
                businessPartnerGroupVM = await dbConnection.QueryAsync<BusinessPartnerGroupVM>("bsp.GetBusinessPartnerGroupDetailsByBusinessPartnerTypeId", dynamicParamterlist, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return businessPartnerGroupVM;
        }


        public async Task<BusinessPartnerVM> UpdateBusinessPartner(BusinessPartnerVM businessPartnerVm)
        {
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@CompanyId", businessPartnerVm.CompanyId);
                dynamicParameterlist.Add("@BankName", businessPartnerVm.BankName);
                dynamicParameterlist.Add("@BusinessPartnerTypeId", businessPartnerVm.BusinessPartnerTypeId);
                dynamicParameterlist.Add("@BusinessPartnerId", businessPartnerVm.BusinessPartnerId);
                dynamicParameterlist.Add("@Addressing", businessPartnerVm.Addressing);
                dynamicParameterlist.Add("@FirstName", businessPartnerVm.FirstName);
                dynamicParameterlist.Add("@LastName", businessPartnerVm.LastName);
                dynamicParameterlist.Add("@CompanyName", businessPartnerVm.CompanyName);
                dynamicParameterlist.Add("@CompanyOwner", businessPartnerVm.CompanyOwner);
                dynamicParameterlist.Add("@CompanyCode", businessPartnerVm.CompanyCode);
                dynamicParameterlist.Add("@City", businessPartnerVm.City);
                dynamicParameterlist.Add("@Province", businessPartnerVm.Province);
                dynamicParameterlist.Add("@DisplayName", businessPartnerVm.DisplayName);
                dynamicParameterlist.Add("@Address1", businessPartnerVm.Address1);
                dynamicParameterlist.Add("@Address2", businessPartnerVm.Address2);
                dynamicParameterlist.Add("@Address3", businessPartnerVm.Address3);
                dynamicParameterlist.Add("@Email", businessPartnerVm.Email);
                dynamicParameterlist.Add("@NIC", businessPartnerVm.NIC);
                dynamicParameterlist.Add("@MobileNo", businessPartnerVm.MobileNo);
                dynamicParameterlist.Add("@LandPhoneNo", businessPartnerVm.LandPhoneNo);
                dynamicParameterlist.Add("@CreatedUserId", businessPartnerVm.CreatedUserId);
                dynamicParameterlist.Add("@Description", businessPartnerVm.Description);
                dynamicParameterlist.Add("@Country", businessPartnerVm.Country);
                dynamicParameterlist.Add("@BankId", businessPartnerVm.BankId);
                dynamicParameterlist.Add("@BranchName", businessPartnerVm.BranchName);
                dynamicParameterlist.Add("@AccountNo", businessPartnerVm.AccountNo);
                dynamicParameterlist.Add("@BrcNo", businessPartnerVm.BrcNo);
                dynamicParameterlist.Add("@VatRegNo", businessPartnerVm.VatRegNo);
                dynamicParameterlist.Add("@DiscountRate", businessPartnerVm.DiscountRate);
                dynamicParameterlist.Add("@CreditPeriod", businessPartnerVm.CreditPeriod);
                dynamicParameterlist.Add("@RegisteredAs", businessPartnerVm.RegisteredAs);
                await dbConnection.QuerySingleOrDefaultAsync<BusinessPartnerVM>("bsp.UpdateBusinessPartner", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        public async Task<BusinessPartnerVM> UpdateBusinessPartnerCustomerStatus(int isActive, int businessPartnerId)
        {
            BusinessPartnerVM businessPartnerVM = new BusinessPartnerVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@BusinessPartnerId", businessPartnerId);
                dynamicParameterlist.Add("@IsActive", isActive);

                businessPartnerVM = await dbConnection.QuerySingleOrDefaultAsync<BusinessPartnerVM>("bsp.UpdateBusinessPartnerCustomerStatus", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return businessPartnerVM;
        }

        public async Task<BusinessPartnerGroupVM> UpdateBusinessPartnerGroupDetails(BusinessPartnerGroupVM businessPartnerGroupVM)
        {
            BusinessPartnerGroupVM businessPartnerGroupVm = new BusinessPartnerGroupVM();

            try
            {
                var dynamicParamterlist = new DynamicParameters();
                dynamicParamterlist.Add("@Id", businessPartnerGroupVM.Id);
                dynamicParamterlist.Add("@GroupCode", businessPartnerGroupVM.GroupCode);
                dynamicParamterlist.Add("@GroupName", businessPartnerGroupVM.GroupName);
                dynamicParamterlist.Add("@BusinessPartnerTypeId", businessPartnerGroupVM.BusinessPartnerTypeId);
                dynamicParamterlist.Add("@CreatedUserId", businessPartnerGroupVM.CreatedUserId);
                businessPartnerGroupVM = await dbConnection.QuerySingleOrDefaultAsync<BusinessPartnerGroupVM>("bsp.UpdateBusinessPartnerGroupDetails", dynamicParamterlist, _transaction, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return businessPartnerGroupVM;
        }

        public async Task<BusinessPartnerGroupVM> DeleteBusinessPartnerGroupDetails(string groupCode)
        {
            BusinessPartnerGroupVM businessPartnerGroupVM = new BusinessPartnerGroupVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@GroupCode", groupCode);
                businessPartnerGroupVM = await dbConnection.QuerySingleOrDefaultAsync<BusinessPartnerGroupVM>("bsp.DeleteBusinessPartnerGroupDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return businessPartnerGroupVM;
        }
    }
}
