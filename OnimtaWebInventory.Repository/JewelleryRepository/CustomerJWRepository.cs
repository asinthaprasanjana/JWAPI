using Dapper;
using DBConnect;
using OnimtaWebInventory.Core.IRepository.IJewelleryRepository;
using OnimtaWebInventory.Models.Jewellery;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Repository.JewelleryRepository
{
    public class CustomerJWRepository :DBContext, ICustomerJWRepository
    {
        public async Task<CustomerJw> AddJewelleryCustomerDetails(CustomerJw CustomerJw)
        {
            CustomerJw customerJW = new CustomerJw();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Title", CustomerJw.Title);
                dynamicParameterlist.Add("@Name", CustomerJw.Name);
                dynamicParameterlist.Add("@Address", CustomerJw.Address);
                dynamicParameterlist.Add("@Contact", CustomerJw.Contact);
                dynamicParameterlist.Add("@Country", CustomerJw.Country);
                dynamicParameterlist.Add("@CreatedUserId", CustomerJw.CreatedUserId);
                customerJW = await dbConnection.QuerySingleOrDefaultAsync<CustomerJw>("msd.AddJewelleryCustomerDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customerJW;

        }

        public async Task<CustomerJw> AddSalesManDetails(CustomerJw CustomerJw)
        {

            CustomerJw customerJW = new CustomerJw();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Title", CustomerJw.Title);
                dynamicParameterlist.Add("@Name", CustomerJw.Name);
                dynamicParameterlist.Add("@Address", CustomerJw.Address);
                dynamicParameterlist.Add("@Contact", CustomerJw.Contact);
                dynamicParameterlist.Add("@Country", CustomerJw.Country);
                dynamicParameterlist.Add("@CreatedUserId", CustomerJw.CreatedUserId);
                customerJW = await dbConnection.QuerySingleOrDefaultAsync<CustomerJw>("msd.AddSalesManDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customerJW;
        }

        public async Task<CustomerJw> DeleteJewelleryCustomerDetails(int id)
        {
            CustomerJw customerJW = new CustomerJw();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id",id);
                customerJW = await dbConnection.QuerySingleOrDefaultAsync<CustomerJw>("msd.DeleteJewelleryCustomerDetails",dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customerJW;
        }

        public async Task<CustomerJw> DeleteSalesManDetails(int id)
        {
            CustomerJw customerJW = new CustomerJw();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", id);
                customerJW = await dbConnection.QuerySingleOrDefaultAsync<CustomerJw>("msd.DeleteSalesManDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customerJW;
        }

        public async Task<IEnumerable<CustomerJw>> GetJewelleryCustomerDetails(FilterVM filter)
        {
            IEnumerable<CustomerJw> CustomerJw;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PageId", filter.pageId);
                dynamicParameterlist.Add("@Keyword", filter.keyword);
                dynamicParameterlist.Add("@SortDirection", filter.sortDirection);
                dynamicParameterlist.Add("@SortActive", filter.sortActive);
                dynamicParameterlist.Add("@Limit", filter.limit);
                dynamicParameterlist.Add("@FilterActive", filter.FilterActive);
                dynamicParameterlist.Add("@FilterValue", filter.FilterValue);
                CustomerJw = await dbConnection.QueryAsync<CustomerJw>("[msd].[GetJewelleryCustomerDetails]", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return CustomerJw;
        }

        public async Task<IEnumerable<CustomerJw>> GetSalesManDetails(FilterVM filter)
        {
            IEnumerable<CustomerJw> CustomerJw;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PageId", filter.pageId);
                dynamicParameterlist.Add("@Keyword", filter.keyword);
                dynamicParameterlist.Add("@SortDirection", filter.sortDirection);
                dynamicParameterlist.Add("@SortActive", filter.sortActive);
                dynamicParameterlist.Add("@Limit", filter.limit);
                dynamicParameterlist.Add("@FilterActive", filter.FilterActive);
                dynamicParameterlist.Add("@FilterValue", filter.FilterValue);
                CustomerJw = await dbConnection.QueryAsync<CustomerJw>("msd.GetSalesManDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return CustomerJw;
        }

        public async Task<CustomerJw> UpdateJewelleryCustomerDetails(CustomerJw CustomerJw)
        {
            CustomerJw customerJW = new CustomerJw();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", CustomerJw.Id);
                dynamicParameterlist.Add("@Country", CustomerJw.Country);
                dynamicParameterlist.Add("@Title", CustomerJw.Title);
                dynamicParameterlist.Add("@Name", CustomerJw.Name);
                dynamicParameterlist.Add("@Address", CustomerJw.Address);
                dynamicParameterlist.Add("@Contact", CustomerJw.Contact);
                dynamicParameterlist.Add("@Country", CustomerJw.Country);
                dynamicParameterlist.Add("@LastModifiedUserId", CustomerJw.LastModifiedUserId);
                customerJW = await dbConnection.QuerySingleOrDefaultAsync<CustomerJw>("msd.UpdateJewelleryCustomerDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customerJW;
        }

        public async Task<CustomerJw> UpdateSalesManDetails(CustomerJw CustomerJw)
        {
            CustomerJw customerJW = new CustomerJw();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", CustomerJw.Id);
                dynamicParameterlist.Add("@Title", CustomerJw.Title);
                dynamicParameterlist.Add("@Name", CustomerJw.Name);
                dynamicParameterlist.Add("@Address", CustomerJw.Address);
                dynamicParameterlist.Add("@Contact", CustomerJw.Contact);
                dynamicParameterlist.Add("@Country", CustomerJw.Country);
                dynamicParameterlist.Add("@LastModifiedUserId", CustomerJw.LastModifiedUserId);
                customerJW = await dbConnection.QuerySingleOrDefaultAsync<CustomerJw>("msd.UpdateSalesManDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customerJW;
        }
    }
}
