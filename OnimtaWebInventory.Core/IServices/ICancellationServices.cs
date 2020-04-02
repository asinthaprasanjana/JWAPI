using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
    public interface ICancellationServices
    {
        Task<CancellationVM> AddNewCancellationDetails(CancellationVM cancellationVM);
        Task<IEnumerable<PurchaseOrderMasterVM>> GetCancellationData(int cancellationTypeId);
        Task<PurchaseOrderMasterVM> GetCancellationSummaryData(int cancellationTypeId, string id);
        Task<PurchaseOrderMasterVM> updateCancellationData(int cancellationTypeId, string rferenceNo,int notificationTypeId,string reason, int isCancelled,int userId);


    }
}
