using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
  public  interface IPurchaseOrderRecieveServices
    {
        Task<PurchaseOrderMasterVM> UpdateAllPurchaseOrderRecieve(string PurchaseOrderNo,  int recieveTypeId,int userId,int isBilled,int isRecieved);
        Task<PurchaseOrderMasterVM> UpdatePartiallyPurchaseOrderRecieve(PurchaseOrderMasterVM purchaseOrderMasterVM, int isBilling);
        Task<PurchaseOrderMasterVM> GetPurchaseOrderRecievedDetailsByPurchaseNo(string PurchaseOrderNo, int recieveTypeId, int isHistory);
        Task<PurchaseOrderMasterVM> GetPurchaseOrderRecieveDetailsByDocumentNo(string recievedIds);
        Task < IEnumerable< PurchaseOrderSummeryVM>> GetPurchaseOrderRecievedDetailsByCompanyId(int companyId,int isPendingBill,int pageId);

    }
}
