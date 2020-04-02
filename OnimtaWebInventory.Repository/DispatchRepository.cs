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
    public class DispatchRepository :DBContext, IDispatchRepository
    {
        public async Task<DispatchVM> AddNewDispatchDetails(DispatchVM dispatchVM)
        {
            DispatchVM dispatchVm = new DispatchVM();
            PurchaseOrderItemVM purchaseOrderItemVM = new PurchaseOrderItemVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@TypeId", dispatchVM.TypeId);
                dynamicParameterlist.Add("@BusinessPartnerId", dispatchVM.BusinessPartnerId);
                dynamicParameterlist.Add("@DispatchTypeId", dispatchVM.DispatchTypeId);
                dynamicParameterlist.Add("@BusinessPartnerTypeId", dispatchVM.BusinessPartnerTypeId);
                dynamicParameterlist.Add("@ReasonId", dispatchVM.ReasonId);
                dynamicParameterlist.Add("@ReasonName", dispatchVM.ReasonName);
                dynamicParameterlist.Add("@Comment", dispatchVM.Comment);
                dynamicParameterlist.Add("@CreatedUserId", dispatchVM.CreatedUserId);
                dynamicParameterlist.Add("@ReturnDate", dispatchVM.ReturnDate);
                dynamicParameterlist.Add("@RecieveStatus", dispatchVM.RecieveStatus);
                dynamicParameterlist.Add("@ContactDetail", dispatchVM.ContactDetail);
                dynamicParameterlist.Add("@Reason", dispatchVM.Reason);

                dispatchVm = await dbConnection.QuerySingleOrDefaultAsync<DispatchVM>("stk.AddNewDispatchDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

                for(int i=0 ; i < dispatchVM.PurchaseOrderItemVM.Count(); i++)
                {
                    var dynamicParameterlist1 = new DynamicParameters();
                    dynamicParameterlist1.Add("@DispatchTypeId", dispatchVM.DispatchTypeId);
                    dynamicParameterlist1.Add("@DocumentNumber", dispatchVm.DocumentNo);
                    dynamicParameterlist1.Add("@ProductId",dispatchVM.PurchaseOrderItemVM.ElementAt(i).ProductId );
                    dynamicParameterlist1.Add("@ProductName", dispatchVM.PurchaseOrderItemVM.ElementAt(i).ProductName);
                    dynamicParameterlist1.Add("@Quantity",dispatchVM.PurchaseOrderItemVM.ElementAt(i).Quantity);
                    dynamicParameterlist1.Add("@PackSizeName",dispatchVM.PurchaseOrderItemVM.ElementAt(i).PackSizeName);
                    dynamicParameterlist1.Add("@PackSizeId",dispatchVM.PurchaseOrderItemVM.ElementAt(i).PackSizeId);
                    purchaseOrderItemVM = await dbConnection.QuerySingleOrDefaultAsync<PurchaseOrderItemVM>("stk.AddDispatchItemsDetails",dynamicParameterlist1, _transaction, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dispatchVM;
        }

        public async Task<IEnumerable<DispatchVM>> GetAllDispatchDetails(int dispatchTypeId)
        {
           IEnumerable<DispatchVM>dispatchVM;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@DispatchTypeId",dispatchTypeId);
                dispatchVM = await dbConnection.QueryAsync<DispatchVM>("stk.GetAllDispatchDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dispatchVM;
        }

        public async Task<DispatchVM> GetDispatchDetailsById(int id)
        {
            DispatchVM dispatchVM = new DispatchVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id ",id);
                dispatchVM = await dbConnection.QuerySingleOrDefaultAsync<DispatchVM>("stk.GetDispatchDetailsById", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dispatchVM;
        }

        public async Task<IEnumerable<PurchaseOrderItemVM>> GetGatePassItemsDetails(string DocumentNumber)
        {
            IEnumerable<PurchaseOrderItemVM> purchaseOrderItemVM;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@DocumentNumber", DocumentNumber);
                purchaseOrderItemVM = await dbConnection.QueryAsync<PurchaseOrderItemVM>("stk.GetGatePassItemsDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return purchaseOrderItemVM;
        }
    }
}
