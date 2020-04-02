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
    public class CancellationRepository :DBContext, ICancellationRepository
    {
        public async Task<CancellationVM> AddNewCancellationDetails(CancellationVM cancellationVM)
        {
            CancellationVM cancellationVm = new CancellationVM();
            try
            {
                var dynamicParamterlist = new DynamicParameters();
                dynamicParamterlist.Add("@CancellationTypeId",cancellationVM.CancellationTypeId);
                dynamicParamterlist.Add("@ReferenceNumber", cancellationVM.ReferenceNumber);
                dynamicParamterlist.Add("@Reason", cancellationVM.Reason);
                dynamicParamterlist.Add("@CreatedUserId", cancellationVM.CreatedUserId);
                cancellationVM = await dbConnection.QuerySingleOrDefaultAsync<CancellationVM>("msd.AddNewCancellationDetails", dynamicParamterlist, _transaction, commandType: CommandType.StoredProcedure);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cancellationVM;
        }

        public async Task<IEnumerable<PurchaseOrderMasterVM>> GetCancellationData(int cancellationTypeId)
        {
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;
            try
            {
                var dynamicParamterlist = new DynamicParameters();
                dynamicParamterlist.Add("@cancellationTypeId", cancellationTypeId);
                purchaseOrderMasterVM = await dbConnection.QueryAsync<PurchaseOrderMasterVM>("msd.GetCancellationData", dynamicParamterlist, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderMasterVM;
        }

        public async Task<IEnumerable<PurchaseOrderItemVM>> GetCancellationProductData(int cancellationTypeId, string id)
        {
            IEnumerable<PurchaseOrderItemVM> purchaseOrderItemVM;
            try
            {
                var dynamicParamterlist = new DynamicParameters();
                dynamicParamterlist.Add("@cancellationTypeId", cancellationTypeId);
                dynamicParamterlist.Add("@id", id);
                purchaseOrderItemVM = await dbConnection.QueryAsync<PurchaseOrderItemVM>("msd.GetCancellationProductData", dynamicParamterlist, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderItemVM;
        }

        public async Task<PurchaseOrderMasterVM> GetCancellationSummaryData(int cancellationTypeId, string id)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVM = new PurchaseOrderMasterVM();
            try
            {
                var dynamicParamterlist = new DynamicParameters();
                dynamicParamterlist.Add("@cancellationTypeId", cancellationTypeId);
                dynamicParamterlist.Add("@id", id);
                purchaseOrderMasterVM = await dbConnection.QuerySingleOrDefaultAsync<PurchaseOrderMasterVM>("msd.GetCancellationSummaryData", dynamicParamterlist, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderMasterVM;
        }

        public async Task<PurchaseOrderMasterVM> updateCancellationData(int cancellationTypeId, string id, int isCancelled, int userId)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVM = new PurchaseOrderMasterVM();
            try
            {
                var dynamicParamterlist = new DynamicParameters();
                dynamicParamterlist.Add("@cancellationTypeId", cancellationTypeId);
                dynamicParamterlist.Add("@id", id);
                dynamicParamterlist.Add("@userId", userId);
                purchaseOrderMasterVM = await dbConnection.QuerySingleOrDefaultAsync<PurchaseOrderMasterVM>("msd.UpdateCancellationData", dynamicParamterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderMasterVM;
        }
    }
}
