using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
    public interface IStockTransferRepository
    {
        Task<IEnumerable< StockTransferSummeryVM>> GetStockTransferSummaryDetails(int companyId);
        Task<IEnumerable<StockTransferSummeryVM> >GetStockTransferId(int companyId);
        Task<StockTransferSummeryVM> AddStockTransferSummeryDraftDetails(StockTransferSummeryVM stockTransferSummeryVM);
        Task<StockTransferItemVM> AddStockTransferItemDraft(StockTransferItemVM stockTransferItemVM);
        Task<StockTransferSummeryVM> GetStockTransferDetailsById( int transferId, int companyId);
        Task<StockTransferItemVM> DeleteStockTransferItemById(int Id);
        Task<StockTransferSummeryVM> updateStockTransferDetails(int transferId);
        //Task<IEnumerable<StockTransferItemVM>> updateStockTransferItem(int transferId,int transferIdDraft);
        Task<IEnumerable<StockTransferSummeryVM>> GetAllTransferSummeryDraft();
        Task<IEnumerable<StockTransferItemVM>> GetStockTransferItemDraftByTransferId(string TransferId);
        Task<IEnumerable<StockTransferSummeryVM>> GetStockTranferSummeryDetailsByDestinationId(int BranchId);
        Task<IEnumerable<StockTransferItemVM>> GetStockTransferItemByTransferId(string TransferId);
        Task<StockTransferSummeryVM> UpdateStockTransferSummeryDetailsByTransferId(StockTransferSummeryVM stockTransferSummeryVM);
        Task<IEnumerable<StockTransferSummeryVM>> GetStockTranferSummeryDetailsBySourceId(int BranchId);

        Task<IEnumerable<StockTransferSummeryVM>> GetStockTranferSummeryDetails(int pageNumber, int rows);




    }
}
