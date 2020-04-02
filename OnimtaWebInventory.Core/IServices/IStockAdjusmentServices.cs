using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
    public interface IStockAdjusmentServices
    {
        Task<IEnumerable<StockAdjustmentSummeryVM>> GetStockAdjusmentSummeryByCompanyId(int companyId);
        Task<StockAdjustmentSummeryVM> GetStockAdjusmentId(int companyId);
        Task<StockAdjustmentDetailVM> AddstockAdjusmentDetails(IEnumerable<StockAdjustmentDetailVM> StockAdjustmentDetailVM);
        Task<StockAdjustmentSummeryVM> GetStockAdjusmentDetailsByAdjusmentId(string StockAdjustmentId);
        Task<IEnumerable<StockAdjustmentDetailVM>> GetProductStockCountByBranchId(int BranchId, int ProductId);
        Task<IEnumerable<StockAdjustmentSummeryVM>> GetStockAdjusmentSummeryByBranchId(int BranchId);

    }
}
