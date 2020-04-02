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
    public class CustomerRepository : DBContext,ICustomerRepository
    {
        public async Task<CustomerVM> AddNewCustomerDetails(CustomerVM customerVM)
        {
            CustomerVM customervM = new CustomerVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Nic", customerVM.Nic);
                dynamicParameterlist.Add("@UserId", customerVM.UserId);
                dynamicParameterlist.Add("@UserName", customerVM.UserName);
                dynamicParameterlist.Add("@Password", customerVM.Password);
                dynamicParameterlist.Add("@BDay", customerVM.BDay);
                dynamicParameterlist.Add("@Email", customerVM.Email);
                dynamicParameterlist.Add("@CompanyId", customerVM.CompanyId);
                customervM = await dbConnection.QuerySingleOrDefaultAsync<CustomerVM>("msd.AddNewCustomerDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
             }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customerVM;
        }

        public async Task<CustomerVM> GetCustomerDetailsById(int id,int companyId)
        {
            CustomerVM customerVM = new CustomerVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id",id);
                dynamicParameterlist.Add("@CompanyId", companyId);
                customerVM = await dbConnection.QuerySingleOrDefaultAsync<CustomerVM>("msd.GetCustomerDetailsById", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customerVM;
        }
        public async Task<CustomerVM> UpdateCustomerDetailsById(CustomerVM customerVM)
        {
            CustomerVM customerVm = new CustomerVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", customerVM.Id);
                dynamicParameterlist.Add("@Nic", customerVM.Nic);
                dynamicParameterlist.Add("@UserId", customerVM.UserId);
                dynamicParameterlist.Add("@UserName", customerVM.UserName);
                dynamicParameterlist.Add("@Password", customerVM.Password);
                dynamicParameterlist.Add("@BDay", customerVM.BDay);
                dynamicParameterlist.Add("@Email", customerVM.Email);
                dynamicParameterlist.Add("@CompanyId", customerVM.CompanyId);
                customerVm = await dbConnection.QuerySingleOrDefaultAsync<CustomerVM>("msd.UpdateCustomerDetailsById", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customerVm;
        }
    
        public async Task<CustomerVM> DeleteCustomerDetailsById(int id)
        {
            CustomerVM customerVM = new CustomerVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", customerVM.Id);
                customerVM = await dbConnection.QuerySingleOrDefaultAsync<CustomerVM>("msd.DeleteCustomerDetailsById", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customerVM;
        }
    }
}
