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
    public class PurchaseOrderInteligenceRepository : DBContext,IPurchaseOrderInteligenceRepository
    {
        public async Task<PurchaseAndSalesSummaryVM> GetPurchaseorderAndSalesOrderSummaryDeails(int companyId)
        {
            PurchaseAndSalesSummaryVM purchaseAndSalesSummaryVM = new PurchaseAndSalesSummaryVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@CompanyId", companyId);
                var a = await dbConnection.QueryMultipleAsync("rpt.GetPurchaseOrderAndSalesOrderReportDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                IEnumerable< PurchaseOrderItemVM> result = a.Read<PurchaseOrderItemVM>();
                IEnumerable<PurchaseOrderItemVM> result1 = a.Read<PurchaseOrderItemVM>();

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseAndSalesSummaryVM;
        }
    }
}
