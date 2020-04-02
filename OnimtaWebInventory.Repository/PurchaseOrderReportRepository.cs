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
    public class PurchaseOrderReportRepository :DBContext, IPurchaseOrderReportRepository
    {
        public async Task<IEnumerable<PurchaseOrderReportVM>> GetAllPurchaseOrderReportDetails()
        {
           IEnumerable< PurchaseOrderReportVM >purchaseOrderReportVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("");
                purchaseOrderReportVM = await dbConnection.QueryAsync<PurchaseOrderReportVM>("rptstk.GetAllPurchaseOrderReportDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderReportVM;
        }

        public async Task<IEnumerable<ReportVM>> GetNetTotalOfSalesNPurchase(int companyId)
        {
           // IEnumerable<ReportVM> reportVM;
                    IList<ReportVM> reportVM = new List<ReportVM>();
            ReportVM a = new ReportVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@COmpanyId", companyId);
                var resultSet = await dbConnection.QueryMultipleAsync("stk.GetNetTotalOfSalesNPurchase", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                IEnumerable<ReportVM> result = resultSet.Read<ReportVM>();
                IEnumerable<ReportVM> result1 = resultSet.Read<ReportVM>();

                reportVM.Add(result.ElementAt(0));
                reportVM.Add(result1.ElementAt(0));



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

            return reportVM;
        }

        public async Task<IEnumerable<PurchaseOrderReportVM>> GetPurchaseOrderReportDetailsGroupByApprovalStatus(int companyId)
        {
          IEnumerable <PurchaseOrderReportVM> purchaseOrderReportVM ;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@CompanyId", companyId);
                purchaseOrderReportVM = await dbConnection.QueryAsync<PurchaseOrderReportVM>("stk.GetPurchaseOrderReportDetailsGroupByApprovalStatus", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderReportVM;
        }

        public async Task<IEnumerable<PurchaseOrderReportVM>> GetTopPurchaseReportDetailsOrderByBranchId()
        {
            IEnumerable<PurchaseOrderReportVM> purchaseOrderReportVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                purchaseOrderReportVM = await dbConnection.QueryAsync<PurchaseOrderReportVM>("rptstk.GetTopPurchaseReportDetailsOrderByBranchId", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderReportVM;
        }

        public async Task<IEnumerable<PurchaseOrderReportVM>> GetTopSaleReportDetailsOrderByBranchId()
        {
            IEnumerable<PurchaseOrderReportVM> purchaseOrderReportVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                purchaseOrderReportVM = await dbConnection.QueryAsync<PurchaseOrderReportVM>("rptstk.GetTopSaleReportDetailsOrderByBranchId", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderReportVM;
        }

        public async Task<IEnumerable<ReportVM>> GetTopSalesNPurchaseBranches(int companyId)
        {
            IList<ReportVM> reportVM = new List<ReportVM>();
            ReportVM a = new ReportVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@COmpanyId", companyId);
                var resultSet = await dbConnection.QueryMultipleAsync("stk.getTopSalesNPurchaseBranches", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                IEnumerable<ReportVM> result = resultSet.Read<ReportVM>();
                IEnumerable<ReportVM> result1 = resultSet.Read<ReportVM>();
                for(int i=0;i < result.Count(); i++)
                {
                    reportVM.Add(result.ElementAt(i));
                }

                for (int i = 0; i < result1.Count(); i++)
                {
                    reportVM.Add(result1.ElementAt(i));
                }



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

            return reportVM;
        }

        public async Task<IEnumerable<ReportVM>> GetTopSaleProducts(int companyId)
        {
            IList<ReportVM> reportVM = new List<ReportVM>();
            ReportVM a = new ReportVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@COmpanyId", companyId);
                var resultSet = await dbConnection.QueryMultipleAsync("stk.GetTopSaleProducts", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                IEnumerable<ReportVM> result = resultSet.Read<ReportVM>();
               // IEnumerable<ReportVM> result1 = resultSet.Read<ReportVM>();
                for (int i = 0; i < result.Count(); i++)
                {
                    reportVM.Add(result.ElementAt(i));
                }

              //  for (int i = 0; i < result1.Count(); i++)
                //{
                  //  reportVM.Add(result1.ElementAt(i));
                //}
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

            return reportVM;
        }

    }
}
