using Dapper;
using DBConnect;
using Microsoft.EntityFrameworkCore;
using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Repository
{
    public class SalesInvoiceRepository :DBContext,ISalesInvoiceRepository
    {
        public async Task<SalesInvoiceMasterVM> AddNewSalesInvoiceSummaryDetails(SalesInvoiceMasterVM salesInvoiceMasterVM)
        {
            SalesInvoiceMasterVM SalesInvoiceMasterVm = new SalesInvoiceMasterVM();

            try
            {
                DynamicParameters dynamicParameterList = new DynamicParameters();
                dynamicParameterList.Add("@SaleNo", salesInvoiceMasterVM.OrderNo);
                dynamicParameterList.Add("@InvoiceType", 0);
                dynamicParameterList.Add("@CompanyId", salesInvoiceMasterVM.CompanyId);
                dynamicParameterList.Add("@CustomerId", salesInvoiceMasterVM.CustomerId);
                dynamicParameterList.Add("@InvoiceDate", salesInvoiceMasterVM.InvoiceDate);
                dynamicParameterList.Add("@GrossTotal", salesInvoiceMasterVM.GrossTotal);
                dynamicParameterList.Add("@NetTotal", salesInvoiceMasterVM.NetTotal);
                dynamicParameterList.Add("@TotalTax", salesInvoiceMasterVM.TotalTax);
                dynamicParameterList.Add("@TotalDiscounts", salesInvoiceMasterVM.TotalDiscounts);
                dynamicParameterList.Add("@CreatedUserId", salesInvoiceMasterVM.CreatedUserId);

                SalesInvoiceMasterVm = await dbConnection.QuerySingleOrDefaultAsync<SalesInvoiceMasterVM>("csh.AddNewSalesOrderInvoiceSummaryDetails", dynamicParameterList, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return SalesInvoiceMasterVm;
        }

        public async Task<SalesInvoiceMasterVM> AddNewProformaInvoiceSummaryDetails(SalesInvoiceMasterVM salesInvoiceMasterVM)
        {
            SalesInvoiceMasterVM SalesInvoiceMasterVm = new SalesInvoiceMasterVM();

            try
            {
                DynamicParameters dynamicParameterList = new DynamicParameters();
                dynamicParameterList.Add("@InvoiceNo", salesInvoiceMasterVM.InvoiceNo);
                dynamicParameterList.Add("@SaleNo", salesInvoiceMasterVM.OrderNo);
                dynamicParameterList.Add("@CompanyId", salesInvoiceMasterVM.CompanyId);
                dynamicParameterList.Add("@CustomerId", salesInvoiceMasterVM.CustomerId);
                dynamicParameterList.Add("@InvoiceDate", salesInvoiceMasterVM.InvoiceDate);
                dynamicParameterList.Add("@GrossTotal", salesInvoiceMasterVM.GrossTotal);
                dynamicParameterList.Add("@NetTotal", salesInvoiceMasterVM.NetTotal);
                dynamicParameterList.Add("@TotalTax", salesInvoiceMasterVM.TotalTax);
                dynamicParameterList.Add("@TotalDiscounts", salesInvoiceMasterVM.TotalDiscounts);
                dynamicParameterList.Add("@CreatedUserId", salesInvoiceMasterVM.CreatedUserId);

                SalesInvoiceMasterVm = await dbConnection.QuerySingleOrDefaultAsync<SalesInvoiceMasterVM>("csh.AddNewProformaInvoiceSummaryDetails", dynamicParameterList, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return SalesInvoiceMasterVm;
        }


        public async Task<SalesOrderItemVM> AddNewSalesInvoiceItemDetails(SalesOrderItemVM salesOrderItemVM,string invoiceNo,int companyId)
        {
            SalesOrderItemVM salesOrderItemVm = new SalesOrderItemVM();

            try
            {
                DynamicParameters dynamicParameterList = new DynamicParameters();
                dynamicParameterList.Add("@ProductId", salesOrderItemVM.ItemId);
                dynamicParameterList.Add("@Quantity", salesOrderItemVM.Quantity);
                dynamicParameterList.Add("@PackSizeId", salesOrderItemVM.PackSizeId);
                dynamicParameterList.Add("@InvoiceNo", invoiceNo);
                dynamicParameterList.Add("@ItemCost", salesOrderItemVM.ItemCost);
                dynamicParameterList.Add("@CompanyId", companyId);
                dynamicParameterList.Add("@Discount", salesOrderItemVM.Discount);
                dynamicParameterList.Add("@Tax", salesOrderItemVM.Tax);
                dynamicParameterList.Add("@UserId", salesOrderItemVM.UserId);

                salesOrderItemVm = await dbConnection.QuerySingleOrDefaultAsync<SalesOrderItemVM>("csh.AddSalesOrderInvoicedItems", dynamicParameterList, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return salesOrderItemVm;
        }

        public async Task<SalesOrderItemVM> AddNewProformaInvoiceItemDetails(SalesOrderItemVM salesOrderItemVM, string invoiceNo, int companyId)
        {
            SalesOrderItemVM salesOrderItemVm = new SalesOrderItemVM();

            try
            {
                DynamicParameters dynamicParameterList = new DynamicParameters();
                dynamicParameterList.Add("@ProductId", salesOrderItemVM.ItemId);
                dynamicParameterList.Add("@Quantity", salesOrderItemVM.Quantity);
                dynamicParameterList.Add("@PackSizeId", salesOrderItemVM.PackSizeId);
                dynamicParameterList.Add("@InvoiceNo", invoiceNo);
                dynamicParameterList.Add("@ItemCost", salesOrderItemVM.ItemCost);
                dynamicParameterList.Add("@CompanyId", companyId);
                dynamicParameterList.Add("@Discount", salesOrderItemVM.Discount);
                dynamicParameterList.Add("@Tax", salesOrderItemVM.Tax);
                dynamicParameterList.Add("@UserId", salesOrderItemVM.UserId);

                salesOrderItemVm = await dbConnection.QuerySingleOrDefaultAsync<SalesOrderItemVM>("csh.AddProformaInvoicedItems", dynamicParameterList, _transaction, commandType: System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return salesOrderItemVm;
        }

        public async Task<IEnumerable<SalesInvoiceSummaryVM>> GetAllInvoiceDetailsByCompanyId(int companyId)
        {
            IEnumerable<SalesInvoiceSummaryVM> salesInvoiceSummaryVM;

            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("CompanyId", companyId);
                salesInvoiceSummaryVM = await dbConnection.QueryAsync<SalesInvoiceSummaryVM>("csh.GetAllInvoiceDetailsByCompanyId",dynamicParameters,commandType:CommandType.StoredProcedure);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return salesInvoiceSummaryVM;
        }

        public async Task<SalesInvoiceMasterVM> GetAllInvoiceSummaryDetailsByInvoiceNo(int InvoiceNo)
        {
            SalesInvoiceMasterVM salesInvoiceMasterVM = new SalesInvoiceMasterVM();
            
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("InvoiceNo", InvoiceNo);
                salesInvoiceMasterVM = await dbConnection.QuerySingleOrDefaultAsync<SalesInvoiceMasterVM>("csh.GetAllInvoiceDetailsByInvoiceNo", dynamicParameters, commandType: CommandType.StoredProcedure);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return salesInvoiceMasterVM;
        }

        public async Task<IEnumerable<SalesOrderItemVM>> GetAllInvoicedItemDetailsByInvoiceNo(int InvoiceNo)
        {
            IEnumerable<SalesOrderItemVM> salesOrderItemVM;

            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("InvoiceNo",InvoiceNo);
                salesOrderItemVM = await dbConnection.QueryAsync<SalesOrderItemVM>("csh.GetAllInvoicedItemDetailsByInvoiceNo",dynamicParameters, commandType:CommandType.StoredProcedure);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return salesOrderItemVM;
        }
    }
}
