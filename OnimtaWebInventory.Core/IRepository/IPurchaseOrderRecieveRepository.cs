using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
    public interface IPurchaseOrderRecieveRepository : IRepository
    {
       // void setTransaction(IDbConnection con, IDbTransaction trn);

        Task<PurchaseOrderMasterVM> UpdateAllPurchaseOrderRecieve(string PurchaseOrderNo, int recieveTypeId, int userId, int recieveId, int isRecieved);
        Task<PurchaseOrderMasterVM> GetPurchaseOrderRecievedDetailsByPurchaseNo(string PurchaseOrderNo, int recieveTypeId, int isHistory);
        Task<PurchaseOrderMasterVM> UpdatePartiallyPurchaseOrderRecieve(PurchaseOrderItemVM PurchaseOrderItemVM,string purchaseNo, int isBilling);
        Task<IEnumerable< PurchaseOrderItemVM>> GetPurchaseOrderRecieveDetailsByDocumentNo(string  recievedId);
        Task<IEnumerable< PurchaseOrderSummeryVM>> GetPurchaseOrderRecievedDetailsByCompanyId(int companyId , int isPendingBill , int pageId);

        Task<ExpireDateHandleVM> AddProductExpireDateDetails(ExpireDateHandleVM expireDateHandleVM);



    }
}
