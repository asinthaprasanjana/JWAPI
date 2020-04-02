using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
    public interface IStockAdjusmentRepository
    {
        Task<IEnumerable<StockAdjustmentSummeryVM>> GetStockAdjusmentSummeryByCompanyId(int companyId);
        Task<StockAdjustmentSummeryVM> GetStockAdjusmentId(int companyId);
        Task<StockAdjustmentSummeryVM> AddStockAdjusmentSummeryDetails(StockAdjustmentSummeryVM stockAdjustmentSummeryVM);
        Task<StockAdjustmentDetailVM> AddstockAdjusmentDetails(StockAdjustmentDetailVM StockAdjustmentDetailVM);
        Task<IEnumerable<StockAdjustmentDetailVM>> GetStockAdjusmentDetailsByAdjusmentId(string StockAdjustmentId);
        Task<IEnumerable<StockAdjustmentDetailVM>> GetProductStockCountByBranchId(int BranchId,int ProductId);
        Task<IEnumerable<StockAdjustmentSummeryVM>> GetStockAdjusmentSummeryByBranchId(int BranchId);
        Task<StockAdjustmentSummeryVM> GetStockAdjusmentSummeryByAdjusmentId(string stockAdjustmentId);




    }
}
