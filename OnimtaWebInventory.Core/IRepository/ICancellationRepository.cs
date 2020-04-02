using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
   public interface ICancellationRepository
    {
        Task<CancellationVM> AddNewCancellationDetails(CancellationVM cancellationVM);
        Task<IEnumerable<PurchaseOrderMasterVM>> GetCancellationData(int cancellationTypeId);
        Task<PurchaseOrderMasterVM> GetCancellationSummaryData(int cancellationTypeId, string id);
        Task<IEnumerable<PurchaseOrderItemVM>> GetCancellationProductData(int cancellationTypeId, string id);
        Task<PurchaseOrderMasterVM> updateCancellationData(int cancellationTypeId, string id,int isCancelled,int userId);


    }
}
