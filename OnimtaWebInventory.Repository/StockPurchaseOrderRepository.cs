using Dapper;
using DBConnect;
using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Repository
{
    public class StockPurchaseOrderRepository : DBContext, IPurchaseOrderRepository
    {

        public StockPurchaseOrderRepository( )
        {
        }

        public async Task<PurchaseOrderItemVM> AddPurschaseOrderItemDetails(PurchaseOrderItemVM purchaseOrderItemVM)
        {

            PurchaseOrderItemVM purchaseOrderItemVm = new PurchaseOrderItemVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();

                dynamicParameterlist.Add("@productId", purchaseOrderItemVM.ProductId);
                dynamicParameterlist.Add("@ItemName", purchaseOrderItemVM.ProductName);
                dynamicParameterlist.Add("@Quantity", purchaseOrderItemVM.Quantity);
                dynamicParameterlist.Add("@packSizeId", purchaseOrderItemVM.PackSizeId);
                dynamicParameterlist.Add("@purchaseOrderId", purchaseOrderItemVM.purchaseOrderId);
                dynamicParameterlist.Add("@ItemCost", purchaseOrderItemVM.ItemCost);
                dynamicParameterlist.Add("@Discount", purchaseOrderItemVM.Discount);
                dynamicParameterlist.Add("@Tax", purchaseOrderItemVM.Tax);
                dynamicParameterlist.Add("@TotalCost", purchaseOrderItemVM.TotalCost);
                dynamicParameterlist.Add("@UserId", purchaseOrderItemVM.UserId);
                dynamicParameterlist.Add("@CompanyId", purchaseOrderItemVM.CompanyId);


                purchaseOrderItemVm = await dbConnection.QuerySingleOrDefaultAsync<PurchaseOrderItemVM>("stk.AddPurchaseOrderItem", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

                if(purchaseOrderItemVM.BranchWiseQuantity.Count()>0)
                {
                     for(int i=0;i< purchaseOrderItemVM.BranchWiseQuantity.Count();i++)
                    {
                        var dynamicParameterlist1 = new DynamicParameters();
                        dynamicParameterlist1.Add("@PurchaseId", purchaseOrderItemVM.purchaseOrderId);
                        dynamicParameterlist1.Add("@PurchaseOrderItemId", purchaseOrderItemVM.purchaseOrderItemId);
                        dynamicParameterlist1.Add("@BranchId", purchaseOrderItemVM.BranchWiseQuantity.ElementAt(i).BranchId);
                        dynamicParameterlist1.Add("@Quantity", purchaseOrderItemVM.BranchWiseQuantity.ElementAt(i).ProductQuantity);

                        int returnvalue = await dbConnection.QuerySingleOrDefaultAsync<int>("stk.AddBranchWisePurchaseOrderItems", dynamicParameterlist1, _transaction, commandType: CommandType.StoredProcedure);

                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderItemVm;
        }

        public async Task<NewPurchaseOrderVM> AddPurschaseOrderSummeryDetails(NewPurchaseOrderVM newPurchaseOrderVM)
        {
            NewPurchaseOrderVM purchaseOrderVM = new NewPurchaseOrderVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.AddDynamicParams(newPurchaseOrderVM);
                purchaseOrderVM = await dbConnection.QuerySingleOrDefaultAsync<NewPurchaseOrderVM>("stk.AddPurchaseOrderSummeryDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderVM;
        }

       

        public async Task<PurchaseOrderItemVM> DeletePurchaseOrderItemDetailsByPurchaseOrderId(int purchaseOrderId)
        {
            PurchaseOrderItemVM purchaseOrderItemVM = new PurchaseOrderItemVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PurchaseOrderItemId", purchaseOrderId);
                purchaseOrderItemVM = await dbConnection.QueryFirstOrDefaultAsync<PurchaseOrderItemVM>("stk.DeletePurchaseOrderItemDetailsByPurchaseOrderId", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderItemVM;
        }

        public async Task<PurchaseOrderMasterVM> GetPurchaseOrderDetailsById( string purchaseorderId,int companyId)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVM = new PurchaseOrderMasterVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PurchaseOrderId", purchaseorderId);
                dynamicParameterlist.Add("@CompanyId", companyId);
                purchaseOrderMasterVM = await dbConnection.QuerySingleOrDefaultAsync<PurchaseOrderMasterVM>("stk.GetPurchaseOrderDetailsByPurchaseOrderId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderMasterVM;
        }

        public async Task<PurchaseOrderMasterVM> GetPurchaseOrderDraftDetailsById(string purchaseorderId, int companyId)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVM = new PurchaseOrderMasterVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PurchaseOrderId", purchaseorderId);
                dynamicParameterlist.Add("@CompanyId", companyId);
                purchaseOrderMasterVM = await dbConnection.QuerySingleOrDefaultAsync<PurchaseOrderMasterVM>("stk.GetPurchaseOrderDraftDetailsByPurchaseOrderId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderMasterVM;
        }
        public async Task<IEnumerable<PurchaseOrderItemVM>> GetPurchaseOrderItemDetailsById(string purchaseorderId )
        {
            IEnumerable<PurchaseOrderItemVM> purchaseOrderItemVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PurchaseOrderId", purchaseorderId);
                purchaseOrderItemVM = await dbConnection.QueryAsync<PurchaseOrderItemVM>("stk.GetPurchaseOrderItemByPurchaseOrderID", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderItemVM;
        }

        public async Task<IEnumerable<PurchaseOrderItemVM>> GetPurchaseOrderItemDraftDetailsById(string purchaseorderId)
        {
            IEnumerable<PurchaseOrderItemVM> purchaseOrderItemVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PurchaseOrderId", purchaseorderId);
                purchaseOrderItemVM = await dbConnection.QueryAsync<PurchaseOrderItemVM>("stk.GetPurchaseOrderItemsDraftDetailsByPurchaseNo", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderItemVM;
        }

        public async Task<IEnumerable<PurchaseOrderItemVM>> GetPurchaseOrderDraftDetailsByUserId(int userId)
        {
            IEnumerable<PurchaseOrderItemVM> purchaseOrderItemVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@UserId", userId);
                purchaseOrderItemVM = await dbConnection.QueryAsync<PurchaseOrderItemVM>("stk.GetPurchaseOrderDraftDetailsByUserId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                return purchaseOrderItemVM;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<PurchaseOrderSummeryVM>> GetPurchaseOrderSummeryDetails(int searchTypeId, int pageId)
        {
            IEnumerable<PurchaseOrderSummeryVM> purchaseOrderSummeryVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@SearchTypeId", searchTypeId);
                dynamicParameterlist.Add("@PageId", pageId);

                purchaseOrderSummeryVM = await dbConnection.QueryAsync<PurchaseOrderSummeryVM>("stk.GetPurchaseOrderSummeryDetailsByCompanyId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                return purchaseOrderSummeryVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<PurchaseOrderSummeryVM> GetStockPurchaseOrderId(int companyId)
        {
            PurchaseOrderSummeryVM purchaseOrderSummeryVM = new PurchaseOrderSummeryVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@CompanyID", companyId);
                purchaseOrderSummeryVM = await dbConnection.QuerySingleOrDefaultAsync<PurchaseOrderSummeryVM>("stk.GetPurchaseOrderId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                return purchaseOrderSummeryVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async  Task<PurchaseOrderFinalVM> UpdatePurchaseOrderById(PurchaseOrderFinalVM purchaseOrderFinalVM)
        {
            PurchaseOrderFinalVM purchaseOrderFinalVm = new PurchaseOrderFinalVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PurchaseNo", purchaseOrderFinalVM.PurchaseNo);
                dynamicParameterlist.Add("@GrossTotal", purchaseOrderFinalVM.GrossTotal);
                dynamicParameterlist.Add("@tax", purchaseOrderFinalVM.Tax);
                dynamicParameterlist.Add("@Discount", purchaseOrderFinalVM.Discount);
                dynamicParameterlist.Add("@NetTotal", purchaseOrderFinalVM.NetTotal);
                dynamicParameterlist.Add("@UserId", purchaseOrderFinalVM.UserId);
                dynamicParameterlist.Add("@QcAvailable", purchaseOrderFinalVM.QcAvailable);


                purchaseOrderFinalVm = await dbConnection.QuerySingleOrDefaultAsync<PurchaseOrderFinalVM>("stk.UpdatePurchaseOrderById", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderFinalVm;
        }

        public async Task<PurchaseOrderItemVM> UpdatePurchaseOrderItemDetailsByPurchaseOrderId(PurchaseOrderItemVM purchaseOrderItemVM)
        {
            PurchaseOrderItemVM purchaseOrderItemVm = new PurchaseOrderItemVM();
          
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PurchaseOrderId", purchaseOrderItemVM.purchaseOrderId);
                dynamicParameterlist.Add("@ItemName", purchaseOrderItemVM.ProductName);
                dynamicParameterlist.Add("@ItemId", purchaseOrderItemVM.ProductId);
                dynamicParameterlist.Add("@purchaseOrderItemId", purchaseOrderItemVM.purchaseOrderItemId);
                dynamicParameterlist.Add("@Quantity", purchaseOrderItemVM.Quantity);
                dynamicParameterlist.Add("@ItemCost", purchaseOrderItemVM.ItemCost);
                dynamicParameterlist.Add("@Discount", purchaseOrderItemVM.Discount);
                dynamicParameterlist.Add("@Tax", purchaseOrderItemVM.Tax);
                dynamicParameterlist.Add("@TotalCost", purchaseOrderItemVM.TotalCost);
                dynamicParameterlist.Add("@UserId", purchaseOrderItemVM.UserId);


                purchaseOrderItemVM = await dbConnection.QuerySingleOrDefaultAsync<PurchaseOrderItemVM>("stk.UpdatePurchaseOrderItemDetailsByPurchaseOrderId", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderItemVM;
           
        }

        public async Task<NewPurchaseOrderVM> UpdatePurchaseOrderSummeryDetailsById(NewPurchaseOrderVM newPurchaseOrderVM)
        {
            NewPurchaseOrderVM newPurchaseOrderVm = new NewPurchaseOrderVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@ID", newPurchaseOrderVM.Id);
                dynamicParameterlist.Add("@PurchaseNO", newPurchaseOrderVM.PurchaseNo);
                dynamicParameterlist.Add("@BranchId", newPurchaseOrderVM.BranchId);
                dynamicParameterlist.Add("@SupplierId", newPurchaseOrderVM.SupplierId);
                dynamicParameterlist.Add("@BillLocationId", newPurchaseOrderVM.BillTo);
                dynamicParameterlist.Add("@ShipLocationId", newPurchaseOrderVM.ShipTo);
                dynamicParameterlist.Add("@StockDue", newPurchaseOrderVM.StockDue);
                dynamicParameterlist.Add("@PaymentDue", newPurchaseOrderVM.PayementDue);
                dynamicParameterlist.Add("@CurrencyId", newPurchaseOrderVM.CurrencyId);
                dynamicParameterlist.Add("@Status", newPurchaseOrderVM.Status);
                dynamicParameterlist.Add("@Recieved", newPurchaseOrderVM.Recieved);
                dynamicParameterlist.Add("@Billed", newPurchaseOrderVM.Billed);
                dynamicParameterlist.Add("@CreditPeriod", newPurchaseOrderVM.CreditPeriod);
                dynamicParameterlist.Add("@Email", newPurchaseOrderVM.Email);
                dynamicParameterlist.Add("@Remarks", newPurchaseOrderVM.Remarks);
                dynamicParameterlist.Add("@CreatedUserId", newPurchaseOrderVM.CreatedUserId);
                dynamicParameterlist.Add("@LastModifiedUserId", newPurchaseOrderVM.LastModifiedUserId);

                newPurchaseOrderVm = await dbConnection.QuerySingleOrDefaultAsync<NewPurchaseOrderVM>("stk.UpdatePurchaseOrderSummeryDetailsByID", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
            return newPurchaseOrderVM;
        }

        public async Task<IEnumerable<PurchaseDraftSummeryVM>> GetPurchaseOrderDraftSummeryDetailsByUserId(int companyId, int userId)
        {
            IEnumerable<PurchaseDraftSummeryVM> purchaseDraftSummeryVM ;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@CompanyId", companyId);
                dynamicParameterlist.Add("@UserId", userId);
                purchaseDraftSummeryVM = await dbConnection.QueryAsync<PurchaseDraftSummeryVM>("stk.GetPurchaseOrderDraftSummeryDetailsByUserId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                return purchaseDraftSummeryVM;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<NewPurchaseOrderVM> UpdateAllPurchaseOrderRecieved(int purchaseOrderId, int userId)
        {
            NewPurchaseOrderVM newPurchaseOrderVM = new NewPurchaseOrderVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PurchaseOrderId", purchaseOrderId);
                dynamicParameterlist.Add("@UserId", userId);
                newPurchaseOrderVM = await dbConnection.QuerySingleOrDefaultAsync<NewPurchaseOrderVM>("stk.UpdateAllPurchaseOrderRecieved", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return newPurchaseOrderVM;
        }

        public async Task<PurchaseOrderMasterVM> UpdatePurchaseOrderStatusByPurchaseNo(string purchaseNo , int userId)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVM = new PurchaseOrderMasterVM();
            try
            {
                var dynamicParamterlist = new DynamicParameters();
                dynamicParamterlist.Add("@PurchaseNo", purchaseNo);
                dynamicParamterlist.Add("@UserId", userId);

                purchaseOrderMasterVM = await dbConnection.QuerySingleOrDefaultAsync<PurchaseOrderMasterVM>("stk.UpdatePurchaseOrderIssueStatusByPurchaseNo", dynamicParamterlist, _transaction, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
             }

            return purchaseOrderMasterVM;
        }

      
    }
    }



